using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestMVC.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error/NotFound
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }

        // GET: Error/Forbidden
        public ActionResult Forbidden()
        {
            Response.StatusCode = 403;
            return View();
        }
    }
}