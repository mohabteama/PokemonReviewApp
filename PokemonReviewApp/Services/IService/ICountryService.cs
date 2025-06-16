public interface ICountryService
{
    List<CountryDto> GetAllCountries();
    CountryDto GetCountryById(int id);
    CountryDto GetCountryOfOwner(int ownerId);
    bool CreateCountry(CountryDto countryDto);
    bool UpdateCountry(int id, CountryDto countryDto);
    bool DeleteCountry(int id);
}
