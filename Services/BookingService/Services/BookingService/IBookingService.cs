using BookingService.Dtos;

namespace BookingService.Services.BookingService
{
    public interface IBookingService
    {
        Task<List<ResultBookingDto>> GetAllBookings();
        Task<ResultBookingDto> GetBookingById(int id);
        Task<ResultBookingDto> AddBooking(CreateBookingDto dto);
        Task<bool> DeleteBooking(int id);
    }
}
