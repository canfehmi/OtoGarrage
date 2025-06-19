using CompanyService.Entities;

namespace CompanyService.Dtos.ModelDto
{
    public class UpdateModelDto
    {
        public int Id { get; set; }
        public string ModelName { get; set; } = default!;
        public int CompanyId { get; set; }
    }
}
