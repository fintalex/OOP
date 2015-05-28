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
        public int PageSize = 1; // позже изменим
        private IProductsRepository productsRepository;

        public ProductsController(IProductsRepository productRepository)
        {
            // это временно пока не будет готова инфраструктура
            //string connString = @"Data Source=ALEX-PC\SQLEXPRESS;Initial Catalog=SportStore;Integrated Security=True";
            //productsRepository = new SqlProductRepository(connString);
            this.productsRepository = productRepository;
        }

        public ViewResult List(string category, int page)
        {
            var productsInCategory = (category == null) ? productsRepository.Products : productsRepository.Products.Where(x => x.Category == category);

            int numProducts = productsInCategory.Count();
            ViewBag.TotalPages = (int)Math.Ceiling((double)numProducts / PageSize);
            ViewBag.CurrentPage = page;
            ViewBag.CurrentCategory = category; // для использования при генерации ссылок на страницы

            return View(productsInCategory
                        .Skip((page-1) * PageSize)
                        .Take(PageSize)
                        .ToList());
        }
    }
}
