using RealEstate.Models;
using Microsoft.EntityFrameworkCore;


namespace RealEstate.Reposistory

{
    public interface ICategoryReposistory
    {
        public List<Post> GetPosts();

        public List<Category> GetProp();

    }

    public class CategoryReposistory : ICategoryReposistory
    {
        private Ntphu24072001CnaContext _ctx;

        public CategoryReposistory(Ntphu24072001CnaContext ctx)
        {
            _ctx = ctx;
        }

        public List<Post> GetPosts()
        { 
                return _ctx.Posts.Include(p => p.Date).ToList();
        }

        public List<Category> GetProp() 
        {
            return _ctx.Categories
                .Include(p => p.Properties)
                .ToList();  
        }

    }

}


