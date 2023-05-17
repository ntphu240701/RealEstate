using RealEstate.Models;
using Microsoft.EntityFrameworkCore;

namespace RealEstate.Reposistory
{
    public interface IUserReposistory
    {
        public List<LoginUser> GetAll();
    }

    public class UserReposistory : IUserReposistory
    {
        private Ntphu24072001CnaContext _ctx;
        public UserReposistory(Ntphu24072001CnaContext ctx)
        {
            _ctx = ctx;
        }

        public List<LoginUser> GetAll()
        {
            return _ctx.LoginUsers.Include(x => x.Images).ToList();
        }
    }
}
