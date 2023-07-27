using BiteMeBurgers.Areas.Admin.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace BiteMeBurgers.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminGraficoController : Controller
    {
        private readonly GraficoVendasServices _graficoVendasServices;
        public AdminGraficoController(GraficoVendasServices graficoVendasServices)
        {
            _graficoVendasServices = graficoVendasServices;
        }


        public JsonResult VendasLanches(int dias)
        {
            var lanchesVendasTotais = _graficoVendasServices.GetVendasLanches(dias);
            return Json(lanchesVendasTotais);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult VendasMensal()
        {
            return View();
        }

        [HttpGet]
        public IActionResult VendasSemanal()
        {
            return View();
        }
    }
}
