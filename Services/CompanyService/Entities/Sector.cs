namespace CompanyService.Entities
{
    public class Sector
    {
        public int Id { get; set; }
        public string Name { get; set; }=default!;
        public string? Description { get; set; }
        public ICollection<Company>? Companies { get; set; } = new List<Company>();
    }
}
