using CompanyService.Dtos.ModelDto;

namespace ModelService.Services.ModelService
{
    public interface IModelService
    {
        Task<List<ModelResultDto>> GetAllModels();
        Task<ModelResultDto> GetModelById(int id);
        Task<ModelResultDto> AddModel(CreateModelDto Model);
        Task<bool> UpdateModel(int id, UpdateModelDto Model);
        Task<bool> DeleteModel(int id);
    }
}
