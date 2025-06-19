using CompanyService.Entities;

namespace CompanyService.Dtos.CompanyDto
{
    public class CreateCompanyDto
    {
        public string Name { get; set; } = default!;
        public string? City { get; set; }
        public string? Adress { get; set; }
        public string? TypeOfCompany { get; set; }
        public int? SectorId { get; set; }
        public string? Phone { get; set; }
    }
}
