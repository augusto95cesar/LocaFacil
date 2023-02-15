using LocaFacilWeb.Models.Entity;
using System.Data.Entity;

namespace LocaFacilWeb.Models.Repository
{
    public class LocaFacilContext : DbContext
    {
        public LocaFacilContext() : base("name=LocaFacilContext") {}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Locacao> Locacoes { get; set; } 
    }
}