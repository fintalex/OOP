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

        public ProductsController(IProductsRepository productRepository)
        {
            // это временно пока не будет готова инфраструктура
            //string connString = @"Data Source=ALEX-PC\SQLEXPRESS;Initial Catalog=SportStore;Integrated Security=True";
            //productsRepository = new SqlProductRepository(connString);
            this.productsRepository = productRepository;
        }

        public ViewResult List()
        {
            return View(productsRepository.Products.ToList());
        }
    }
}
