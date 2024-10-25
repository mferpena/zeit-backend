using CapaDeNegocio.Services;
using CapaDePresentacion.Dtos;
using CapaDeEntidad.Model;
using Microsoft.AspNetCore.Mvc;

namespace CapaDePresentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto signUpDto)
        {
            try
            {
                await _authService.SignUp(signUpDto.Username, signUpDto.Password, signUpDto.Email);

                var response = new SignUpResponse
                {
                    StatusCode = 201,
                    Message = "Usuario registrado correctamente"
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new FailReponse
                {
                    StatusCode = 500,
                    Message = "Ocurrió un error inesperado",
                    Stack = ex.Message
                };
                return StatusCode(500, errorResponse);
            }
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] SignInDto signInDto)
        {
            try
            {
                var token = await _authService.SignIn(signInDto.Username, signInDto.Password);

                if (token == null)
                {
                    var errorResponse = new Response
                    {
                        StatusCode = 401,
                        Message = "Credenciales inválidas"
                    };
                    return Unauthorized(errorResponse);
                }

                var response = new SignInResponse
                {
                    StatusCode = 200,
                    Message = "Inicio de sesión exitoso",
                    AccessToken = token
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new FailReponse
                {
                    StatusCode = 500,
                    Message = "Ocurrió un error inesperado",
                    Stack = ex.Message
                };
                return StatusCode(500, errorResponse);
            }
        }
    }
}
