using CompanyService.Entities;

namespace CompanyService.Dtos.ModelDto
{
    public class ModelResultDto
    {
        public int Id { get; set; }
        public string ModelName { get; set; } = default!;
        public ICollection<Company>? Companies { get; set; } = new List<Company>();
    }
}
