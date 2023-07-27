using BiteMeBurgers.Context;
using BiteMeBurgers.Models;
using Microsoft.EntityFrameworkCore;

namespace BiteMeBurgers.Areas.Admin.Servicos
{
    public class RelatorioVendasServico
    {
        private readonly BancoContext _bancoContext;
        public RelatorioVendasServico(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }


        public async Task<List<PedidoModel>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in _bancoContext.Pedidos select obj;

            if(minDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado >= minDate.Value);
            }
            if(maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado <= maxDate.Value);
            }

            return await resultado
                        .Include(l => l.PedidosItens)
                        .ThenInclude(l => l.Lanche)
                        .OrderByDescending(x => x.PedidoEnviado)
                        .ToListAsync();
        }
    }
}
