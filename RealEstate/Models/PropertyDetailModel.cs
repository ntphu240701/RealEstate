namespace RealEstate.Models
{
    public class PropertyDetailModel
    {
        public Property Property { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();    

        public ICollection<Location> Locations { get; set; } = null!;
    }
}
