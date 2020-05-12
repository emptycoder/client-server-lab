using System.Threading.Tasks;

namespace Services.DataServerService
{
    public interface IDataServer
    {
        Task<string> GetMatrixAsync(string idOfMatrix);
    }
}
