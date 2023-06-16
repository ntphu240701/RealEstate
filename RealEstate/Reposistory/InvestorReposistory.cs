using RealEstate.Models;
using Microsoft.EntityFrameworkCore;

namespace RealEstate.Reposistory
{
    public interface IInvestorReposistory
    {
       
    }

    public class InvestorReposistory : IInvestorReposistory
    {
        private Ntphu24072001CnaContext _ctx;

        public InvestorReposistory(Ntphu24072001CnaContext ctx)
        {
            _ctx = ctx;
        }
    }
}
