using Banco.Application.Pessoas.Criar;
using Banco.Application.Pessoas.Listar;
using Banco.Application.Pessoas.Obter;
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
    public class PessoasController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly JwtHandler _jwtHandler;

        public PessoasController(IMediator mediator, JwtHandler jwtHandler)
        {
            _mediator = mediator;
            _jwtHandler = jwtHandler;
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(CriarPessoaResponse), StatusCodes.Status201Created)]
        public async Task<ActionResult<CriarPessoaResponse>> Salvar([FromBody] CriarPessoaRequest request)
        {
            request.Validar();

            var pessoa = await _mediator.Send(request);
            return pessoa == null ? pessoa : CreatedAtRoute("ObterPessoa", new { id = pessoa.Id }, pessoa);
        }

        [HttpGet("{Id}", Name = "ObterPessoa")]
        [ProducesResponseType(typeof(ObterPessoaResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<ObterPessoaResponse>> Obter([FromRoute] ObterPessoaRequest request)
        {
            request.Id = request.Id == 0 ? _jwtHandler.IdPessoa : request.Id;
            return await _mediator.Send(request);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ListarPessoaResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<ListarPessoaResponse>> Listar([FromRoute] ListarPessoaRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
