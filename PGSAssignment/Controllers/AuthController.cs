using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PGSAssignment.Data.Services.AuthenticateServices;
using PGSAssignment.JWTAuthenticationManager;


namespace PGSAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private static User user = new();
        private readonly IAuthenticationManager _authenticationManager;

        public AuthController(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            _authenticationManager.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.UserName = request.UserName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return Ok(user.UserName);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            if (user.UserName != request.UserName)
            {
                return BadRequest("User not found.");
            }
            if (!_authenticationManager.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            var token = _authenticationManager.CreateToken(user);
            var refreshToken = _authenticationManager.GenerateRefreshToken();
            _authenticationManager.SetRefreshToken(Response, refreshToken, user);

            return Ok(token);
        }

        [HttpGet, Authorize]
        public ActionResult<string> GetMe()
        {
            var userName = _authenticationManager.GetMyName();

            return Ok(userName);
        }

        [HttpPost("RefreshToken")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            if (!user.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid refresh token.");
            }
            else if(user.TokenExpires <DateTime.Now)
            {
                return Unauthorized("Token Expired");
            }

            var token = _authenticationManager.CreateToken(user);
            var newRefreshToken = _authenticationManager.GenerateRefreshToken();
            _authenticationManager.SetRefreshToken(Response,newRefreshToken,user);

            return Ok(token);
        }
    }
}