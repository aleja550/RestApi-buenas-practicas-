using System;
using System.Collections.Generic;

using RestApi.Entities;

namespace RestApi
{
    public class Constantes
    {
        public static readonly List<Poliza> polizas = new List<Poliza>
        {
            new Poliza(1, "PlanAntiPolicias", "Equidad", new List<string>{"Repatriación", "Responsabilidad civil"}, new List<string>{"Servicio de grúa", "Conductor elegido"}, 10000, DateTime.Now, 1, 1),
            new Poliza(2, "PlanFull", "Equidad", new List<string>{"Repatriación", "Responsabilidad civil"}, new List<string>{"Servicio de grúa", "Conductor elegido"}, 10000, DateTime.Now, 1, 1),
            new Poliza(3, "PlanBasico", "Equidad", new List<string>{"Repatriación", "Responsabilidad civil"}, new List<string>{"Servicio de grúa", "Conductor elegido"}, 10000, DateTime.Now, 1, 2),
        };

        public static readonly List<Producto> productos = new List<Producto>
        {
            new Producto(1, "EconoPlan", "Mapfre", new List<string>{"Repatriación", "Responsabilidad civil"}, new List<string>{"Servicio de grúa", "Conductor elegido"}, 10000),
            new Producto(2, "PlanMujer", "Mapfre", new List<string>{"Repatriación", "Responsabilidad civil"}, new List<string>{"Servicio de grúa", "Conductor elegido"}, 10000),
            new Producto(3, "SuperTrebol", "Mapfre", new List<string>{"Repatriación", "Responsabilidad civil"}, new List<string>{"Servicio de grúa", "Conductor elegido"}, 10000),
        };

        public static readonly List<Tenedor> tenedores = new List<Tenedor>
        {
            new Tenedor(1, "Alejandra Sandoval"),
            new Tenedor(2, "Paula Goyeneche")
        };
    }
}
