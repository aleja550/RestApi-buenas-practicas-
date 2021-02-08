using System.Collections.Generic;

namespace RestApi.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string NombrePlan { get; set; }
        public string Aseguradora { get; set; }
        public List<string> Coberturas { get; set; }
        public List<string> Asistencias { get; set; }
        public int Precio { get; set; }

        public Producto() { }

        public Producto(int id, string nombrePlan, string aseguradora, List<string> coberturas, List<string> asistencias, int precio)
        {
            Id = id;
            NombrePlan = nombrePlan;
            Aseguradora = aseguradora;
            Coberturas = coberturas;
            Asistencias = asistencias;
            Precio = precio;
        }
    }
}
