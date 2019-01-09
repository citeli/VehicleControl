using System.Data.Entity.ModelConfiguration;
using ControleVeiculos.Models;

namespace ControleVeiculos.Data.Config
{
    public class ResponsavelConfig : EntityTypeConfiguration<Responsavel>
    {
        public ResponsavelConfig()
        {
            ToTable("Responsaveis");
        }
    }
}
