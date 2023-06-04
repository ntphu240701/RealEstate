using RealEstate.Models;
using Microsoft.EntityFrameworkCore;

namespace RealEstate.Reposistory
{
    public interface IPropertyReposistory
    {
        public List<Property> GetAll();

        public Post GetById(int id);

        //public List<Location> GetPropWLoctation();
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


        public Post GetById(int id) 
        {
            return _ctx.Posts.Where(x => x.Id == id)
                .SingleOrDefault();
            //.Include(p=>p.Properties)
            //.Include(p=>p.Posts)



            //.Where(x => x.Id == id)
            //ThenInclude
            //.SingleOrDefault();
            //return _ctx.Posts.Where(x => x.Id == id).SingleOrDefault();
        }
    }
}
