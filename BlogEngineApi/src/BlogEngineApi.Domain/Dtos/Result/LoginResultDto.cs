namespace BlogEngineApi.Domain.Dtos.Result
{
    public class LoginResultDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

        public LoginResultDto(string token, DateTime expiration)
        {
            Token = token;
            Expiration = expiration;
        }
    }
}