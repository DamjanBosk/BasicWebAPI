using BasicWebAPI.Data;
using BasicWebAPI.Dtos;
using BasicWebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BasicWebAPI.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataContext _dataContext;
        public CompanyRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Company>> GetAllCompanies()
        {
            return await _dataContext.Companies.ToListAsync();
        }

        public async Task<Company?> CreateCompany(CreateUpdateCompanyRequest request)
        {
            if (request == null || request.Name.IsNullOrEmpty())
            {
                return null;
            }

            Company company = new Company();
            company.Name = request.Name;

            _dataContext.Companies.Add(company);
            await _dataContext.SaveChangesAsync();

            return company;
        }

        public async Task<Company?> UpdateCompany(int id, CreateUpdateCompanyRequest request)
        {
            var company = await _dataContext.Companies.FindAsync(id);
            if (company == null || request == null || request.Name.IsNullOrEmpty())
            {
                return null;
            }
            
            company.Name = request.Name;
            await _dataContext.SaveChangesAsync();

            return company;
        }

        public async Task<bool> DeleteCompany(int id)
        {
            var company = await _dataContext.Companies.FindAsync(id);
            if (company == null)
            {
                return false;
            }

            _dataContext.Companies.Remove(company);
            await _dataContext.SaveChangesAsync();

            return true;
        }
    }
}
