using CompanyService.Data;
using CompanyService.Dtos.ModelDto;
using CompanyService.Entities;
using Microsoft.EntityFrameworkCore;
using ModelService.Services.ModelService;

namespace CompanyService.Services.ModelService
{
    public class ModelService : IModelService
    {
        private readonly ApplicationDbContext _context;

        public ModelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ModelResultDto> AddModel(CreateModelDto Model)
        {
            var model = new Model
            {
                ModelName = Model.ModelName
            };
            _context.Models.Add(model);
            await _context.SaveChangesAsync();
            return new ModelResultDto
            {
                Id = model.Id,
                ModelName = model.ModelName,
                Companies = model.Companies
            };
        }

        public Task<bool> DeleteModel(int id)
        {
            var model = _context.Models.Find(id);
            if (model == null) return Task.FromResult(false);
            _context.Models.Remove(model);
            _context.SaveChanges();
            return Task.FromResult(true);
        }

        public async Task<List<ModelResultDto>> GetAllModels()
        {
            return await _context.Models.Include(x => x.Companies)
                .Select(x => new ModelResultDto
                {
                    Id = x.Id,
                    ModelName = x.ModelName,
                    Companies = x.Companies
                }).ToListAsync();
        }

        public async Task<ModelResultDto> GetModelById(int id)
        {
            var model = await _context.Models.Include(x => x.Companies)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (model == null) return null!;
            return new ModelResultDto
            {
                Id = model.Id,
                ModelName = model.ModelName,
                Companies = model.Companies
            };
        }

        public Task<bool> UpdateModel(int id, UpdateModelDto Model)
        {
            var model = _context.Models.Find(id);
            if (model == null) return Task.FromResult(false);
            model.ModelName = Model.ModelName;
            var company = _context.Companies
                .FirstOrDefault(x => x.Id == Model.CompanyId);
            if (company != null)
            {
                model.Companies.Add(company);
            }
            _context.Models.Update(model);
            _context.SaveChanges();
            return Task.FromResult(true);
        }
    }
}
