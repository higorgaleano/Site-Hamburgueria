using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiteMeBurgers.Models
{
    public class PedidoDetalheModel
    {
        public int Id { get; set; }
        public int LancheId { get; set; }
        public int Quantidade { get; set; }
        public int PedidoId { get; set; }

        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Preco { get; set; }

        public virtual LancheModel Lanche { get; set; }
        public virtual PedidoModel Pedido { get; set; }
        
    }
}
