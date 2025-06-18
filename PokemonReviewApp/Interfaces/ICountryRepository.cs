
namespace PokemonReviewApp.Interface
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersFromACountry(int countryId);
    }
}
