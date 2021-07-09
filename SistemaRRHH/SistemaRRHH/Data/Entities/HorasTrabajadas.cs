using System;

namespace SistemaRRHH.Data.Entities
{
    public class HorasTrabajadas
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public int Horas { get; set; }
        public DateTime fecha { get; set;}
    }
}