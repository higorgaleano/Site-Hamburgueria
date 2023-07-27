using BiteMeBurgers.Models;

namespace BiteMeBurgers.ViewModels
{
    public class PedidoLancheViewModel
    {
        public PedidoModel Pedido { get; set; }
        public IEnumerable<PedidoDetalheModel> PedidoDetalhes { get; set; }
    }
}
