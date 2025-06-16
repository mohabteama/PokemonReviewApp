public class CountryService : ICountryService
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public CountryService(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }

    public List<CountryDto> GetAllCountries()
    {
        return _mapper.Map<List<CountryDto>>(_countryRepository.GetAll());
    }

    public CountryDto GetCountryById(int id)
    {
        if (!_countryRepository.Exists(id))
            return null;

        return _mapper.Map<CountryDto>(_countryRepository.GetById(id));
    }

    public CountryDto GetCountryOfOwner(int ownerId)
    {
        return _mapper.Map<CountryDto>(_countryRepository.GetCountryByOwner(ownerId));
    }

    public bool CreateCountry(CountryDto countryDto)
    {
        var exists = _countryRepository.GetAll()
            .Any(c => c.Name.Trim().ToUpper() == countryDto.Name.Trim().ToUpper());

        if (exists)
            return false;

        var country = _mapper.Map<Country>(countryDto);
        return _countryRepository.Create(country);
    }

    public bool UpdateCountry(int id, CountryDto countryDto)
    {
        if (id != countryDto.Id || !_countryRepository.Exists(id))
            return false;

        var country = _mapper.Map<Country>(countryDto);
        return _countryRepository.Update(country);
    }

    public bool DeleteCountry(int id)
    {
        if (!_countryRepository.Exists(id))
            return false;

        var country = _countryRepository.GetById(id);
        return _countryRepository.Delete(country);
    }
}
