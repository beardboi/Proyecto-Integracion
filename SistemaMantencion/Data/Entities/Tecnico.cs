using System.Collections.Generic;

namespace SistemaMantencion.Data.Entities
{
    public class Tecnico
    {
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public List<MantencionTecnico> MantencionesEmpleado { get; set; }
    }
}