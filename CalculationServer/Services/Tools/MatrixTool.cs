namespace Services.Tools
{
    public static class MatrixTool
    {
        public static int[,] MultiplyMatrix(int[,] leftMatrix, int[,] rightMatrix)
        {
            int matrixLeftColumns = leftMatrix.GetLength(1);

            int resultMatrixRows = leftMatrix.GetLength(0);
            int resultMatrixColumns = rightMatrix.GetLength(1);

            int[,] resultMatrix = new int[resultMatrixRows, resultMatrixColumns];

            for (int i = 0; i < resultMatrixRows; i++)
            {
                for (int j = 0; j < resultMatrixColumns; j++)
                {
                    resultMatrix[i, j] = 0;
                    for (int k = 0; k < matrixLeftColumns; k++)
                    {
                        resultMatrix[i, j] = resultMatrix[i, j] + leftMatrix[i, k] * rightMatrix[k, j];
                    }
                }
            }

            return resultMatrix;
        }
    }
}
