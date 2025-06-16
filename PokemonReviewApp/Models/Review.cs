namespace PokemonReviewApp.Models
{
    public class Review : BaseModel
    {
        public String Title { get; set; }
        public String Text { get; set; }
        public int Rating { get; set; }
        public Reviewer Reviewer { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}