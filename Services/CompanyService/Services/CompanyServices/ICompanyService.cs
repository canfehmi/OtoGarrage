using CompanyService.Dtos.CompanyDto;
using CompanyService.Entities;

namespace CompanyService.Services.CompanyServices
{
    public interface ICompanyService
    {
        Task<List<CompanyResultDto>> GetAllCompanies();
        Task<CompanyResultDto> GetCompanyById(int id);
        Task<CompanyResultDto> AddCompany(CreateCompanyDto company);
        Task<bool> UpdateCompany(int id,UpdateCompanyDto company);
        Task<bool> DeleteCompany(int id);
        Task<bool> AddModelToCompany(int companyId, int modelId);
        Task<bool> RemoveModelFromCompany(int companyId, int modelId);
        Task<bool> AddSectorToCompany(int companyId, int sectorId);
        Task<bool> RemoveSectorFromCompany(int companyId, int sectorId);
    }
}
