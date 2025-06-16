namespace PokemonReviewApp.Models
{
    public class Category : BaseModel
    {
        public String Name { get; set; }
        public ICollection<PokemonCategory> PokemonCategories { get; set; }
    }
} 



