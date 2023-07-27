using BiteMeBurgers.Models;
using BiteMeBurgers.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BiteMeBurgers.Components
{
    public class CarrinhoCompraResumo : ViewComponent
    {
        private readonly CarrinhoCompraModel _carrinhoCompra;
        public CarrinhoCompraResumo(CarrinhoCompraModel carrinhoCompra)
        {
            _carrinhoCompra = carrinhoCompra;
        }


        public IViewComponentResult Invoke()
        {
            //teste
            //var itens = new List<CarrinhoCompraItemModel>() 
            //{ 
            //    new CarrinhoCompraItemModel(),
            //    new CarrinhoCompraItemModel()
            //};

            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoComprasItens = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraVM);
        }
    }
}
