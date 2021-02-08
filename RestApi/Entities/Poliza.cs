using System;
using System.Collections.Generic;

namespace RestApi.Entities
{
    public class Poliza
    {
        public int Id { get; set; }
        public string NombrePlan { get; set; }
        public string Aseguradora { get; set; }
        public List<string> Coberturas { get; set; }
        public List<string> Asistencias { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public int IdProducto { get; set; }
        public int Tenedor { get; set; }

        public Poliza() { }
        public Poliza(int id, int idProducto, int tenedor)
        {
            Id = id;
            IdProducto = idProducto;
            Tenedor = tenedor;
        }
        public Poliza(int id, string nombrePlan, string aseguradora, List<string> coberturas, List<string> asistencias, decimal precio, DateTime fechaExpedicion, int idProducto, int tenedor)
        {
            Id = id;
            NombrePlan = nombrePlan;
            Aseguradora = aseguradora;
            Coberturas = coberturas;
            Asistencias = asistencias;
            Precio = precio;
            FechaExpedicion = fechaExpedicion;
            IdProducto = idProducto;
            Tenedor = tenedor;
        }
    }
}
