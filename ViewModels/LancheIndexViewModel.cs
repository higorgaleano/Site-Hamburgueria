using BiteMeBurgers.Models;

namespace BiteMeBurgers.ViewModels
{
    public class LancheIndexViewModel
    {
        public IEnumerable<LancheModel> Lanches { get; set; }
        public string CategoriaAtual { get; set; }

    }
}
