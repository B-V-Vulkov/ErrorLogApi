namespace ErrorLogApi.Services
{
    using System;
    using System.Text;
    using System.Security.Claims;
    using System.IdentityModel.Tokens.Jwt;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;

    using GlobalConstants;
    using Services.Contracts;

    public class JwtService : IJwtService
    {
        private readonly SecuritySettings securitySettings;

        private readonly double liveTimeHours; 

        private readonly byte[] Key;

        public JwtService(IOptions<ApplicationSettings> options)
        {
            this.securitySettings = options.Value.Security;

            this.liveTimeHours = Double.Parse(this.securitySettings.JwtLiveTimeHours);
            this.Key = Encoding.UTF8.GetBytes(this.securitySettings.SecretKey);
        }

        public string GenerateJwt(string userName)
        {
            var key = new SymmetricSecurityKey(this.Key);
            var algorithm = SecurityAlgorithms.HmacSha256Signature;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(key, algorithm),
                Expires = DateTime.UtcNow.AddSeconds(30),
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, userName)
                })
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
