using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiteMeBurgers.Models
{
    public class LancheModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do lanche deve ser informado")]
        [MinLength(10, ErrorMessage = "O nome deve ter no mínimo {1} caracteres")]
        [MaxLength(40, ErrorMessage = "O nome deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O preço deve ser informado")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1,999.99, ErrorMessage = "O preço deve estar entre 1 e 999,99")]
        public decimal preco { get; set; }

        [Required(ErrorMessage = "A descrição do lanche deve ser informada")]
        [Display(Name = "Descrição")]
        [MinLength(20, ErrorMessage = "A descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "A descrição deve ter no máximo {1} caracteres")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "A descrição do lanche deve ser informada")]
        [Display(Name = "Descrição detalhada")]
        [MinLength(20, ErrorMessage = "A descrição detalhada deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "A descrição detalhada deve ter no máximo {1} caracteres")]
        public string DescricaoDetalhada { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(300, ErrorMessage = "O caminho da imagem normal não pode exceder {1} caracteres")]
        public string ImagemUrl { get; set; }

        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(300, ErrorMessage = "O caminho da imagem miniatura não pode exceder {1} caracteres")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        public int CategoriaId { get; set; }
        public virtual CategoriaModel Categoria { get; set; }
    }
}
