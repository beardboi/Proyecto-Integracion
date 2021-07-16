using System;

namespace SistemaBodega.Data.Entities
{
    public class MovimientoMaterial
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set;}
        public int IdMaterial { get; set; }
        public Material Material { get; set; }
    }
}