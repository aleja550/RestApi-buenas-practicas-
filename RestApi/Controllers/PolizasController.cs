using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

using RestApi.Entities;

namespace RestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PolizasController : ControllerBase
    {
        private readonly List<Poliza> polizas = Constantes.polizas;
        private readonly ILogger<PolizasController> _logger;

        public PolizasController(ILogger<PolizasController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Obtener()
        {
            return Ok(polizas);
        }
    }
}
