using APIMantenimiento.Models.DTOs;
using APIMantenimiento.Models.Vaiables;
using Newtonsoft.Json;
using System.Net;

namespace APIMantenimiento.Middleware
{
    public class ExceptionMiddleware
    {
        #region Properties

        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        #endregion Properties

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public ExceptionMiddleware(RequestDelegate next, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _next = next;
            _configuration = configuration;
            _logger = loggerFactory.CreateLogger<ExceptionMiddleware>();
        }
        #endregion Constructor

        #region Public

        /// <summary>
        /// Invoke Async
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                if (ValidateHandleSecretKeyAsync(httpContext).Result)
                {
                    await _next(httpContext);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Masters Microservice. Something went wrong: {ex.Message}");
                await HandleGlobalExceptionAsync(httpContext, ex);
            }
        }
        #endregion Public

        #region Private

        private async Task<bool> ValidateHandleSecretKeyAsync(HttpContext context)
        {
            bool result = true;
            string IP = GetIPAddress(context);

            string secretKeyAPI = _configuration[AppSettings.APP_SALT];

            if (!context.Request.Headers.ContainsKey(AppSettings.SECURITY_KEY_ID))
                /*para corregir el error en security_key_id se debe crear ese metodo en la clase Appsettings*/
            {
                result = false;
            }
            else if (string.IsNullOrEmpty(secretKeyAPI) || string.IsNullOrEmpty(context.Request.Headers[AppSettings.SECURITY_KEY_ID].ToString()))
            {
                result = false;

            }
            else if (!secretKeyAPI.Trim().ToUpper().Equals(context.Request.Headers[AppSettings.SECURITY_KEY_ID].ToString().Trim().ToUpper()))
            {
                result = false;
            }

            if (!result)
            {
                context.Response.ContentType = AppSettings.CONTENT_TYPE;
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await context.Response.WriteAsync(new HttpErrorResponse()
                {
                    StatusCode = context.Response.StatusCode,
                    Description = ServiceMessages.FORBIDDEN,
                    ExceptionMessage = ServiceMessages.FORBIDDEN_MESSAGE
                }.ToString());
            }

            return result;
        }

        /// <summary>
        /// Handle Exception Async
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private async Task HandleGlobalExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = AppSettings.CONTENT_TYPE;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new HttpErrorResponse()
            /* httpErrorRresponse = tipo de respuesta de como se manejara si es error*/
            {
                StatusCode = context.Response.StatusCode,
                Description = ServiceMessages.ERROR,
                ExceptionMessage = exception.Message,
                StackTrace = exception.StackTrace
            }.ToString()));
        }
        /// <summary>
        /// Method to get IP from the client making request
        /// </summary>
        /// <returns>string with IP or Port</returns>
        /// <author>David Estepa</author>
        /// <date>28/11/2022</date>
        private String GetIPAddress(HttpContext httpContext)
        {
            string? ClientIPAddr = httpContext.Connection.RemoteIpAddress?.ToString();

            return ClientIPAddr;
        }
        #endregion Private
    }
}
