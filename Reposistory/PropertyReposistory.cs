using RealEstate.Models;
using Microsoft.EntityFrameworkCore;

namespace RealEstate.Reposistory
{
    public interface IPropertyReposistory
    {
        public List<Property> GetAll();
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
    }
}
