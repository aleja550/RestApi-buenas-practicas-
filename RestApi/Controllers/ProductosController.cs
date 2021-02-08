using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.JsonPatch;

using RestApi.Entities;

namespace RestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly List<Producto> productos = Constantes.productos;
        private readonly List<Poliza> polizas = Constantes.polizas;
        private readonly ILogger<ProductosController> _logger;

        public ProductosController(ILogger<ProductosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Obtener()
        {
            return Ok(productos);

            //var productosList = await productosRepository.GetProductos().ToListAsync();
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var producto = productos.Find(p => p.Id == id);

            return Ok(producto);
        }

        [HttpPost]
        public IActionResult Crear([FromBody] Producto producto)
        {
            if (producto == null)
            {
                return BadRequest();
            }

            productos.Add(producto);

            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult Actualizar([FromBody] Producto producto)
        {
            if (producto == null)
            {
                return BadRequest();
            }

            if (productos.Exists(p => p.Id == producto.Id))
            {
                Producto productToChange = productos.Find(p => p.Id == producto.Id);

                productToChange.NombrePlan = producto.NombrePlan;
                productToChange.Aseguradora = producto.Aseguradora;
                productToChange.Coberturas = producto.Coberturas;
                productToChange.Asistencias = producto.Asistencias;
                productToChange.Precio = producto.Precio;
            }

            return Ok("Producto actualizado correctamente.");
        }

        [HttpPatch("{id}")]
        public IActionResult ActualizarParcialmente(int id, [FromBody] JsonPatchDocument<Producto> productoPatch)
        {
            var productoOriginal = productos.Find(p => p.Id == id);

            if (productoOriginal == null)
            {
                return NotFound();
            }

            productoPatch.ApplyTo(productoOriginal, ModelState);

            return StatusCode(202);
        }

        //[HttpPatch("{id}")]
        //public async Task<ActionResult> Parcialmente(int id, [FromBody] Dictionary<string, string> cambio)
        //{
        //    var productoOriginal = productos.Find(p => p.Id == id);

        //    if (productoOriginal == null)
        //    {
        //        return NotFound();
        //    }

        //    if (productoOriginal.GetType().GetProperty(cambio.ElementAt(0).Key).Name.Any())
        //    {
        //        productoOriginal.GetType().GetProperty(cambio.ElementAt(0).Key).SetValue(productoOriginal, cambio.ElementAt(0).Value);
        //    }

        //    await Task.Delay(3);

        //    return StatusCode(202);
        //}

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var producto = productos.RemoveAll(p => p.Id == id);

            return StatusCode(204);
        }


        [Route("{id}/expedir-poliza")]
        [HttpPost]
        public IActionResult ExpedirPoliza([FromBody] Poliza poliza)
        {

            if (poliza == null)
            {
                return BadRequest();
            }

            var producto = productos.Find(p => p.Id == poliza.IdProducto);

            if (producto == null)
            {
                return NotFound();
            }

            Poliza polizaExpedida = new Poliza(poliza.Id, producto.NombrePlan, producto.Aseguradora, producto.Coberturas, producto.Asistencias, producto.Precio,
                                               DateTime.Now, poliza.IdProducto, poliza.Tenedor);

            polizas.Add(polizaExpedida);

            return StatusCode(201);
        }

        [HttpOptions]
        public IActionResult Options()
        {
            Response.Headers.Add("Allow", "GET,POST,PUT,PATCH,DELETE,OPTIONS");
            return Ok();
        }
    }
}
