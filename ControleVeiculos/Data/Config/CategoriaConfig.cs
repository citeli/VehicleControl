using System.Data.Entity.ModelConfiguration;
using ControleVeiculos.Models;

namespace ControleVeiculos.Data.Config
{
    public class CategoriaConfig : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfig()
        {
            ToTable("Categorias");
        }
    }
}
