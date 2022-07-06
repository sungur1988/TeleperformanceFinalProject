using Application.Contracts.Identities;
using Application.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Services
{
    public class JwtTokenService : ITokenService
    {
        private readonly IUserService _userService;
        private readonly CustomJwtSettings _jwtSettings;

        public JwtTokenService(IUserService userService, IOptions<CustomJwtSettings> options)
        {
            _userService = userService;
            _jwtSettings = options.Value;
        }

        public async Task<string> CreateTokenAsync(AppUser appUser)
        {
            var userClaims = await _userService.GetClaims(appUser);
            var userRoles = await _userService.GetRoles(appUser);
            var roleClaims = new List<Claim>();

            for (int i = 0; i < userRoles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, userRoles[i]));
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, appUser.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, appUser.Email),
                new Claim(ClaimTypes.NameIdentifier,appUser.Id)
            }.Union(roleClaims).Union(userClaims);


            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes((double)_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return token;
        }
    }
}
