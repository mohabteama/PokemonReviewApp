public class OwnerService : IOwnerService
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public OwnerService(IOwnerRepository ownerRepository, ICountryRepository countryRepository, IMapper mapper)
    {
        _ownerRepository = ownerRepository;
        _countryRepository = countryRepository;
        _mapper = mapper;
    }

    public List<OwnerDto> GetAllOwners()
    {
        return _mapper.Map<List<OwnerDto>>(_ownerRepository.GetAll());
    }

    public OwnerDto GetOwnerById(int ownerId)
    {
        if (!_ownerRepository.Exists(ownerId))
            return null;

        return _mapper.Map<OwnerDto>(_ownerRepository.GetById(ownerId));
    }

    public List<PokemonDto> GetPokemonByOwner(int ownerId)
    {
        if (!_ownerRepository.Exists(ownerId))
            return null;

        return _mapper.Map<List<PokemonDto>>(_ownerRepository.GetPokemonByOwner(ownerId));
    }

    public bool CreateOwner(int countryId, OwnerDto ownerDto)
    {
        var exists = _ownerRepository.GetAll()
            .Any(o => o.LastName.Trim().ToUpper() == ownerDto.LastName.Trim().ToUpper());

        if (exists)
            return false;

        var owner = _mapper.Map<Owner>(ownerDto);
        owner.Country = _countryRepository.GetById(countryId);

        return _ownerRepository.Create(owner);
    }

    public bool UpdateOwner(int ownerId, OwnerDto ownerDto)
    {
        if (ownerId != ownerDto.Id || !_ownerRepository.Exists(ownerId))
            return false;

        var owner = _mapper.Map<Owner>(ownerDto);
        return _ownerRepository.Update(owner);
    }

    public bool DeleteOwner(int ownerId)
    {
        if (!_ownerRepository.Exists(ownerId))
            return false;

        var owner = _ownerRepository.GetById(ownerId);
        return _ownerRepository.Delete(owner);
    }
}
