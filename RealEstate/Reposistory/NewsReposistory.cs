using RealEstate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RealEstate.Models.Admin_Models;
using NuGet.Protocol.Plugins;

namespace RealEstate.Reposistory
{
    public interface INewsReposistory
    {
        public List<News> GetAll();

        public List<News> GetTop3();

        public News GetById(int Id);
        public void Addnew(News news);
        public void EditingNew(News news);
        public void DeleteNews(News news);
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
            return _ctx.News.ToList();
        }

        public List<News> GetTop3()
        {
            return _ctx.News.Include(x => x.Images).OrderByDescending(x => x.Id).Take(3).ToList();
        }

        public News GetById(int Id)
        {
            return _ctx.News
                .Where(x => x.Id == Id)
                .Include(x => x.Images)
                .SingleOrDefault();
        }
        public void Addnew(News news)
        {
            _ctx.News.Add(news);
            _ctx.SaveChanges();
        }

        public void EditingNew(News news)
        {
            if (news != null)
            {
                var existingNew = _ctx.News.Where(x => x.Id == news.Id).FirstOrDefault();
                if (existingNew != null)
                {
                    existingNew.Id = news.Id;
                    existingNew.Contents = news.Contents;
                    existingNew.Date = news.Date;
                    existingNew.Title = news.Title;

                    _ctx.SaveChanges();
                }
            }
        }

        public void DeleteNews(News news)
        {
            if (news != null)
            {
                    _ctx.News.Remove(news);
                    _ctx.SaveChanges();
            }
        }
    }
}