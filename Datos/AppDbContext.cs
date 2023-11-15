using Entidades;
using iText.Commons.Actions.Contexts;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Agrega DbSet para cada entidad que tengas en tu base de datos
        public DbSet<Usuario> Usuarios { get; set; }
        // Agrega otros DbSet según sea necesario...

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración adicional de modelos, relaciones, etc.
        }
    }
}
