using RealEstate.Models;
using Microsoft.EntityFrameworkCore;

namespace RealEstate.Reposistory
{
    public interface IInvestorReposistory
    {
        public List<ChuDauTu> GetPropWInvestor();
    }

    public class InvestorReposistory : IInvestorReposistory
    {
        private Ntphu24072001CnaContext _ctx;

        public InvestorReposistory(Ntphu24072001CnaContext ctx)
        {
            _ctx = ctx;
        }

        public List<ChuDauTu> GetPropWInvestor()
        {
            return _ctx.ChuDauTus
            .Include(p => p.Properties)
            .ToList();
        }
    }
}
