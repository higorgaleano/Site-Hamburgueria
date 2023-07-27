using BiteMeBurgers.Models;
using BiteMeBurgers.Repositories.Interfaces;
using BiteMeBurgers.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BiteMeBurgers.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }


        public IActionResult Index(string categoria)
        {
            IEnumerable<LancheModel> lanches = Enumerable.Empty<LancheModel>();
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(x => x.Id);
                categoriaAtual = "Todos";
            }
            else
            {
                lanches = _lancheRepository.Lanches
                    .Where(x => x.Categoria.Nome.Equals(categoria))
                    .OrderBy(x => x.Nome);
            }

            var lanchesIndexViewModel = new LancheIndexViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            return View(lanchesIndexViewModel);
        }

        public IActionResult Detalhes(int id)
        {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(x => x.Id == id);
            return View("Detalhes", lanche);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<LancheModel> lanches;
            string categoriaAtual = string.Empty;

            if(string.IsNullOrEmpty(searchString))
            {
                lanches = _lancheRepository.Lanches.OrderBy(x => x.Id);
                categoriaAtual = "Todos os Lanches";
            }
            else
            {
                lanches = _lancheRepository.Lanches
                    .Where(x => x.Nome.ToLower().Contains(searchString.ToLower()));

                if (lanches.Any())
                    categoriaAtual = "Lanches";
                else
                    categoriaAtual = "Nenhum lanche foi encontrado";
            }

            return View("~/Views/Lanche/Index.cshtml", new LancheIndexViewModel 
            { 
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            });
        }
    }
}
