using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_System.Entity.Models
{
    public class WithdrawDetails : CardDetails
    {
        public string AccountType { set; get; }
        public int Amount { set; get; }
        public bool MaximumLimitAchieved { set; get; }
        public int MaximumLimit { set; get; }
    }
}
