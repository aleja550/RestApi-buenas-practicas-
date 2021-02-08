using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

using RestApi.Entities;

namespace RestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TenedoresController : ControllerBase
    {
        private readonly List<Tenedor> tenedores = Constantes.tenedores;
        private readonly List<Poliza> polizas = Constantes.polizas;
        private readonly ILogger<TenedoresController> _logger;

        public TenedoresController(ILogger<TenedoresController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Obtener()
        {
            return Ok(tenedores);
        }

        [Route("{id}/polizas")]
        [HttpGet]
        public IActionResult PolizasDelTenedor(int id)
        {
            var polizasTenedor = polizas.FindAll(p => p.Tenedor == id);

            if (polizasTenedor == null)
            {
                return NotFound("El tenedor no tiene polizas");
            }

            return Ok(polizasTenedor);
        }
    }
}
