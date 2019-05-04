using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM_System.Entity.Models;
using Newtonsoft.Json;

namespace ATM_System.BusinessLayer.Repository
{
    public class Withdraw : IWithdraw
    {
        public Withdraw(WithdrawDetails withdraw)
        {
            //Setting MaximumLimitAchieved false as maximum limit checker functionality is not implemented yet.
            withdraw.MaximumLimitAchieved = false;
        }


        private bool IsSufficientBalance(WithdrawDetails withdrawDetails, CardDetails user)
        {
            if (user.TotalBalance >= withdrawDetails.Amount)
                return true;
            else
                return false;
        }

        private bool MaximumLimitPerDayAchieved(WithdrawDetails withdrawDetails)
        {
            if (withdrawDetails.MaximumLimitAchieved == false)
                return true;
            else
                return false;
        }

        public CardDetails WithdrawAmount(string json, WithdrawDetails withdrawDetails)
        {
            CardDetails user = new CardDetails();
            List<CardDetails> items = JsonConvert.DeserializeObject<List<CardDetails>>(json);

            user = items.FirstOrDefault(x => x.Username == withdrawDetails.Username);
            if (IsSufficientBalance(withdrawDetails,user))
            {
                user.TotalBalance = user.TotalBalance - withdrawDetails.Amount;
                user.MaximumLimit = user.MaximumLimit + withdrawDetails.Amount;
                user.IsSufficientBalance = true;
            }
            else
            {
                user.IsSufficientBalance = false;
            }

            return user;
        }
    }
}
