using RealEstate.Models;
using Microsoft.EntityFrameworkCore;

namespace RealEstate.Reposistory
{
    public interface ISellerReposistory
    {
        public List<Seller> GetAll();

        public List<Seller> GetTop3();

        public Seller GetById(int Id);

        //public List<Seller> GetProperties();
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
            return _ctx.Sellers.Include(x => x.Images).ToList();
        }

        public List<Seller> GetTop3()
        {
            return _ctx.Sellers.Include(x => x.Images).OrderByDescending(x => x.Id).Take(3).ToList();
        }

        public Seller GetById(int Id)
        {
            return _ctx.Sellers
                .Where(x => x.Id == Id)
                .Include(x=>x.Images).SingleOrDefault();
        }

        /*public List<Seller> GetProperties()
        {
            return _ctx.Sellers
                .Include(x => x.Posts)
                .ThenInclude(post=>post.RealEstate)
                .Include(x=>x.);
        }*/
    }
}