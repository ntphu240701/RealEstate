using RealEstate.Models;
using Microsoft.EntityFrameworkCore;

namespace RealEstate.Reposistory
{
    public interface ISellerReposistory
    {
        public List<Seller> GetAll();

        public List<Seller> GetTop3();

        /*public List<Seller> GetById();*/
    }

    public class SellerReposistory : ISellerReposistory
    {
        private Ntphu24072001CnaContext _ctx;
        public SellerReposistory(Ntphu24072001CnaContext ctx)
        {
            _ctx = ctx;
        }

        public List<Seller> GetAll()
        {
            return _ctx.Sellers.ToList();
        }

        public List<Seller> GetTop3()
        {
            return _ctx.Sellers.OrderByDescending(x => x.Id).Take(3).ToList();
        }

        /*public List<Seller> GetById()
        {
            return _ctx.Sellers.Select(x => x.Id).ToList();
        }*/
    }
}
