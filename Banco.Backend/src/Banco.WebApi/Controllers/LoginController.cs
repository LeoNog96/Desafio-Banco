using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banco.Application.Logins.Autenticar;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Banco.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("autenticar")]
        [ProducesResponseType(typeof(AutenticarResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<AutenticarResponse>> Save([FromBody] AutenticarRequest request)
        {
            request.Validar();

            return await _mediator.Send(request);
        }
    }
}
