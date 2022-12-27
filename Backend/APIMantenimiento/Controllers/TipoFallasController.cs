using Microsoft.AspNetCore.Mvc;

namespace APIMantenimiento.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("text/json")]
    public class TipoFallasController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "OK";
        }
    }
}
