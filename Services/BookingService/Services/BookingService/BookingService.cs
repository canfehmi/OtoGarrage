using BookingService.Data;
using BookingService.Dtos;
using BookingService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly ApplicationDbContext _context;

        public BookingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ResultBookingDto> AddBooking(CreateBookingDto dto)
        {
            var booking = new Booking
            {
                BookingDate = dto.BookingDate,
                BookingTime = dto.BookingTime,
                Company = dto.Company,
                CreatedDate = DateTime.Now,
                IsActive = true,
                IsUrgent = dto.IsUrgent,
                IsWarranty = dto.IsWarranty,
                Name = dto.Name,
                Surname = dto.Surname
            };
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            var result = new ResultBookingDto
            {
                Id = booking.Id,
                BookingDate = booking.BookingDate,
                BookingTime = booking.BookingTime,
                Company = booking.Company,
                CreatedDate = booking.CreatedDate,
                IsActive = booking.IsActive,
                IsUrgent = booking.IsUrgent,
                IsWarranty = booking.IsWarranty,
                Name = booking.Name,
                Surname = booking.Surname
            };
            return Task.FromResult(result);
        }

        public Task<bool> DeleteBooking(int id)
        {
            var value = _context.Bookings.FirstOrDefault(x => x.Id == id);
            if (value == null)
            {
                return Task.FromResult(false);
            }
            _context.Bookings.Remove(value);
            _context.SaveChanges();
            return Task.FromResult(true);
        }

        public async Task<List<ResultBookingDto>> GetAllBookings()
        {
            return await _context.Bookings.Select(x => new ResultBookingDto
            {
                BookingTime = x.BookingTime,
                BookingDate = x.BookingDate,
                Company = x.Company,
                CreatedDate = x.CreatedDate,
                IsActive = x.IsActive,
                Id = x.Id,
                IsUrgent = x.IsUrgent,
                IsWarranty = x.IsWarranty,
                Name = x.Name,
                Surname = x.Surname
            }).ToListAsync();
        }

        public Task<ResultBookingDto> GetBookingById(int id)
        {
            var value = _context.Bookings.FirstOrDefault(x => x.Id == id);
            if (value == null)
            {
                return Task.FromResult<ResultBookingDto>(null!);
            }
            var result = new ResultBookingDto
            {
                Id = value.Id,
                BookingDate = value.BookingDate,
                BookingTime = value.BookingTime,
                Company = value.Company,
                CreatedDate = value.CreatedDate,
                IsActive = value.IsActive,
                IsUrgent = value.IsUrgent,
                IsWarranty = value.IsWarranty,
                Name = value.Name,
                Surname = value.Surname
            };
            return Task.FromResult(result);
        }
    }
}
