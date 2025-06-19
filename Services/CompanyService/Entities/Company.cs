namespace CompanyService.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? City { get; set; }
        public string? Adress { get; set; }
        public string? TypeOfCompany { get; set; }
        public int? SectorId { get; set; }
        public Sector? Sector { get; set; }
        public string? Phone { get; set; }
        public ICollection<Model>? Models { get; set; }
    }
}
