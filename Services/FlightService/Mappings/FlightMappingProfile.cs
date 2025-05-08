using AutoMapper;
using FlightService.Data;
using FlightService.DTOs;
using FlightService.Models;

namespace FlightService.Mappings
{
    public class FlightMappingProfile : Profile
    {
        public FlightMappingProfile()
        {
            CreateMap<Flight, FlightResponseDto>();
            CreateMap<CreateFlightDto, Flight>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));
        }
    }
}
