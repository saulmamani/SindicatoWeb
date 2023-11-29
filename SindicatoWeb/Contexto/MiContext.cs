using Microsoft.EntityFrameworkCore;
using SindicatoWeb.Models;

namespace SindicatoWeb.Contexto
{
    public class MiContext: DbContext
    {
        public MiContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Chofer> Chofer { get; set; }
        public DbSet<Pago> Pago { get; set; }

    }
}
