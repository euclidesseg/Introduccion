using APIMantenimiento.BL;
using APIMantenimiento.Controllers.V1;
using APIMantenimiento.Models.Vaiables;
using APIMantenimiento.Persistance;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIMantenimiento.Controllers
{

    public class TipoFallasController : BaseV1Controller
    {
        TipoFallaBL _tipoFallaBL;
        public TipoFallasController(TipoFallaBL tipoFallaBL)
        {
            _tipoFallaBL = tipoFallaBL;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _tipoFallaBL.GetAll();
            if (result != null)
            {
                return await GetResponseAsync(HttpStatusCode.OK, ServiceMessages.OK, result);
            }
            return await GetResponseAsync<string>(HttpStatusCode.Unauthorized, ServiceMessages.UNAUTHORIZED, null);
           
        }
    }
}
