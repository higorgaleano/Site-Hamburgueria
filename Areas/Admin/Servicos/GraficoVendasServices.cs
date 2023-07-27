using BiteMeBurgers.Context;
using BiteMeBurgers.Models;

namespace BiteMeBurgers.Areas.Admin.Servicos
{
    public class GraficoVendasServices
    {
        private readonly BancoContext _bancoContext;
        public GraficoVendasServices(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }


        public List<LancheGrafico> GetVendasLanches(int dias=360)
        {
            var data = DateTime.Now.AddDays(-dias);

            var lanches = (from pd in _bancoContext.PedidoDetalhes
                           join l in _bancoContext.Lanches on pd.Id equals l.Id
                           where pd.Pedido.PedidoEnviado >= data
                           group pd by new { pd.Id, l.Nome }
                           into g
                           select new
                           {
                               LancheNome = g.Key.Nome,
                               LanchesQuantidade = g.Sum(q => q.Quantidade),
                               LanchesValorToral = g.Sum(a => a.Preco * a.Quantidade)
                           });

            var lista = new List<LancheGrafico>();

            foreach(var item in lanches)
            {
                var lanche = new LancheGrafico();
                lanche.LancheNome = item.LancheNome;
                lanche.LanchesQuantidade = item.LanchesQuantidade;
                lanche.LanchesValorTotal = item.LanchesValorToral;
                lista.Add(lanche);
            }

            return lista;
        }
    }
}
