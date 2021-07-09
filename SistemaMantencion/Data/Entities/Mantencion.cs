using System;
using System.Collections.Generic;

namespace SistemaMantencion.Data.Entities
{
    public class Mantencion
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public int IdVehiculo { get; set;}
        public Vehiculo Vehiculo { get; set;}
        public List<MantencionMaterial> MantencionProductos { get; set; }
        public List<MantencionTecnico> MantencionEmpleados { get; set; }
    }
}