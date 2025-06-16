
namespace PokemonReviewApp.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public PokemonService(IPokemonRepository pokemonRepository, IReviewRepository reviewRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public List<PokemonDto> GetAll()
        {
            return _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetAll());
        }

        public PokemonDto? GetById(int pokeId)
        {
            if (!_pokemonRepository.Exists(pokeId))
                return null;

            return _mapper.Map<PokemonDto>(_pokemonRepository.GetById(pokeId));
        }

        public decimal GetRating(int pokeId)
        {
            return _pokemonRepository.GetPokemonRating(pokeId);
        }

        public bool CreatePokemon(int ownerId, int catId, PokemonDto pokemonCreate)
        {
            var existing = _pokemonRepository.GetPokemonTrimToUpper(pokemonCreate);
            if (existing != null)
                return false;

            var pokemon = _mapper.Map<Pokemon>(pokemonCreate);
            return _pokemonRepository.CreatePokemon(ownerId, catId, pokemon);
        }

        public bool UpdatePokemon(int pokeId, int ownerId, int catId, PokemonDto pokemonUpdate)
        {
            if (!_pokemonRepository.Exists(pokeId))
                return false;

            var pokemon = _mapper.Map<Pokemon>(pokemonUpdate);
            return _pokemonRepository.UpdatePokemon(ownerId, catId, pokemon);
        }

        public bool DeletePokemon(int pokeId)
        {
            if (!_pokemonRepository.Exists(pokeId))
                return false;

            var pokemon = _pokemonRepository.GetById(pokeId);
            var reviews = _reviewRepository.GetReviewsOfAPokemon(pokeId).ToList();

            _reviewRepository.DeleteReviews(reviews);
            return _pokemonRepository.Delete(pokemon);
        }
    }
}
