using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ATM_System.Entity.Models;

namespace ATM_System.WebPortal.Controllers
{
    public class ChangePinController : Controller
    {
        // GET: ChangePin
        public ActionResult Index(string username, string pin)
        {
            CardDetails cardDetails = new CardDetails();
            cardDetails.Pin = Convert.ToInt32(pin);
            cardDetails.Username = username;
            return View(cardDetails);
        }

        public ActionResult ChangeOldPin(CardDetails cardDetails)
        {
            if (cardDetails.NewPin == cardDetails.ConfirmPin)
            {
                cardDetails.Pin = Convert.ToInt32(cardDetails.NewPin);
                return View();
            }
            else
            {
                return RedirectToAction("ChangePin_Failed", "ChangePin");
            }
        }

        public ActionResult ChangePin_Failed()
        {
            return View();
        }
    }
}