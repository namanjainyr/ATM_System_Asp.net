using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATM_System.Entity.Models;

namespace ATM_System.WebPortal.Controllers
{
    public class LoggedInController : Controller
    {
        // GET: LoggedIn
        public ActionResult Index(CardDetails cardDetails)
        {
            return View(cardDetails);
        }
    }
}