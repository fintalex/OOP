using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SandersonFirstApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ViewResult Index()
        {
			int hour = DateTime.Now.Hour;
			ViewData["greeting"] = (hour < 12 ? "good morning" : "Good afternoon");

			return View();
        }

		[AcceptVerbs(HttpVerbs.Get)]
		public ViewResult RSVPForm()
		{
			return View();
		}
		[AcceptVerbs(HttpVerbs.Post)]
		public ViewResult RSVPForm(GuestResponse guestResponse)
		{
			if (ModelState.IsValid)
			{
				// todo: send by email
				return View("Thanks", guestResponse);
			}
			else
			{ 
				// ошибка проверки достоверности, отображаем форму данных заново
				return View(guestResponse);
			}
		}
    }
}
