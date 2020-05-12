using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataServerService
{
    public class DataServer : IDataServer
    {
        private readonly string dataServerUrl;

        public DataServer(string dataServerUrl)
        {
            this.dataServerUrl = dataServerUrl;
        }

        public async Task<string> GetMatrixAsync(string idOfMatrix)
        {
            string output = null;

            using (var client = new HttpClient())
            {
                using (var content = new StringContent(JsonConvert.SerializeObject(idOfMatrix), Encoding.UTF8, "application/json"))
                {
                    using (HttpResponseMessage message = await client.PostAsync(dataServerUrl, content))
                    {
                        if (message.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            output = await message.Content.ReadAsStringAsync();
                        }
                    }
                }
            }

            return output;
        }
    }
}
