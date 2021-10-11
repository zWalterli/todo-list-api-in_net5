namespace VUTTR.Domain.ViewModels
{
    public class TokenViewModel
    {
        public TokenViewModel(bool authenticated, string created, string expiration, string accessToken, string refreshToken)
        {
            Authenticated = authenticated;
            Created = created;
            Expiration = expiration;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
        public TokenViewModel(bool authenticated, string created, string expiration, string accessToken, string refreshToken, UserViewModel userDto)
        {
            Authenticated = authenticated;
            Created = created;
            Expiration = expiration;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            User = userDto;
        }
        public TokenViewModel() { }

        public bool Authenticated { get; set; }
        public string Created { get; set; }
        public string Expiration { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public virtual UserViewModel User { get; set; }
    }
}