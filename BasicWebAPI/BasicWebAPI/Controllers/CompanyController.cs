using BasicWebAPI.Dtos;
using BasicWebAPI.Entities;
using BasicWebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebAPI.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Company>>> GetAllCompanies()
        {
            var companies =  await _companyRepository.GetAllCompanies();
            return Ok(companies);
        }

        [HttpPost]
        public async Task<ActionResult<Company>> CreateCompany(CreateUpdateCompanyRequest request)
        {
            var company = await _companyRepository.CreateCompany(request);
            if (company == null)
            {
                return BadRequest();
            }
            return Ok(company);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Company>> UpdateCompany(int id, CreateUpdateCompanyRequest request)
        {
            var company = await _companyRepository.UpdateCompany(id, request);
            if (company == null)
            {
                return BadRequest();
            }
            return Ok(company);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            var result = await _companyRepository.DeleteCompany(id);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
