using System.IO;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using CreateUploadSessionPostRequestBody = Microsoft.Graph.Drives.Item.Items.Item.CreateUploadSession.CreateUploadSessionPostRequestBody;
using File = System.IO.File;

namespace TestGraphApiConnection
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var configCredentials = new ConfigCredentials
            {
                ClientId = "4b5c957b-8ca9-4059-b57d-8921d4633d53",
                ClientSecret = "rE78Q~PhFxD28T-3EtOaGbvnhOiARdSSwLQbAbI1",
                TenantId = "96953412-a65c-4fe8-9e12-82a558d74f58",
                TenantName = "astroidpsa",
                DocumentLibrary = "Scans",
                SiteName = "FocusPrintKomunikacja"
            };
            
            var _clientService = new GetClientService();
            var client = _clientService.GetClient(configCredentials); 
            
            var _siteService = new SiteService();
            var driveId = await _siteService.GetDriveId(client, configCredentials);

            string filePath = @"F:\LoremIpsum.docx";
            
            if (driveId == null)
            {
                return;
            }
            else
            {
                await UploadFile(client,filePath,driveId);
            }
            
        }

        static async Task UploadFile(GraphServiceClient client, string filePath, string driveId)
        {
            var requestBody = new CreateUploadSessionPostRequestBody();
            string fileName = Path.GetFileName(filePath);
            
            var response = await client.Drives[driveId].Items["root"].ItemWithPath(fileName).CreateUploadSession.PostAsync(requestBody);
            
            var largeUploadFile = new LargeFileUploadTask<DriveItem>(response, File.OpenRead(filePath));
            var finalResponse = await largeUploadFile.UploadAsync();
        }
    }
}