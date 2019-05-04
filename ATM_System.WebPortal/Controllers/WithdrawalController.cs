using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using ATM_System.BusinessLayer.Repository;
using ATM_System.Entity.Models;
using ATM_System.Common;

namespace ATM_System.WebPortal.Controllers
{
    public class WithdrawalController : Controller
    {

        // GET: Withdrawal
        public ActionResult Index(string username)
        {
            WithdrawDetails details = new WithdrawDetails();
            details.Username = username;
            return View(details);
        }

        public ActionResult withdraw(WithdrawDetails details)
        {
            #region Declarations

            string path = Constants.path;
            string json = "";
            IWithdraw withdraw = new Withdraw(details);
            CardDetails cardDetails = new CardDetails();
            string output = "";

            #endregion

            #region Read Json File

            using (StreamReader r = new StreamReader(path))
            {
                json = r.ReadToEnd();
            }

            #endregion

            #region Money Withdraw and JSON update

            cardDetails = withdraw.WithdrawAmount(json, details);
            if (cardDetails.IsSufficientBalance == true)
            {

                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                foreach (var j in jsonObj)
                {
                    if (j["Username"] == cardDetails.Username)
                        j["TotalBalance"] = cardDetails.TotalBalance;
                }
                output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText(path, output);
                return View(cardDetails);
            }
            else
            {
                return RedirectToAction("Withdrawal_Failed", "Withdrawal");
            }

            #endregion

        }

        public ActionResult Withdrawal_Failed(WithdrawDetails details)
        {
            return View();
        }
    }
}