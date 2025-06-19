using CompanyService.Dtos.SectorDto;
using CompanyService.Entities;

namespace CompanyService.Services.SectorServices
{
    public interface ISectorService
    {
        Task<List<ResultSectorDto>> GetAllSectorsAsync();
        Task<ResultSectorDto> GetSectorByIdAsync(int id);
        Task<bool> CreateSectorAsync(CreateSectorDto sector);
        Task<bool> UpdateSectorAsync(int id, UpdateSectorDto sector);
        Task<bool> DeleteSectorAsync(int id);
    }
}
