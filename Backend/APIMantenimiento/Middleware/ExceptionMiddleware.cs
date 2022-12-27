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
                if (true)
                {
                    await _next(httpContext);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"API Mantenimiento. Something went wrong: {ex.Message}");
                await HandleGlobalExceptionAsync(httpContext, ex);
            }
        }
        #endregion Public

        #region Private

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

        #endregion Private
    }
}
