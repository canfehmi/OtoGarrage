using CompanyService.Data;
using CompanyService.Dtos.CompanyDto;
using CompanyService.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CompanyService.Services.CompanyServices
{
    public class CompanyService : ICompanyService
    {
        private readonly ApplicationDbContext _context;

        public CompanyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CompanyResultDto> AddCompany(CreateCompanyDto dto)
        {
            var company = new Company
            {
                Adress = dto.Adress,
                City = dto.City,
                Name = dto.Name,
                Phone = dto.Phone,
                SectorId = dto.SectorId,
                TypeOfCompany = dto.TypeOfCompany
            };
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return new CompanyResultDto
            {
                Id = company.Id,
                Adress = company.Adress,
                City = company.City,
                Name = company.Name,
                Phone = company.Phone,
                Sector = company.Sector,
                TypeOfCompany = company.TypeOfCompany,
                Models = company.Models
            };
        }


        public async Task<List<CompanyResultDto>> GetAllCompanies()
        {
            return await _context.Companies.Include(c=>c.Sector).Include(c => c.Models)
                .Select(x => new CompanyResultDto
                {
                    Id = x.Id,
                    Adress = x.Adress,
                    Models = x.Models,
                    City = x.City,
                    Name = x.Name,
                    Phone = x.Phone,
                    Sector = x.Sector,
                    TypeOfCompany = x.TypeOfCompany
                }).ToListAsync();
        }

        public async Task<CompanyResultDto> GetCompanyById(int id)
        {
            var company = await _context.Companies.Include(c => c.Sector).Include(c => c.Models)
                .FirstOrDefaultAsync(x=>x.Id==id);
            if (company == null) return null!;
            return new CompanyResultDto
            {
                Id = company.Id,
                Adress = company.Adress,
                Models = company.Models,
                City = company.City,
                Name = company.Name,
                Phone = company.Phone,
                Sector = company.Sector,
                TypeOfCompany = company.TypeOfCompany
            };
        }

        public Task<bool> UpdateCompany(int id, UpdateCompanyDto dto)
        {
            var company = _context.Companies
                .FirstOrDefault(x => x.Id == id);
            if (company == null)
            {
                return Task.FromResult(false);
            }
            company.Adress = dto.Adress;
            company.Models = dto.Models;
            company.City = dto.City;
            company.Name = dto.Name;
            company.Phone = dto.Phone;
            company.Sector = dto.Sector;
            company.TypeOfCompany = dto.TypeOfCompany;
            _context.Companies.Update(company);
            _context.SaveChanges();
            return Task.FromResult(true);
        }

        public Task<bool> DeleteCompany(int id)
        {
            var company = _context.Companies
                .FirstOrDefault(x => x.Id == id);
            if (company == null) return Task.FromResult(false);
            _context.Companies.Remove(company);
            _context.SaveChanges();
            return Task.FromResult(true);
        }

        public async Task<bool> AddModelToCompany(int companyId, int modelId)
        {
            var company = await _context.Companies.Include(c => c.Models)
                .FirstOrDefaultAsync(x => x.Id == companyId);
            if (company == null) return false;
            var model = await _context.Models.FirstOrDefaultAsync(x => x.Id == modelId);
            if (model == null) return false;
            company.Models.Add(model);
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveModelFromCompany(int companyId, int modelId)
        {
            var company = await _context.Companies.Include(c => c.Models)
                .FirstOrDefaultAsync(x => x.Id == companyId);
            if (company == null) return false;
            var model = await _context.Models.FirstOrDefaultAsync(x => x.Id == modelId);
            if (model == null) return false;
            company.Models = null;
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddSectorToCompany(int companyId, int sectorId)
        {
            var company = await _context.Companies.Include(c => c.Sector)
                .FirstOrDefaultAsync(x => x.Id == companyId);
            if (company == null) return false;
            var sector = await _context.Sectors.FirstOrDefaultAsync(x => x.Id == sectorId);
            if (sector == null) return false;
            company.Sector = sector;
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveSectorFromCompany(int companyId, int sectorId)
        {
            var company = await _context.Companies.Include(c => c.Sector)
                .FirstOrDefaultAsync(x => x.Id == companyId);
            if (company == null) return false;
            var sector = await _context.Sectors.FirstOrDefaultAsync(x => x.Id == sectorId);
            if (sector == null) return false;
            company.Sector = null;
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
