using AutoMapper;
using BookingService.DTOs;
using BookingService.Models; 

namespace BookingService.Mappings
{
    public class BookingMappingProfile : Profile
    {
        public BookingMappingProfile()
        {
            CreateMap<CreateBookingRequest, Booking>();
            CreateMap<Booking, BookingResponse>();
        }
    }
}
