using DomainModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductsRepository productsRepository;
        public NavController(IProductsRepository productsRepository) 
        {
            this.productsRepository = productsRepository;
        }
        public ViewResult Menu(string highlightCategory)
        {
            // Поместить в начало ссылку Home
            List<NavLink> navLinks = new List<NavLink>();
            navLinks.Add(new CategoryLink(null) { IsSelected = (highlightCategory == null) });
            //добавить ссылку для каждой отличающейся категории
            var categories = productsRepository.Products.Select(x => x.Category);
            foreach (string category in categories.Distinct().OrderBy(x=>x))
            {
                navLinks.Add(new CategoryLink(category) { IsSelected = (category == highlightCategory) });
            }
            return View(navLinks);
        }
    }

    public class NavLink // представляет ссылку на произвольный элемент маршрута
    {
        public string Text { get; set; }
        public RouteValueDictionary RouteValues { get; set; }
        public bool IsSelected { get; set; }
    }

    public class CategoryLink : NavLink // специфическая ссылка на категорию товаров
    {
        public CategoryLink(string category)
        {
            Text = category ?? "Home";
            RouteValues = new RouteValueDictionary(new
            {
                controller = "Products",
                action = "List",
                category = category,
                page = 1
            });
        }
    }
}
