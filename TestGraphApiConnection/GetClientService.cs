using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using TestGraphApiConnection.Interfaces;

namespace TestGraphApiConnection
{
    public class GetClientService : IGetClientService
    {
        public GraphServiceClient GetClient(ConfigCredentials configCredentials)
        {
            var scopes = new[] { "https://graph.microsoft.com/.default" };
            
            var options = new ClientSecretCredentialOptions
            {
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
            };
            
            var clientSecretCredential = new ClientSecretCredential(
                configCredentials.TenantId, configCredentials.ClientId, configCredentials.ClientSecret, options);

            var graphClient = new GraphServiceClient(clientSecretCredential, scopes);
            
            return graphClient;
        }
    }
}