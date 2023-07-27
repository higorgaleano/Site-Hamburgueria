using System.ComponentModel.DataAnnotations;

namespace BiteMeBurgers.Models
{
    public class CategoriaModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da categoria deve ser informado")]
        [StringLength(40, ErrorMessage = "O nome da categoria não pode exceder {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição da categoria deve ser informada")]
        [Display(Name = "Descrição")]
        [StringLength(200, ErrorMessage = "Descrição não pode exceder {1} caracteres")] 
        public string Descricao { get; set; }
        
        public List<LancheModel> Lanches { get; set; }
    }
}
