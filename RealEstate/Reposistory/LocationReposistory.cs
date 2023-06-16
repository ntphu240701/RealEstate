using RealEstate.Models;
using Microsoft.EntityFrameworkCore;

namespace RealEstate.Reposistory
{
    public interface ILocationReposistory
    {
        
    }

    public class LocationReposistory : ILocationReposistory
    {
        private Ntphu24072001CnaContext _ctx;

        public LocationReposistory(Ntphu24072001CnaContext ctx)
        {
            _ctx = ctx;
        }
    }
}
