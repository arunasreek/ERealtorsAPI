using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERealtors.API.Controllers
{
    [RoutePrefix("ERealtors")]
    public class HomeController : Controller
    {
        [Route("GetUsersList")]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
