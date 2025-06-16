
namespace PokemonReviewApp.Services
{
    public class ReviewerService : IReviewerService
    {
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IMapper _mapper;

        public ReviewerService(IReviewerRepository reviewerRepository, IMapper mapper)
        {
            _reviewerRepository = reviewerRepository;
            _mapper = mapper;
        }

        public List<ReviewerDto> GetAll()
        {
            var reviewers = _reviewerRepository.GetAll();
            return _mapper.Map<List<ReviewerDto>>(reviewers);
        }

        public ReviewerDto? GetById(int id)
        {
            if (!_reviewerRepository.Exists(id))
                return null;

            var reviewer = _reviewerRepository.GetById(id);
            return _mapper.Map<ReviewerDto>(reviewer);
        }

        public List<ReviewDto> GetReviewsByReviewer(int reviewerId)
        {
            var reviews = _reviewerRepository.GetReviewsByReviewer(reviewerId);
            return _mapper.Map<List<ReviewDto>>(reviews);
        }

        public (bool IsSuccess, string? ErrorMessage) Create(ReviewerDto reviewerCreate)
        {
            if (_reviewerRepository.GetAll().Any(r =>
                r.LastName.Trim().ToUpper() == reviewerCreate.LastName.Trim().ToUpper()))
            {
                return (false, "Reviewer already exists");
            }

            var reviewer = _mapper.Map<Reviewer>(reviewerCreate);

            if (!_reviewerRepository.Create(reviewer))
                return (false, "Something went wrong while saving");

            return (true, null);
        }

        public (bool IsSuccess, string? ErrorMessage) Update(int id, ReviewerDto reviewerUpdate)
        {
            if (id != reviewerUpdate.Id || !_reviewerRepository.Exists(id))
                return (false, "Reviewer not found or invalid ID");

            var reviewer = _mapper.Map<Reviewer>(reviewerUpdate);

            if (!_reviewerRepository.Update(reviewer))
                return (false, "Something went wrong updating reviewer");

            return (true, null);
        }

        public (bool IsSuccess, string? ErrorMessage) Delete(int id)
        {
            if (!_reviewerRepository.Exists(id))
                return (false, "Reviewer not found");

            var reviewer = _reviewerRepository.GetById(id);

            if (!_reviewerRepository.Delete(reviewer))
                return (false, "Something went wrong deleting reviewer");

            return (true, null);
        }
    }
}
