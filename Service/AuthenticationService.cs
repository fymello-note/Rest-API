using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CompanyEmployees.Models;
using CompanyEmployees.Service.Contracts;
using Microsoft.IdentityModel.Tokens;

namespace CompanyEmployees.Service {
    public class AuthenticationService : IAuthenticationService {

        private readonly IConfiguration _configuration;

        public AuthenticationService(IConfiguration configuration) {
            this._configuration = configuration; 
        }

        public async Task<bool> ValidateUser(UserForAuthenticationDbo userForAuthenticationDbo) {
            if(userForAuthenticationDbo.UserName == "user1" && userForAuthenticationDbo.Password == "psww1") {
                return true;
            } else {
                return false;
            }
        }

        public async Task<string> CreateToken() {
            var signingCredentials = GetSigningCredential();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOption(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredential() {
            var key = "BuisinessSecretKeyBuisinessSecretKeyBuisinessSecretKeyBuisinessSecretKey";

            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims() {
            return new List<Claim>() {
                new Claim(ClaimTypes.Name, "user1"),
                new Claim(ClaimTypes.Role, "admin")
            };

            // claim.Add(new Claim(ClaimTypes.Role, "admin"));

            // return claim;
        }

        private JwtSecurityToken GenerateTokenOption(SigningCredentials signingCredentials, List<Claim> claims) {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken( 
                issuer: jwtSettings["ValidIssuer"],
                audience: jwtSettings["ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signingCredentials 
            );

            return tokenOptions;
        }

    }
}