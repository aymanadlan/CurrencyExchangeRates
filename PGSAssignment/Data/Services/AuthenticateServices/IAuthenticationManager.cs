using PGSAssignment.JWTAuthenticationManager;

namespace PGSAssignment.Data.Services.AuthenticateServices
{
    public interface IAuthenticationManager
    {
        public string CreateToken(User user);
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        public string GetMyName();
        public RefreshToken GenerateRefreshToken();
        public void SetRefreshToken(HttpResponse response, RefreshToken newRefreshToken,User user);
    }
}
