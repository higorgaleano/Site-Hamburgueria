using BiteMeBurgers.Context;
using BiteMeBurgers.Models;
using BiteMeBurgers.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BiteMeBurgers.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly BancoContext _bancoContext;
        public LancheRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }


        public IEnumerable<LancheModel> Lanches => _bancoContext.Lanches.Include(c => c.Categoria);

        public IEnumerable<LancheModel> LanchesPreferidos => _bancoContext.Lanches
            .Where(x => x.IsLanchePreferido)
            .Include(c => c.Categoria);

        public LancheModel GetLancheById(int id)
        {
            return _bancoContext.Lanches.FirstOrDefault(x => x.Id == id);
        }
    }
}
