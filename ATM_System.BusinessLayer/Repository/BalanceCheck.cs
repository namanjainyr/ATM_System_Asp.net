using ATM_System.Entity.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ATM_System.BusinessLayer.Repository
{
    public class BalanceCheck : IBalanceCheck
    {
        public CardDetails Check_Balance(string json, CardDetails user)
        {
            List<CardDetails> items = JsonConvert.DeserializeObject<List<CardDetails>>(json);
            user = items.FirstOrDefault(x => x.Username == user.Username);
            return user;
        }
    }
}
