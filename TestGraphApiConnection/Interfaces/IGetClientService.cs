using System.Threading;
using System.Threading.Tasks;
using Microsoft.Graph;

namespace TestGraphApiConnection.Interfaces
{
    public interface IGetClientService
    {
        GraphServiceClient GetClient(ConfigCredentials configCredentials);
    }
}