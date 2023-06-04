using RealEstate.Models;
using Microsoft.EntityFrameworkCore;
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
            Property p = _ctx.Properties
            .Where(x => x.Id == id)
            .Include(x => x.Posts)
                .ThenInclude(post => post.Seller)
            .Include(x => x.Location)
            .SingleOrDefault();

            //List<Post> posts = p.Posts.ToList();

            return p;
        }
    }
}
