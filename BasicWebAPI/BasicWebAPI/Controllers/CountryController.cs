using BasicWebAPI.Dtos;
using BasicWebAPI.Entities;
using BasicWebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebAPI.Controllers
{
    [Route("api/countries")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Country>>> GetAllCoutries()
        {
            var countries = await _countryRepository.GetAllCountries();
            return Ok(countries);
        }

        [HttpPost]
        public async Task<ActionResult<Country>> CreateCountry(CreateUpdateCountryRequest request)
        {
            var country = await _countryRepository.CreateCountry(request);
            if (country == null)
            {
                return BadRequest();
            }
            return Ok(country);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Country>> UpdateCountry(int id, CreateUpdateCountryRequest request)
        {
            var country = await _countryRepository.UpdateCountry(id, request);
            if (country == null)
            {
                return BadRequest();
            }
            return Ok(country);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCountry(int id)
        {
            var result = await _countryRepository.DeleteCountry(id);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
