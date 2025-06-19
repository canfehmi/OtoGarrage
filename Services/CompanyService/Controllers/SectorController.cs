using CompanyService.Dtos.SectorDto;
using CompanyService.Services.SectorServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorController : ControllerBase
    {
        private readonly ISectorService _sectorService;

        public SectorController(ISectorService sectorService)
        {
            _sectorService = sectorService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSectors()
        {
            var sectors = await _sectorService.GetAllSectorsAsync();
            return Ok(sectors);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSectorById(int id)
        {
            var sector = await _sectorService.GetSectorByIdAsync(id);
            if (sector == null) return NotFound();
            return Ok(sector);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSector([FromBody] CreateSectorDto sector)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _sectorService.CreateSectorAsync(sector);
            if (!result) return BadRequest("Failed to create sector");
            return Ok("İşlem Başarılı");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSector(int id, [FromBody] UpdateSectorDto sector)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _sectorService.UpdateSectorAsync(id, sector);
            if (!result) return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSector(int id)
        {
            var result = await _sectorService.DeleteSectorAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
        [HttpGet("companies/{id}")]
        public async Task<IActionResult> GetCompaniesBySectorId(int id)
        {
            var sector = await _sectorService.GetSectorByIdAsync(id);
            if (sector == null) return NotFound();
            return Ok(sector.Companies);
        }
    }
}
