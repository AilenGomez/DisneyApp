using Business.Interfaces;
using Infraestructura.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace AppDisney.Controllers
{
    [Route("auth/[controller]")]
    [ApiController]
    public class loginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISeguridadService _seguridadService;

        public loginController(IConfiguration configuration, ISeguridadService seguridadService)
        {
            _configuration = configuration;
            _seguridadService = seguridadService;
        }
        [HttpPost]
        public async Task<IActionResult> Autenticacion(UserLogin login)
        {
            var validacion = await IsValidUser(login);
            if (validacion.Item1)
            {
                var token = GenerateToken(validacion.Item2);
                return Ok(new { token });
            }
            return NotFound();
        }
        private async Task<(bool,Seguridad)> IsValidUser(UserLogin login)
        {
            var user = await _seguridadService.GetLoginByCredentials(login);
            return (user != null, user);
        }

        private string GenerateToken(Seguridad seguridad)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecreteKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, seguridad.UserName),
                new Claim("User", seguridad.User),
            };

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(10)
            );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
        

    }

