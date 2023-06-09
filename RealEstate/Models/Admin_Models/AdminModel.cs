namespace RealEstate.Models.Admin_Models
{
    public class AdminModel
    {
        public List<Post> MyPost { get; set; }
        public List<Property> MyProp { get; set; }
        public ICollection<Category> Categories { get; set; } = null!;
        public ICollection<Location> Locations { get; set; } = null!;

        public ICollection<Property> properties { get; set; } = null!;

        public ICollection<Post> Posts { get; set; } = null!;
    }
}
