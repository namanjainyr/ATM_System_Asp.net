using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using ATM_System.BusinessLayer.Repository;
using ATM_System.Common;
using ATM_System.Entity.Models;
using Newtonsoft.Json;

namespace ATM_System.WebPortal.Controllers
{
    public class CheckBalanceController : Controller
    {
        // GET: CheckBalance
        public ActionResult Index(string username)
        {
            #region Declarations

            string path = Constants.path;
            CardDetails user = new CardDetails();

            #endregion


            #region Reading Json and Fetch Total Balance
            user.Username = username;
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                IBalanceCheck Check_Bal = new BalanceCheck();
                user = Check_Bal.Check_Balance(json, user);
            }


            #endregion

            return View(user);
        }
    }
}