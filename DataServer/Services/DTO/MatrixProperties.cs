namespace Services.DTO
{
    public class MatrixProperties
    {
        public uint Columns { get; set; }
        public uint Rows { get; set; }
        public uint Size { get; set; }

        public MatrixProperties(uint columns, uint rows, uint size)
        {
            this.Columns = columns;
            this.Rows = rows;
            this.Size = size;
        }
    }
}
