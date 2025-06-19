using CompanyService.Entities;

namespace CompanyService.Dtos.SectorDto
{
    public class CreateSectorDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}
