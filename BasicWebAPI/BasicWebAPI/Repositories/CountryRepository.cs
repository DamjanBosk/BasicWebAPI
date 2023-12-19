using BasicWebAPI.Data;
using BasicWebAPI.Dtos;
using BasicWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BasicWebAPI.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _dataContext;

        public CountryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Country>> GetAllCountries()
        {
            return await _dataContext.Countries.ToListAsync();
        }

        public async Task<Country?> CreateCountry(CreateUpdateCountryRequest request)
        {
            if (request == null || request.Name.IsNullOrEmpty())
            {
                return null;
            }

            Country country = new Country();
            country.Name = request.Name;

            _dataContext.Countries.Add(country);
            await _dataContext.SaveChangesAsync();

            return country;
        }

        public async Task<Country?> UpdateCountry(int id, CreateUpdateCountryRequest request)
        {
            var country = await _dataContext.Countries.FindAsync(id);
            if (country == null || request == null || request.Name.IsNullOrEmpty())
            {
                return null;
            }

            country.Name = request.Name;
            await _dataContext.SaveChangesAsync();

            return country;
        }

        public async Task<bool> DeleteCountry(int id)
        {
            var country = await _dataContext.Countries.FindAsync(id);
            if (country == null)
            {
                return false;
            }

            _dataContext.Countries.Remove(country);
            await _dataContext.SaveChangesAsync();

            return true;
        }
    }
}
