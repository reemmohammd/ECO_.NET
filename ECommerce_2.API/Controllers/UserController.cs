using ECommerce_2.BL.Dtos.User;
using ECommerce_2.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;

namespace ECommerce_2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IConfiguration _configuration;
        private readonly UserManager<User2> _userManager;

        public UserController(IConfiguration configuration,
            UserManager<User2> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        #region Register

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            var user = new User2
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors); // 400, Errors
            }
            //general information 
            var claims = new List<Claim>
            {
               new (ClaimTypes.NameIdentifier, user.Id.ToString()),
               new (ClaimTypes.Name, user.UserName),
               new (ClaimTypes.Email, user.Email),

             };
            await _userManager.AddClaimsAsync(user, claims);

            return NoContent();
        }

        #endregion


        #region Login

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
            {
                return Unauthorized(); // 401
            }

            bool isAuthenticated = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!isAuthenticated)
            {
                return Unauthorized(); // 401
            }

            var userClaims = await _userManager.GetClaimsAsync(user);

            return GenerateToken(userClaims);
        }

        #endregion

        #region Helpers

        private ActionResult<TokenDto> GenerateToken(IEnumerable<Claim> userClaims)
        {   ///1-secret key

            ///get secret key  value
            var keyFromConfig = _configuration.GetValue<string>(Constant.AppSettings.SecretKey)!;
            ///secret key to byte
            var keyInBytes = Encoding.ASCII.GetBytes(keyFromConfig);
            ///byte to SymmetricSecurityKey
            var key = new SymmetricSecurityKey(keyInBytes);
            //////2- SymmetricSecurityKey+ hashing algorithm
            var signingCredentials = new SigningCredentials(key,
                SecurityAlgorithms.HmacSha256Signature);

            var expiryDateTime = DateTime.Now.AddDays(5);
            ///to genetate token  
            var jwt = new JwtSecurityToken(
                claims: userClaims,
                expires: expiryDateTime,
                signingCredentials: signingCredentials
                );

            var jwtAsString = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new TokenDto(jwtAsString, expiryDateTime);
        }

        #endregion

    }
}
