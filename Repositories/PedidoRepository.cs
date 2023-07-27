using BiteMeBurgers.Context;
using BiteMeBurgers.Models;
using BiteMeBurgers.Repositories.Interfaces;

namespace BiteMeBurgers.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly BancoContext _bancoContext;
        private readonly CarrinhoCompraModel _carrinhoCompra;
        public PedidoRepository(BancoContext bancoContext,
                                CarrinhoCompraModel carrinhoCompra)
        {
            _bancoContext = bancoContext;
            _carrinhoCompra = carrinhoCompra;
        }


        public void CriarPedido(PedidoModel pedido)
        {
            //criacao id pedido
            pedido.PedidoEnviado = DateTime.Now;
            _bancoContext.Pedidos.Add(pedido);
            _bancoContext.SaveChanges();

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoComprasItens;

            foreach (var carrinhoItem in carrinhoCompraItens)
            {
                var pedidoDetail = new PedidoDetalheModel()
                {
                    Quantidade = carrinhoItem.Quantidade,
                    LancheId = carrinhoItem.Lanche.Id,
                    PedidoId = pedido.Id,
                    Preco = carrinhoItem.Lanche.preco
                };
                _bancoContext.PedidoDetalhes.Add(pedidoDetail);
            }
            _bancoContext.SaveChanges();
        }
    }
}
