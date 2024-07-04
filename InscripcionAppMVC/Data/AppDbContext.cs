using InscripcionAppMVC.Models;
using Microsoft.EntityFrameworkCore;
namespace InscripcionAppMVC.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}

        public DbSet<Aspirante> Aspirantes { get; set; }
        public DbSet<TipoAspirante> TiposAspirante { get; set; }
        public DbSet<Programa> Programas { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
