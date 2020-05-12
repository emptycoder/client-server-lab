using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Tools;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [Route("get")]
        [HttpPost]
        public ActionResult<int[,]> GetMatrix([FromBody] string idOfMatrix)
        {
            var matrixProperties = ParserTool.ParseId(idOfMatrix);
            if (matrixProperties == null) { return BadRequest(); }

            uint matrixIndex = MatrixTool.GetMatrixIndex(matrixProperties);
            int [,] matrix = new int[matrixProperties.Rows, matrixProperties.Columns];
            for (int i = 0; i < matrixProperties.Rows; i++)
            {
                for (int j = 0; j < matrixProperties.Columns; j++)
                {
                    matrix[i, j] = (int) Math.Floor((Math.Cos(i / 15) + Math.Sin(j / matrixIndex)) * 10);
                }
            }

            return Ok(JsonConvert.SerializeObject(matrix));
        }
    }
}
