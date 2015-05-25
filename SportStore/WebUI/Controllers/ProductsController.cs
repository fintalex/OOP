using DomainModel.Abstract;
using DomainModel.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsRepository productsRepository;

        public ProductsController()
        {
            // это временно пока не будет готова инфраструктура
            productsRepository = new FakeProductsRepository();
        }

        public ViewResult List()
        {
            return View(productsRepository.Products.ToList());
        }
    }
}
