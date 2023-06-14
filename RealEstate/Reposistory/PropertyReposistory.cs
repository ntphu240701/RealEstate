using RealEstate.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace RealEstate.Reposistory
{
    public interface IPropertyReposistory
    {
        public List<Property> GetAll();

        public Property GetPropertyById(int id);

    }

    public class PropertyReposistory : IPropertyReposistory
    {
        private Ntphu24072001CnaContext _ctx;
        public PropertyReposistory(Ntphu24072001CnaContext ctx)
        {
            _ctx = ctx;
        }

        public List<Property> GetAll()
        {
            return _ctx.Properties.Include(x => x.Images).ToList();
        }

        public Property GetPropertyById(int id)
        {
            return _ctx.Properties
                .Where(x => x.Id == id)
                .Include(x => x.Posts)
                .ThenInclude(post => post.Seller).ThenInclude(seller => seller.Images)
                .Include(x => x.Location)
                .Include(x => x.Images)
                .Include(x => x.Category)
                .SingleOrDefault();
        }
    }
}