public interface IOwnerService
{
    List<OwnerDto> GetAllOwners();
    OwnerDto GetOwnerById(int ownerId);
    List<PokemonDto> GetPokemonByOwner(int ownerId);
    bool CreateOwner(int countryId, OwnerDto ownerDto);
    bool UpdateOwner(int ownerId, OwnerDto ownerDto);
    bool DeleteOwner(int ownerId);
}
