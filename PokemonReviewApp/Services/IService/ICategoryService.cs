public interface ICategoryService
{
    List<CategoryDto> GetAllCategories();
    CategoryDto GetCategoryById(int id);
    List<PokemonDto> GetPokemonsByCategoryId(int categoryId);
    bool CreateCategory(CategoryDto categoryDto);
    bool UpdateCategory(int id, CategoryDto categoryDto);
    bool DeleteCategory(int id);
}
