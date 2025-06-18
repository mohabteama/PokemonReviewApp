public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public List<CategoryDto> GetAllCategories()
    {
        return _mapper.Map<List<CategoryDto>>(_categoryRepository.GetAll());
    }

    public CategoryDto GetCategoryById(int id)
    {
        if (!_categoryRepository.Exists(id))
            return null;

        return _mapper.Map<CategoryDto>(_categoryRepository.GetById(id));
    }

    public List<PokemonDto> GetPokemonsByCategoryId(int categoryId)
    {
        if (!_categoryRepository.Exists(categoryId))
            return null;

        return _mapper.Map<List<PokemonDto>>(_categoryRepository.GetPokemonByCategory(categoryId));
    }

    public bool CreateCategory(CategoryDto categoryDto)
    {
        var exists = _categoryRepository.GetAll()
            .Any(c => c.Name.Trim().ToUpper() == categoryDto.Name.Trim().ToUpper());

        if (exists)
            return false;

        var category = _mapper.Map<Category>(categoryDto);
        return _categoryRepository.Create(category);
    }

    public bool UpdateCategory(int id, CategoryDto categoryDto)
    {
       // if (id != categoryDto.Id || !_categoryRepository.Exists(id))
            return false;

        var category = _mapper.Map<Category>(categoryDto);
        return _categoryRepository.Update(category);
    }

    public bool DeleteCategory(int id)
    {
        if (!_categoryRepository.Exists(id))
            return false;

        var category = _categoryRepository.GetById(id);
        return _categoryRepository.Delete(category);
    }
}
