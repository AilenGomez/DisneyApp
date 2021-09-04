using Business.Dtos;
using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDisney.Controllers
{
    [Route("auth/[controller]")]
    [ApiController]
    public class registerController : ControllerBase
    {
        private readonly ISeguridadService _seguridadService;
        private readonly IMailService _mailService;

        public registerController(ISeguridadService seguridadService, IMailService mailService)
        {
            _mailService = mailService;
            _seguridadService = seguridadService;
        }

        [HttpPost]
        public async Task<IActionResult> register (SeguridadDTO seguridadDTO)
        {
            var result = _seguridadService.PostSeguridad(seguridadDTO);
            await _mailService.SendEmailAsync(seguridadDTO.email,"Te registraste exitosamente!!", "<h1>Bienvenido a DisneyAPP</h1><p>Gracias por la oportunidad</p>");
            return Ok(result);
        }
    }
}
