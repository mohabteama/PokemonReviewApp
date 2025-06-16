namespace PokemonReviewApp.Models
{
    public class Country : BaseModel
    {
        public String Name { get; set; }
        public ICollection<Owner> Owners { get; set; }
    }
}