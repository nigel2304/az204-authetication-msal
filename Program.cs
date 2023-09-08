using System.Threading.Tasks;
using Microsoft.Identity.Client;


namespace az204_auth
{
    class Program
    {
        private const string _clientId = "f53cfbdf-e521-466a-8023-4e8435c01507";
        private const string _tenantId = "2f0bfa6b-57c1-440c-8d11-30da125cd8a3";

        public static async Task Main(string[] args)
        {
            var app = PublicClientApplicationBuilder
                .Create(_clientId)
                .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
                .WithRedirectUri("http://localhost")
                .Build(); 
            string[] scopes = { "user.read" };
            AuthenticationResult result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

            Console.WriteLine($"Token:\t{result.AccessToken}");
        }
    }
}
