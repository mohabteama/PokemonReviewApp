
namespace PokemonReviewApp.Interface
{
    public interface ICountryRepository : IRepository<Country>
    {
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersFromACountry(int countryId);
    }
}
