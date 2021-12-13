namespace Banco.Domain.Model
{
    public class Login
    {
        public Login()
        {

        }

        public Login(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public long Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public long IdPessoa { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
