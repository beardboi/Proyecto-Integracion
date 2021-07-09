using System.Collections.Generic;

namespace SistemaMantencion.Data.Entities
{
    public class Vehiculo 
    {
        public int Id { get; set; }
        public string Patente { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public string Marca { get; set; }
        public int Anho { get; set; }
        public int Kilometraje { get; set; }
        public string Modelo { get; set; }
        public ICollection<Mantencion> Mantenciones { get; set; }
    }
}