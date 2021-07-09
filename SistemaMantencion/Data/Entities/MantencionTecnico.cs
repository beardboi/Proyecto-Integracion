namespace SistemaMantencion.Data.Entities
{
    public class MantencionTecnico
    {
        public int MantencionId { get; set; }
        public Mantencion Mantencion { get; set; }
        public string TecnicoRut { get; set; }
        public Tecnico Tecnico { get; set; }
        public int Horas { get; set; }
    }
}