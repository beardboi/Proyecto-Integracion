using System;

namespace SistemaRRHH.Data.Entities
{
    public class Pago
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public DateTime FechaPago { get; set; }
        public int MontoSueldo { get; set; }
        public int MontoHorasExtra { get; set; }
        public Persona Persona { get; set; }
    }
}
