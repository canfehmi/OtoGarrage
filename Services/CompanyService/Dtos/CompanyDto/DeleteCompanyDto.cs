namespace CompanyService.Dtos.CompanyDto
{
    public class DeleteCompanyDto
    {
        public int Id { get; set; }

        public DeleteCompanyDto(int id)
        {
            Id = id;
        }
    }
}
