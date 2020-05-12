using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.DataServerService;
using Services.DTO;
using Services.Tools;
using System.Threading.Tasks;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private readonly IDataServer dataServer;

        public CalculationController(IDataServer dataServer)
        {
            this.dataServer = dataServer;
        }

        [Route("multiplication")]
        [HttpPost]
        public async Task<ActionResult<string>> CalculateMatrix(Input input)
        {
            string matrixLeftStr = await dataServer.GetMatrixAsync(input.matrixLeft);
            string matrixRightStr = await dataServer.GetMatrixAsync(input.matrixRight);

            int[,] leftMatrix = JsonConvert.DeserializeObject<int[,]>(matrixLeftStr);
            int[,] rightMatrix = JsonConvert.DeserializeObject<int[,]>(matrixRightStr);

            if (leftMatrix == null || rightMatrix == null) { return BadRequest(); }

            try
            {
                int[,] multipliedMatrix = MatrixTool.MultiplyMatrix(leftMatrix, rightMatrix);
                int[,] resultMatrix = new int[input.rowEnd - input.rowBeg, input.colEnd - input.colBeg];

                uint row = 0;
                uint col = 0;
                for (uint i = input.rowBeg; i < input.rowEnd; i++)
                {
                    for (uint j = input.colBeg; j < input.colEnd; j++)
                    {
                        resultMatrix[row, col] = multipliedMatrix[i, j];
                        col++;
                    }
                    col = 0;
                    row++;
                }

                return Ok(JsonConvert.SerializeObject(resultMatrix));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
