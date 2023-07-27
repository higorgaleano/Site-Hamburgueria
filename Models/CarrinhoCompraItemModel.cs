using System.ComponentModel.DataAnnotations;

namespace BiteMeBurgers.Models
{
    public class CarrinhoCompraItemModel
    {
        public int Id { get; set; }
        public LancheModel Lanche { get; set; }

        public int Quantidade { get; set; }

        [StringLength(200)]
        public string CarrinhoCompraId { get; set; }
    }
}
