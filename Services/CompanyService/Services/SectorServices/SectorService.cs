using CompanyService.Data;
using CompanyService.Dtos.SectorDto;
using CompanyService.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyService.Services.SectorServices
{
    public class SectorService : ISectorService
    {
        private readonly ApplicationDbContext _context;

        public SectorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateSectorAsync(CreateSectorDto sector)
        {
            var newSector = new Sector
            {
                Name = sector.Name,
                Description = sector.Description
            };
            _context.Sectors.Add(newSector);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSectorAsync(int id)
        {
            var value = await _context.Sectors.FindAsync(id);
            if (value == null) return false;
            _context.Sectors.Remove(value);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ResultSectorDto>> GetAllSectorsAsync()
        {
            return await _context.Sectors.Include(x=> x.Companies)
                .Select(x => new ResultSectorDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Companies = x.Companies
                }).ToListAsync();
        }

        public async Task<ResultSectorDto> GetSectorByIdAsync(int id)
        {
            var value = await _context.Sectors.Include(x => x.Companies)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (value == null) return null!;
            return new ResultSectorDto
            {
                Id = value.Id,
                Name = value.Name,
                Description = value.Description,
                Companies = value.Companies
            };
        }

        public async Task<bool> UpdateSectorAsync(int id, UpdateSectorDto sector)
        {
            var value = await _context.Sectors.FindAsync(id);
            if (value == null) return false;
            value.Name = sector.Name;
            value.Description = sector.Description;
            _context.Sectors.Update(value);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
