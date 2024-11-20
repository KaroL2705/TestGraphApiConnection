using System.Threading.Tasks;
using Microsoft.Graph;

namespace TestGraphApiConnection.Interfaces
{
    public interface ISiteService
    {
        Task<string> GetDriveId(GraphServiceClient client, ConfigCredentials config);
    }
}