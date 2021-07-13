using Microsoft.EntityFrameworkCore;
using SistemaRRHH.Data.Entities;

namespace SistemaRRHH.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<HorasTrabajadas> HorasTrabajadas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=TestDatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Personas");
                entity.HasKey(p => p.Id);
                entity.HasOne(p => p.Contrato)
                    .WithOne(c => c.Persona)
                    .HasForeignKey<Contrato>(p => p.IdPersona);
            });

            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.ToTable("Contratos");
                entity.HasKey(c => c.Id);
                entity.Property(e => e.FechaInicio).HasColumnType("datetime");
                entity.Property(e => e.FechaTermino).HasColumnType("datetime");
            });

            modelBuilder.Entity<HorasTrabajadas>(entity =>
            {
                entity.ToTable("Horas_Trabajadas");
                entity.Property(e => e.Fecha).HasColumnType("datetime");
                entity.HasKey(c => c.Id);
            });
        }
    }
}
