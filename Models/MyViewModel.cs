namespace RealEstate.Models
{
    public partial class MyViewModel
    {
        public ICollection<Category> Categories { get; set; } = null!;
        public ICollection<Location> Locations { get; set; } = null!;  

        public ICollection<Property> properties { get; set; } = null!;  

        public ICollection<Post> Posts { get; set; } = null!;   


    }
}
