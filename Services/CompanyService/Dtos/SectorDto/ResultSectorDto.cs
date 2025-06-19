using CompanyService.Entities;

namespace CompanyService.Dtos.SectorDto
{
    public class ResultSectorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public ICollection<Company>? Companies { get; set; } = new List<Company>();
    }
}
