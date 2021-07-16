namespace SistemaBodega.Data.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string UnidadMedida { get; set; }
        public int Stock { get; set; }
        public double Precio { get; set; }
    }
}