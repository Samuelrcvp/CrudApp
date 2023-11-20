using CrudApp.Data.Map;
using CrudApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApp.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
