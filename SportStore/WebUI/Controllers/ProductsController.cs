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
        public int PageSize = 4; // позже изменим
        private IProductsRepository productsRepository;

        public ProductsController(IProductsRepository productRepository)
        {
            // это временно пока не будет готова инфраструктура
            //string connString = @"Data Source=ALEX-PC\SQLEXPRESS;Initial Catalog=SportStore;Integrated Security=True";
            //productsRepository = new SqlProductRepository(connString);
            this.productsRepository = productRepository;
        }

        public ViewResult List(int page)
        {
            int numProducts = productsRepository.Products.Count();
            ViewBag.TotalPages = (int)Math.Ceiling((double)numProducts / PageSize);
            ViewBag.CurrentPage = page;
            return View(productsRepository.Products
                                          .Skip((page-1) * PageSize)
                                          .Take(PageSize)
                                          .ToList());
        }
    }
}
