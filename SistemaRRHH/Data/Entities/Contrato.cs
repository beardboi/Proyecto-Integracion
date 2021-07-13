using System;

namespace SistemaRRHH.Data.Entities
{
    public class Contrato
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaTermino { get; set; }
        public int Sueldo { get; set; }
        public int ValorHoraExtra { get; set; }
        public Persona Persona { get; set; }
    }
}
