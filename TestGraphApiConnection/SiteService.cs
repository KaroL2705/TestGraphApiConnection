using System.Linq;
using System.Threading.Tasks;
using Microsoft.Graph;
using TestGraphApiConnection.Interfaces;

namespace TestGraphApiConnection
{
    public class SiteService: ISiteService
    {
        public async Task<string> GetDriveId(GraphServiceClient client, ConfigCredentials config)
        {
            // var response = await client.Sites[ config.TenantName +  "-my.sharepoint.com:/my:" ].Drives.GetAsync();
            var response = await client.Sites[ config.TenantName +  ".sharepoint.com:/sites/" + config.SiteName + ":" ].Drives.GetAsync();

            var driveId = response.Value.FirstOrDefault(x => x.Name == config.DocumentLibrary)?.Id;

            return driveId;
        }
    }
}