using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RentACarAPI.Application.Dtos;
using RentACarAPI.Application.Features.Mediator.Results.AppUserResults;

namespace RentACarAPI.Application.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseDto GenerateToken(GetCheckedAppUserQueryResult result)
        {
            var claims = new List<Claim>();
            if (!string.IsNullOrWhiteSpace(result.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role, result.Role));
            }

            claims.Add(new Claim(ClaimTypes.NameIdentifier, result.ID.ToString()));

            if (!string.IsNullOrWhiteSpace(result.Username))
            {
                claims.Add(new Claim("Username", result.Username));
            }

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));

            var signInCredentials = 
                new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: JwtTokenDefaults.ValidIssuer,
                audience: JwtTokenDefaults.ValidAuidience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expireDate,
                signingCredentials: signInCredentials);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return new TokenResponseDto(tokenHandler.WriteToken(token), expireDate);
        }
    }
}
