using FlightService.DTOs;
using FlightService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using FlightService.Services;


namespace FlightService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Flug erstellen")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        public async Task<IActionResult> CreateFlight([FromBody] CreateFlightDto request)
        {
            var id = await _flightService.CreateFlightAsync(request);
            return Ok(ApiResponse<string>.SuccessResponse("Flug erfolgreich erstellt", "Erfolgreich"));
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Alle Flüge abrufen")]
        [ProducesResponseType(typeof(ApiResponse<List<FlightResponseDto>>), 200)]
        public async Task<IActionResult> GetAllFlights()
        {
            var flights = await _flightService.GetAllFlightsAsync();
            return Ok(ApiResponse<List<FlightResponseDto>>.SuccessResponse(flights, "Flüge erfolgreich abgerufen"));

        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Flug nach ID abrufen")]
        [ProducesResponseType(typeof(ApiResponse<FlightResponseDto>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetFlightById(string id)
        {
            var flight = await _flightService.GetFlightByIdAsync(id);
            if (flight == null)
                return NotFound(ApiResponse<string>.FailureResponse("Flug nicht gefunden"));

                return Ok(ApiResponse<FlightResponseDto>.SuccessResponse(flight, "Flug erfolgreich abgerufen"));

        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Flug aktualisieren")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateFlight(string id, [FromBody] UpdateFlightDto request)
        {
            var success = await _flightService.UpdateFlightAsync(id, request);
            if (!success)
                return NotFound(ApiResponse<string>.FailureResponse("Flug nicht gefunden"));

            return Ok(ApiResponse<string>.SuccessResponse(id, "Flug erfolgreich aktualisiert"));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Flug löschen")]
        [ProducesResponseType(typeof(ApiResponse<string>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteFlight(string id)
        {
            var success = await _flightService.DeleteFlightAsync(id);
            if (!success)
                return NotFound(ApiResponse<string>.FailureResponse("Flug nicht gefunden"));

            return Ok(ApiResponse<string>.SuccessResponse(id, "Flug erfolgreich gelöscht"));
        }

    }
}