using System.Collections.Generic;

namespace SistemaRRHH.Data.Entities
{
    public class Persona
    {
        public int Id { get; set; }
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public Contrato Contrato { get; set; }
        public ICollection<Pago> Pagos { get; set; }
        public ICollection<HorasTrabajadas> HorasTrabajadas { get; set;}
    }
}
