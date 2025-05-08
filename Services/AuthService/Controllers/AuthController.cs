using AuthService.Interfaces;
using AuthService.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using AuthService.DTOs;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly JwtTokenGenerator _tokenGenerator;

        public AuthController(IAuthService authService, JwtTokenGenerator tokenGenerator)
        {
            _authService = authService;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Login eines Benutzers")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _authService.LoginAsync(request);
            if (user == null)
                return Unauthorized("Ungültige Anmeldedaten.");

            var token = _tokenGenerator.GenerateToken(user);
            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Registrierung eines Benutzers")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var success = await _authService.RegisterAsync(request);
            if (!success)
                return BadRequest("Registrierung fehlgeschlagen.");

            return Ok("Registrierung erfolgreich.");
        }

        [HttpGet]
        [Authorize]
        [SwaggerOperation(Summary = "Alle Benutzer abrufen")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _authService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize]
        [SwaggerOperation(Summary = "Benutzer nach ID abrufen")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _authService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound("Benutzer nicht gefunden.");

            return Ok(user);
        }

        [HttpPut("{id}")]
        [Authorize]
        [SwaggerOperation(Summary = "Benutzer aktualisieren")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserRequest request)
        {
            var success = await _authService.UpdateUserAsync(id, request);
            if (!success)
                return NotFound("Benutzer nicht gefunden.");

            return Ok("Benutzer aktualisiert.");
        }

        [HttpDelete("{id}")]
        [Authorize]
        [SwaggerOperation(Summary = "Benutzer löschen")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _authService.DeleteUserAsync(id);
            if (!success)
                return NotFound("Benutzer nicht gefunden.");

            return Ok("Benutzer gelöscht.");
        }
    }
}
