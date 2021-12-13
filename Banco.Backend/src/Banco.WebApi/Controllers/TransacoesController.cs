using Banco.Application.Transacoes.Deposito;
using Banco.Application.Transacoes.Extrato;
using Banco.Application.Transacoes.Saque;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Banco.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TransacoesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransacoesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("deposito")]
        [ProducesResponseType(typeof(DepositoResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<DepositoResponse>> Deposito([FromBody] DepositoRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost("saque")]
        [ProducesResponseType(typeof(SaqueResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<SaqueResponse>> Saque([FromBody] SaqueRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("extrato")]
        [ProducesResponseType(typeof(ExtratoResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<ExtratoResponse>> Saque([FromQuery] ExtratoRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
