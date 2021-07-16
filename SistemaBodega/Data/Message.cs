using System;

namespace SistemaBodega.Data
{
    public class Message
    {
        public DateTime FechaMantencion { get; set; }
        public string Material { get; set; }
        public int Cantidad { get; set; }
    }
}