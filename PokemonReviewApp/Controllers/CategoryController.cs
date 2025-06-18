[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult GetCategories()
    {
        var categories = _categoryService.GetAllCategories();
        return Ok(categories);
    }

    [HttpGet("{categoryId}")]
    public IActionResult GetCategory(int categoryId)
    {
        var category = _categoryService.GetCategoryById(categoryId);
        if (category == null) return NotFound();
        return Ok(category);
    }

    [HttpGet("pokemon/{categoryId}")]
    public IActionResult GetPokemonByCategoryId(int categoryId)
    {
        var pokemons = _categoryService.GetPokemonsByCategoryId(categoryId);
        if (pokemons == null) return NotFound();
        return Ok(pokemons);
    }

    [HttpPost]
    public IActionResult CreateCategory([FromBody] CategoryDto categoryDto)
    {
        if (categoryDto == null) return BadRequest();

        var result = _categoryService.CreateCategory(categoryDto);
        if (!result) return StatusCode(422, "Category already exists or error occurred");

        return StatusCode(201, "Successfully created");
    }

    //[HttpPut("{categoryId}")]
    //public IActionResult UpdateCategory(int categoryId, [FromBody] CategoryDto updatedCategory)
    //{
    //    if (updatedCategory == null || categoryId != updatedCategory.Id)
    //        return BadRequest();

    //    var result = _categoryService.UpdateCategory(categoryId, updatedCategory);
    //    if (!result) return NotFound();

    //    return NoContent();
    //}

    [HttpDelete("{categoryId}")]
    public IActionResult DeleteCategory(int categoryId)
    {
        var result = _categoryService.DeleteCategory(categoryId);
        if (!result) return NotFound();

        return NoContent();
    }
}
