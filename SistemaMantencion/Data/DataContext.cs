using Microsoft.EntityFrameworkCore;
using SistemaMantencion.Data.Entities;

namespace SistemaMantencion.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SistemaMantencionDB;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tecnico>()
                .HasKey(em => new { em.Rut });

            modelBuilder.Entity<MantencionMaterial>(entity =>
            {
                entity.HasKey(mp => new { mp.MantencionId, mp.MaterialId });
                entity.ToTable("Mantencion_Material");
            });

            modelBuilder.Entity<MantencionTecnico>(entity =>
            {
                entity.HasKey(mp => new { mp.MantencionId, mp.TecnicoRut });
                entity.ToTable("Mantencion_Tecnico");
            });
        }

        public DbSet<Material> Materiales { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }
        public DbSet<Mantencion> Mantenciones { get; set; }
        public DbSet<MantencionMaterial> MantencionMateriales { get; set; }
        public DbSet<MantencionTecnico> MantencionTecnicos { get; set; }
    }
}