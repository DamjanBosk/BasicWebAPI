using BasicWebAPI.Dtos;
using BasicWebAPI.Entities;

namespace BasicWebAPI.Repositories
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllCountries();
        Task<Country?> CreateCountry(CreateUpdateCountryRequest request);
        Task<Country?> UpdateCountry(int id, CreateUpdateCountryRequest request);
        Task<bool> DeleteCountry(int id);
    }
}
