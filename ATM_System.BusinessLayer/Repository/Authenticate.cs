using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ATM_System.Entity.Models;
using Newtonsoft.Json;

namespace ATM_System.BusinessLayer.Repository
{
    public class Authenticate : IAuthenticate
    {
        private bool _isValid = false;
        private static Dictionary<string,int> _attempts = new Dictionary<string, int>();
        public bool IsCardValid(CardDetails cardDetails, string json)
        {
            #region Declarations $" Initializations"
            CardDetails user = new CardDetails();
            List<CardDetails> items = JsonConvert.DeserializeObject<List<CardDetails>>(json);
            #endregion

            #region Validate Card
            user = items.FirstOrDefault(x => x.Username == cardDetails.Username);
            if (cardDetails.Username == user.Username && cardDetails.Pin == user.Pin && cardDetails.UserType == user.UserType &&
                cardDetails.ExpiryDate == user.ExpiryDate && cardDetails.IsLost == false)
                _isValid = true;



            #endregion

            return _isValid;
        }
        public bool NumberOFAttempts(CardDetails cardDetails)
        {
            if(!(_attempts.ContainsKey(cardDetails.Username)))
                _attempts.Add(cardDetails.Username,1);
            else
            {
                var temp = _attempts[cardDetails.Username];
                temp++;
                _attempts[cardDetails.Username] = temp;
                if (temp > 3)
                {
                    return false;
                }
            }

            return true;

        }
    }
}
