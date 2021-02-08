namespace Domain.Authentication
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public bool IsValid { get; set; }

        public AuthResponse(string token)
        {
            Token = token;
            IsValid = true;
        }

        public AuthResponse()
        {
            IsValid = false;
        }
    }
}
