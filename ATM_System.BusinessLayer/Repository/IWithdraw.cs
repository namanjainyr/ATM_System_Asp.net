using ATM_System.Entity.Models;

namespace ATM_System.BusinessLayer.Repository
{
    public interface IWithdraw
    {
        CardDetails WithdrawAmount(string json, WithdrawDetails withdrawDetails);
    }
}