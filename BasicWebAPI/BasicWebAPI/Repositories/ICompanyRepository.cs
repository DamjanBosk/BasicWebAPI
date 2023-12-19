using BasicWebAPI.Dtos;
using BasicWebAPI.Entities;

namespace BasicWebAPI.Repositories
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetAllCompanies();
        Task<Company?> CreateCompany(CreateUpdateCompanyRequest request);
        Task<Company?> UpdateCompany(int id, CreateUpdateCompanyRequest request);
        Task<bool> DeleteCompany(int id);
    }
}
