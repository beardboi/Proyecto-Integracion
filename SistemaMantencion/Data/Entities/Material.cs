using System.Collections.Generic;

namespace SistemaMantencion.Data.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<MantencionMaterial> MantencionesMateriales { get; set; }
    }
}