using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ATM_System.Entity.Models
{
    public class CardDetails
    {
        
        public string Username { set; get; }

        
        public int Pin { set; get; }
        public int TotalBalance { set; get; }
        public string UserType { set; get;}
        public string ExpiryDate { set; get; }
        public bool IsLost { set; get; }
        public string NewPin { set; get; }
        public string ConfirmPin { set; get; }
        public string MaximumLimit { set; get; }
        public bool IsSufficientBalance { set; get; }

    }
}
