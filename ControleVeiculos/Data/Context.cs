using System.Data.Entity;
using ControleVeiculos.Data.Config;
using ControleVeiculos.Models;

namespace ControleVeiculos.Data
{
    public class Context : DbContext
    {
        public Context() : base("DbControleVeiculos")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Responsavel> Responsaveis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties()
                .Where(p => p.Name == "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new VeiculoConfig());
            modelBuilder.Configurations.Add(new ResponsavelConfig());
            modelBuilder.Configurations.Add(new CategoriaConfig());
        }
    }
}
