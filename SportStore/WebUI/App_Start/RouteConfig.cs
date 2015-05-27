using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null, // назначать имя этому элементу маршрута не обязательно
                "",     // соответствует корневому URL, те `/
                new  { controller = "Products", action = "List", page = 1 } // настройки по умолчанию
            );
            routes.MapRoute(
                null,   // назначать имя этому элементу маршрута не обязательно
                "Page{page}", // шаблон URL, например `/Page683
                new { controller = "Products", action = "List" }, // настройки по умолчанию
                new { page = @"\d+" }
            );
        }
    }
}