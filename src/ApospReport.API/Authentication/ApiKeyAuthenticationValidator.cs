using Microsoft.Extensions.Configuration;

namespace ApospReport.API.Authentication
{
    public interface IApiKeyValidator
    {
        bool IsValid(string apiKey);
    }

    internal class ApiKeyValidator : IApiKeyValidator
    {
        private readonly IConfiguration configuration;

        public ApiKeyValidator(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public bool IsValid(string apiKey)
        {
            return configuration["ApiKey"] == apiKey;
        }
    }
}
