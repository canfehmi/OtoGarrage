using CompanyService.Entities;

namespace CompanyService.Dtos.SectorDto
{
    public class UpdateSectorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}
