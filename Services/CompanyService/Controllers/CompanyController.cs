using CompanyService.Dtos.CompanyDto;
using CompanyService.Services.CompanyServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            var companies = await _companyService.GetAllCompanies();
            return Ok(companies);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var company = await _companyService.GetCompanyById(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }
        [HttpPost]
        public async Task<IActionResult> AddCompany([FromBody] CreateCompanyDto company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdCompany = await _companyService.AddCompany(company);
            return CreatedAtAction(nameof(GetCompanyById), new { id = createdCompany.Id }, createdCompany);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCompany(int id, [FromBody] UpdateCompanyDto company)
        {
            var updatedCompany = _companyService.UpdateCompany(id, company);
            if (updatedCompany == null)
            {
                return NotFound();
            }
            return Ok(new { message = "Başarılı"});
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(int id)
        {
            var value = _companyService.DeleteCompany(id);
            if (value == null)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPost("{companyId}/models/{modelId}")]
        public async Task<IActionResult> AddModelToCompany(int companyId, int modelId)
        {
            var result = await _companyService.AddModelToCompany(companyId, modelId);
            if (!result)
            {
                return NotFound();
            }
            return Ok(new { message = "Model added to company successfully." });
        }
        [HttpDelete("{companyId}/models/{modelId}")]
        public async Task<IActionResult> RemoveModelFromCompany(int companyId, int modelId)
        {
            var result = await _companyService.RemoveModelFromCompany(companyId, modelId);
            if (!result)
            {
                return NotFound();
            }
            return Ok(new { message = "Model removed from company successfully." });
        }
        [HttpPost("{companyId}/sectors/{sectorId}")]
        public async Task<IActionResult> AddSectorToCompany(int companyId, int sectorId)
        {
            var result = await _companyService.AddSectorToCompany(companyId, sectorId);
            if (!result)
            {
                return NotFound();
            }
            return Ok(new { message = "Sector added to company successfully." });
        }
        [HttpDelete("{companyId}/sectors/{sectorId}")]
        public async Task<IActionResult> RemoveSectorFromCompany(int companyId, int sectorId)
        {
            var result = await _companyService.RemoveSectorFromCompany(companyId, sectorId);
            if (!result)
            {
                return NotFound();
            }
            return Ok(new { message = "Sector removed from company successfully." });
        }
    }
}
