using RealEstate.Models;
using Microsoft.EntityFrameworkCore;

namespace RealEstate.Reposistory
{
    public interface IUserReposistory
    {
        public List<LoginUser> GetAll();
        public LoginUser GetById(int id);
    }

    public class UserReposistory : IUserReposistory
    {
        private Ntphu24072001CnaContext _ctx;
        private List<LoginUser> _users;
        public UserReposistory(Ntphu24072001CnaContext ctx)
        {
            _ctx = ctx;
        }

        public List<LoginUser> GetAll()
        {
            return _ctx.LoginUsers.ToList();
        }

        public LoginUser GetById(int id)
        {
            return _ctx.LoginUsers.FirstOrDefault(user => user.Id == id);
        }

    }
}
