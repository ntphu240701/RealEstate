using RealEstate.Models;
using Microsoft.EntityFrameworkCore;

namespace RealEstate.Reposistory
{
    public interface INewsReposistory
    {
        public List<News> GetAll();

        public List<News> GetTop3();

        public News GetById(int Id);
    }

    public class NewsReposistory : INewsReposistory
    {
        private Ntphu24072001CnaContext _ctx;
        public NewsReposistory(Ntphu24072001CnaContext ctx)
        {
            _ctx = ctx;
        }

        public List<News> GetAll()
        {
            return _ctx.News.Include(x => x.Images).ToList();
        }

        public List<News> GetTop3()
        {
            return _ctx.News.Include(x => x.Images).OrderByDescending(x => x.Id).Take(3).ToList();
        }

        public News GetById(int Id)
        {
            return _ctx.News.Where(x => x.Id == Id).SingleOrDefault();
        }
    }
}