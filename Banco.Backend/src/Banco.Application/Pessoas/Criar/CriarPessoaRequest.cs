using Banco.Application.Base;
using MediatR;
using System;

namespace Banco.Application.Pessoas.Criar
{
    public class CriarPessoaRequest : ValidadorBase, IRequest<CriarPessoaResponse>
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public void Validar()
        {
            Valida(this, new CriarPessoaValidator());
        }
    }
}
