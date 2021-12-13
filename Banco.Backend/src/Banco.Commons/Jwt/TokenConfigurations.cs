namespace Banco.Commons.Jwt
{
    public class TokenConfigurations
    {
        public string ChaveSecreta { get; set; }
        public string App { get; set; }
        public string Emitente { get; set; }
        public int Dias { get; set; }
    }
}
