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
    }
}
