using ATM_System.Entity.Models;

namespace ATM_System.BusinessLayer.Repository
{
    public interface IBalanceCheck
    {
        CardDetails Check_Balance(string json, CardDetails cardDetails);
    }
}