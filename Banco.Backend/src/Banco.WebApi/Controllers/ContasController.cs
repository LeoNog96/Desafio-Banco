using Banco.Application.Contas.AlterarLimiteSaque;
using Banco.Application.Contas.Criar;
using Banco.Application.Contas.Listar;
using Banco.Application.Contas.Obter;
using Banco.Application.Contas.ObterSaldo;
using Banco.Commons.Jwt;
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
    public class ContasController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly JwtHandler _jwtHandler;

        public ContasController(IMediator mediator, JwtHandler jwtHandler)
        {
            _mediator = mediator;
            _jwtHandler = jwtHandler;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CriarContaResponse), StatusCodes.Status201Created)]
        public async Task<ActionResult<CriarContaResponse>> Salvar([FromBody] CriarContaRequest request)
        {
            request.IdPessoa = request.IdPessoa == 0 ? _jwtHandler.IdPessoa : request.IdPessoa;
            request.Validar();

            var conta = await _mediator.Send(request);

            return conta == null ? conta : CreatedAtRoute("ObterConta", new { id = conta.Id }, conta);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Salvar([FromBody] AlterarLimiteSaqueRequest request)
        {
            request.Validar();

            await _mediator.Send(request);

            return NoContent();
        }

        [HttpGet("{Id}", Name = "ObterConta")]
        [ProducesResponseType(typeof(ObterContaResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<ObterContaResponse>> Obter([FromRoute] ObterContaRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("obter-saldo/{IdConta}", Name = "ObterSaldo")]
        [ProducesResponseType(typeof(ObterSaldoResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<ObterSaldoResponse>> Obter([FromRoute] ObterSaldoRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("listar-por-pessoa")]
        [ProducesResponseType(typeof(ObterContaResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<ListarContaResponse>> ListarPorPessoa([FromQuery] ListarContaRequest request)
        {
            request.IdPessoa = request.IdPessoa == null ? _jwtHandler.IdPessoa : request.IdPessoa;
            return await _mediator.Send(request);
        }
    }
}
