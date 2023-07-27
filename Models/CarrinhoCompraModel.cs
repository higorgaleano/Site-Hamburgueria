using BiteMeBurgers.Context;
using Microsoft.EntityFrameworkCore;

namespace BiteMeBurgers.Models
{
    public class CarrinhoCompraModel
    {
        private readonly BancoContext _bancoContext;
        public CarrinhoCompraModel(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }


        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItemModel> CarrinhoComprasItens { get; set; }


        public static CarrinhoCompraModel GetCarrinho(IServiceProvider services)
        {
            //define uma sessao
            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço do tipo do meu contexto
            var bancoContext = services.GetService<BancoContext>();

            //obtem ou gera o Id do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na sessao
            session.SetString("CarrinhoId", carrinhoId);

            return new CarrinhoCompraModel(bancoContext)
            {
                CarrinhoCompraId = carrinhoId
            };
        }

        public void AdicionarAoCarrinho(LancheModel lanche)
        {
            var carrinhoCompraItem = _bancoContext.CarrinhoCompraItens
                .SingleOrDefault(x => x.Lanche.Id == lanche.Id && x.CarrinhoCompraId == CarrinhoCompraId);

            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItemModel
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };

                _bancoContext.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }

            _bancoContext.SaveChanges();
        }

        public int RemoverDoCarrinho(LancheModel lanche)
        {
            var carrinhoCompraItem = _bancoContext.CarrinhoCompraItens
                .SingleOrDefault(x => x.Lanche.Id == lanche.Id && x.CarrinhoCompraId == CarrinhoCompraId);

            var quantidadeLocal = 0;

            if(carrinhoCompraItem != null)
            {
                if(carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
                else
                {
                    _bancoContext.CarrinhoCompraItens.Remove(carrinhoCompraItem);
                }
            }

            _bancoContext.SaveChanges();
            return quantidadeLocal;
        }

        public List<CarrinhoCompraItemModel> GetCarrinhoCompraItens()
        {
            return CarrinhoComprasItens ?? (CarrinhoComprasItens =
                                          _bancoContext.CarrinhoCompraItens
                                          .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                                          .Include(x => x.Lanche)
                                          .ToList());
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _bancoContext.CarrinhoCompraItens
                                .Where(c => c.CarrinhoCompraId == CarrinhoCompraId);

            _bancoContext.CarrinhoCompraItens.RemoveRange(carrinhoItens);
            _bancoContext.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal()
        {
            var total = _bancoContext.CarrinhoCompraItens
                        .Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                        .Select(x => x.Lanche.preco * x.Quantidade).Sum();

            return total;
        }
    }
}
