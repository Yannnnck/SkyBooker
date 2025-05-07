using AutoMapper;
using FlightService.DTOs;
using FlightService.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FlightService.Mappings
{
    public class FlightMappingProfile : Profile
    {
        public FlightMappingProfile()
        {
            CreateMap<CreateFlightDto, Flight>();
            CreateMap<Flight, FlightResponseDto>();
        }
    }
}
