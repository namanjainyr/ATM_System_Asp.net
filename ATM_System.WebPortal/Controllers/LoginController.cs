using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ATM_System.BusinessLayer.Repository;
using ATM_System.Common;
using ATM_System.Entity.Models;

namespace ATM_System.WebPortal.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CardInserted()
        {
            #region Declarations
            string path = Constants.path;
            string json = "";
            CardDetails carddetails = new CardDetails();
            IAuthenticate authenticate = new Authenticate();
            #endregion

            #region Reading Json File

            using (StreamReader r = new StreamReader(path))
            {
                json = r.ReadToEnd();
            }

            #endregion

            #region AssignsValuesFromConfig
            carddetails.Username = WebConfigurationManager.AppSettings["UserName"];
            carddetails.Pin = Convert.ToInt16(WebConfigurationManager.AppSettings["Pin"]);
            carddetails.UserType = WebConfigurationManager.AppSettings["UserType"];
            carddetails.ExpiryDate = WebConfigurationManager.AppSettings["ExpiryDate"];
            carddetails.IsLost = Convert.ToBoolean(WebConfigurationManager.AppSettings["IsLost"]);
            #endregion

            #region Calling Method IsValidCard()

            bool IsValidCard = authenticate.IsCardValid(carddetails, json);

            if (IsValidCard)
            {
                Session["user"] = carddetails.Username;
                bool MaxAttempts = authenticate.NumberOFAttempts(carddetails);
                return RedirectToAction("Index", "LoggedIn", new ATM_System.Entity.Models.CardDetails() { Username = carddetails.Username });

            }

            else
            {
                bool MaxAttempts = authenticate.NumberOFAttempts(carddetails);
                if (MaxAttempts)
                    return RedirectToAction("CardNotFound", "Login");

                else
                    return RedirectToAction("MaxAttemptsReached", "Login");



            }
            #endregion



        }

        public ActionResult CardNotFound()
        {

            return View();
        }

        public ActionResult MaxAttemptsReached()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            Session["user"] = null;
            return View();
        }




    }
}