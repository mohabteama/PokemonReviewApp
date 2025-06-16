namespace PokemonReviewApp.Models
{
    public class Owner : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public String Gym { get; set; }
        public Country Country { get; set; }
        public ICollection<PokemonOwner> PokemonOwners { get; set; }
    }
}