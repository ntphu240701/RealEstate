using RealEstate.Models;
using Microsoft.EntityFrameworkCore;


namespace RealEstate.Reposistory
{
    public interface ICategoryReposistory
    {

    }

    public class CategoryReposistory : ICategoryReposistory
    {
        private Ntphu24072001CnaContext _ctx;

        public CategoryReposistory(Ntphu24072001CnaContext ctx)
        {
            _ctx = ctx;
        }
    }

}


