[Route("api/[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountryController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet]
    public IActionResult GetCountries()
    {
        var countries = _countryService.GetAllCountries();
        return Ok(countries);
    }

    [HttpGet("{countryId}")]
    public IActionResult GetCountry(int countryId)
    {
        var country = _countryService.GetCountryById(countryId);
        if (country == null) return NotFound();

        return Ok(country);
    }

    [HttpGet("owners/{ownerId}")]
    public IActionResult GetCountryOfAnOwner(int ownerId)
    {
        var country = _countryService.GetCountryOfOwner(ownerId);
        if (country == null) return NotFound();

        return Ok(country);
    }

    [HttpPost]
    public IActionResult CreateCountry([FromBody] CountryDto countryCreate)
    {
        if (countryCreate == null)
            return BadRequest();

        var result = _countryService.CreateCountry(countryCreate);
        if (!result)
            return StatusCode(422, "Country already exists or error occurred");

        return Ok("Successfully created");
    }

    [HttpPut("{countryId}")]
    public IActionResult UpdateCountry(int countryId, [FromBody] CountryDto updatedCountry)
    {
        if (updatedCountry == null || countryId != updatedCountry.Id)
            return BadRequest();

        var result = _countryService.UpdateCountry(countryId, updatedCountry);
        if (!result) return NotFound();

        return NoContent();
    }

    [HttpDelete("{countryId}")]
    public IActionResult DeleteCountry(int countryId)
    {
        var result = _countryService.DeleteCountry(countryId);
        if (!result) return NotFound();

        return NoContent();
    }
}
