using BiteMeBurgers.Models;

namespace BiteMeBurgers.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        void CriarPedido(PedidoModel pedido);
    }
}
