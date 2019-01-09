using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleVeiculos.Models
{
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [MaxLength(50, ErrorMessage = "Máximo 50 Caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [MaxLength(50, ErrorMessage = "Máximo 50 Caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Descricao { get; set; }

        [ScaffoldColumn(false)]
        public int ResponsavelId { get; set; }

        [ForeignKey("ResponsavelId")]
        public Responsavel Responsavel { get; set; }

        [ScaffoldColumn(false)]
        public int CategoriaId { get; set; }
        [ScaffoldColumn(false)]

        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }
    }
}
