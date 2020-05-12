using Services.DTO;

namespace Services.Tools
{
    public static class MatrixTool
    {
        public static uint GetMatrixIndex(MatrixProperties matrixProperties)
        {
            return matrixProperties.Columns * matrixProperties.Size + matrixProperties.Rows;
        }
    }
}
