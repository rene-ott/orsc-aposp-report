using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ApospReport.API.Authentication
{
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiKeyAuthenticationOptions>
    {
        private readonly IApiKeyAuthenticationValidator apiKeyAuthenticationValidator;

        public ApiKeyAuthenticationHandler(
            IOptionsMonitor<ApiKeyAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IApiKeyAuthenticationValidator apiKeyAuthenticationValidator)
            : base(options, logger, encoder, clock)
        {
            this.apiKeyAuthenticationValidator = apiKeyAuthenticationValidator;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string apiKey = Request.Headers["X-API-KEY"];
            if (string.IsNullOrEmpty(apiKey))
                return Task.FromResult(AuthenticateResult.Fail("Unauthorized"));

            if (!apiKeyAuthenticationValidator.IsValid(apiKey))
                return Task.FromResult(AuthenticateResult.Fail("Unauthorized"));

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, "APP")
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new GenericPrincipal(identity, null);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
