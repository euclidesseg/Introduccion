using APIMantenimiento.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIMantenimiento.Controllers
{
    [Produces("application/json")]
    /*Produces qu genere como respuesta un json */
    /*Consultar mediaType*/
    [ApiController]
    public class BaseController : ControllerBase
    {

        /// <summary>
        /// Get Response Async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        public async Task<ObjectResult> GetResponseAsync<T>(HttpStatusCode statusCode, string message, T response)
        {
            return await Task.Run(() =>
            {
                var objectResult = new HttpResponse<T>((int)statusCode, message, response);
                return new ObjectResult(objectResult)
                {
                    StatusCode = (int)statusCode
                };
            });
        }
    }
}
