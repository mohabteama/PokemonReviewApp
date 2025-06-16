
namespace PokemonReviewApp.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(ApplicationDbContext context) : base(context) { }

        public Country GetCountryByOwner(int ownerId)
        {
            return _context.Owners
                .Where(o => o.Id == ownerId)
                .Select(o => o.Country)
                .FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromACountry(int countryId)
        {
            return _context.Owners
                .Where(o => o.Country.Id == countryId)
                .ToList();
        }
    }
}
