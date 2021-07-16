using Microsoft.EntityFrameworkCore;
using SistemaBodega.Data.Entities;

namespace SistemaBodega.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // Entidades que se mappearan en la base de datos.
        public DbSet<Material> Materiales { get; set; } 
        public DbSet<MovimientoMaterial> Movimientos_Materiales { get; set; } 

        // Configuracion para utilizar Sqlite.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=SistemaBodegaDB.db");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(p => p.Id);
            });

            modelBuilder.Entity<MovimientoMaterial>(entity =>
            {
                entity.ToTable("Movimiento_Materiales");
                entity.HasKey(mv => mv.Id);
                entity.Property(mv => mv.Fecha).HasColumnType("datetime");
            });
        }
    }
}