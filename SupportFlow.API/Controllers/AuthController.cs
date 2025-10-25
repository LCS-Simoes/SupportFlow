using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SupportFlow.Application.DTOs.SuporteDTOs;
using SupportFlow.Application.DTOs.UsuarioDTOs;
using SupportFlow.Application.UseCases.Suportes;
using SupportFlow.Application.UseCases.Usuarios;
using SupportFlow.Domain.Entities;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SupportFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AutenticacaoUseCase _autenticarUsuario;
        private readonly TicketUsuarioUseCase _ticket;
        private readonly IConfiguration _config;

        public AuthController(AutenticacaoUseCase autenticacao, IConfiguration config, TicketUsuarioUseCase ticketUser)
        {
            _autenticarUsuario = autenticacao;
            _config = config;
            _ticket = ticketUser;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] BuscarLoginRequest request)
        {
            var usuario = await _autenticarUsuario.ValidarLoginAsync(request.Username, request.Senha);
            if(usuario == null)
            {
                return Unauthorized(new { message = "Credenciais Inválidas" });
            }

            var expiracao = request.LembrarMe ? DateTime.UtcNow.AddDays(7) : DateTime.UtcNow.AddHours(2);

            var token = GerarJwtToken(usuario, usuario.Username, usuario.Perfil.ToString(), expiracao);

            return Ok(new
            {
                token,
                expiracao,
                usuario = new
                {
                    usuario.Id,
                    usuario.Nome,
                    usuario.Username,
                    usuario.Perfil,
                    usuario.Setor
                }
            });

        }

        [Authorize]
        [HttpGet("tickets")]
        public async Task<ActionResult<List<SuporteResponse>>> TicketUsuario()
        {
            var userIdClaim = User.FindFirst("id");
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int usuarioId))
            {
                return Unauthorized("ID de usuário não encontrado ou inválido no token.");
            }
            try
            { 
                var result = await _ticket.Handle(usuarioId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro interno ao processar sua solicitação de tickets.");
            }
        }

        //Adicionar no local correto posteriormente
        private string GerarJwtToken(Usuario usuario, string username, string perfil, DateTime expiracao)
        {
            var key = Environment.GetEnvironmentVariable("JWT_KEY") ?? _config["Jwt:Key"];
            var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? _config["Jwt:Issuer"];
            var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? _config["Jwt:Audience"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                 new Claim("id", usuario.Id.ToString()),
                 new Claim(ClaimTypes.Name, username),
                 new Claim(ClaimTypes.Role, perfil)
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expiracao,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
