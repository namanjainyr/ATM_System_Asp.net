using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM_System.Entity.Models;

namespace ATM_System.BusinessLayer.Repository
{
    public interface IAuthenticate
    {
        bool IsCardValid(CardDetails cardDetails, string json);
        bool NumberOFAttempts(CardDetails cardDetails);
    }
}
