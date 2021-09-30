using Microsoft.Extensions.Configuration;

namespace ApospReport.API.Authentication
{
    public interface IApiKeyAuthenticationValidator
    {
        bool IsValid(string apiKey);
    }

    internal class ApiKeyAuthenticationValidator : IApiKeyAuthenticationValidator
    {
        private readonly IConfiguration configuration;

        public ApiKeyAuthenticationValidator(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public bool IsValid(string apiKey)
        {
            return configuration["ApiKey"] == apiKey;
        }
    }
}
