namespace SistemaMantencion.Data.Entities
{
    public class MantencionMaterial
    {
        public int MantencionId { get; set; }
        public Mantencion Mantencion { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public int Cantidad { get; set; }
    }
}