using BiteMeBurgers.Models;

namespace BiteMeBurgers.Repositories.Interfaces
{
    public interface ILancheRepository
    {
        IEnumerable<LancheModel> Lanches { get; }
        IEnumerable<LancheModel> LanchesPreferidos  { get; }
        LancheModel GetLancheById (int id);
    }
}
