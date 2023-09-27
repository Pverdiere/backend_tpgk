using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace backend_tpgk.Helper
{
    public class CustomJwtBearerHandler : JwtBearerHandler
    {
        private readonly HttpClient _httpClient;
        public CustomJwtBearerHandler(HttpClient httpClient, IOptionsMonitor<JwtBearerOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
            _httpClient = httpClient;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if(!Context.Request.Headers.TryGetValue("Authorization", out var authorizationHeaderValues))
            {
                return AuthenticateResult.Fail("Authorization header not found.");
            }

            var authorizationHeader = authorizationHeaderValues.FirstOrDefault();
            if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
            {
                return AuthenticateResult.Fail("Bearer token not found in Authorization header.");
            }

            string token = authorizationHeader["Bearer ".Length..].Trim();
            JwtSecurityTokenHandler handler = new();
            Byte[] key = Encoding.ASCII.GetBytes("qsgriopghe56seg4r44qerg46es6rsgrg4g");
            TokenValidationParameters validations = new(){
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true
            };

            ClaimsPrincipal claims =  handler.ValidateToken(token, validations, out var tokenSecure);

            return AuthenticateResult.Success(new AuthenticationTicket(claims,"CustomJwtBearer"));
        }
    }
}