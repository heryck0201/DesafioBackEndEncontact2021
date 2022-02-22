using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBackendEnContact.Controllers.Models;
using TesteBackendEnContact.Core.Interface.ContactBook.Company;
using TesteBackendEnContact.Repository.Interface;

namespace TesteBackendEnContact.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly ICompanyRepository _companyRepository;
        public CompanyController(ILogger<CompanyController> logger)
        {
            _logger = logger;
        }

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpPost]
        public async Task<ActionResult<ICompany>> Post(SaveCompanyRequest company, [FromServices] ICompanyRepository companyRepository)
        {
            return Ok(await companyRepository.SaveAsync(company.ToCompany()));
        }

        [HttpDelete]
        public async Task<ActionResult<ICompany>> DeleteAsync(int id, [FromServices] ICompanyRepository companyRepository)
        {
            var company = await _companyRepository.GetAsync(id);
            if (company == null)
                return NotFound();
            await _companyRepository.DeleteAsync(company.Id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IEnumerable<ICompany>> Get([FromServices] ICompanyRepository companyRepository)
        {
            return await companyRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ICompany>> GetCompany(int id/*, [FromServices] ICompanyRepository companyRepository*/)
        {
            return await _companyRepository.Get();
        }
    }
}
