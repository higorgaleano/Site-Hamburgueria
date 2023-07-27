using BiteMeBurgers.Models;

namespace BiteMeBurgers.Repository
{
    public interface ICategoriaRepository
    {
        IEnumerable<CategoriaModel> Categorias { get; }
    }
}
