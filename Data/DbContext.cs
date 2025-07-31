using LightIdiomas.Entities;
using Microsoft.EntityFrameworkCore;

namespace LightIdiomas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Turma> Turmas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cidade>()
                .HasOne(c => c.Estado)
                .WithMany(e => e.Cidades)
                .HasForeignKey(c => c.EstadoId);

            modelBuilder.Entity<Clientes>()
                .HasOne(c => c.Cidade)
                .WithMany()
                .HasForeignKey(c => c.CidadeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Clientes>()
                .HasOne(c => c.Turma)
                .WithMany(t => t.Clientes)
                .HasForeignKey(c => c.TurmaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
