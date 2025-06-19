using CompanyService.Dtos.ModelDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelService.Services.ModelService;

namespace CompanyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModelService _modelService;
        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllModels()
        {
            var models = await _modelService.GetAllModels();
            return Ok(models);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetModelById(int id)
        {
            var model = await _modelService.GetModelById(id);
            if (model == null) return NotFound();
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddModel([FromBody] CreateModelDto model)
        {
            var createdModel = await _modelService.AddModel(model);
            return CreatedAtAction(nameof(GetModelById), new { id = createdModel.Id }, createdModel);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModel(int id, [FromBody] UpdateModelDto model)
        {
            var result = await _modelService.UpdateModel(id, model);
            if (!result) return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModel(int id)
        {
            var result = await _modelService.DeleteModel(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
