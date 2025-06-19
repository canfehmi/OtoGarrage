namespace CompanyService.Entities
{
    public class Model
    {
        public int Id { get; set; }
        public string ModelName { get; set; } = default!;
        public ICollection<Company>? Companies { get; set; } = new List<Company>();
    }
}
