namespace BookingService.Dtos
{
    public class ResultBookingDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public string Company { get; set; } = default!;
        public DateTime BookingDate { get; set; }
        public DateTime BookingTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsUrgent { get; set; } = false;
        public bool IsWarranty { get; set; } = false;
    }
}
