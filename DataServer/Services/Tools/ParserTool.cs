using Services.DTO;
using System;
using System.Text.RegularExpressions;

namespace Services.Tools
{
    public static class ParserTool
    {
        public static MatrixProperties ParseId(string id)
        {
            try
            {
                id = id.Replace("M", "").Replace("m", "");
                id = Regex.Replace(id, @"\s+", "");
                string[] splited = id.Split(',');

                uint columns = Convert.ToUInt32(splited[1].ToString());
                uint rows = Convert.ToUInt32(splited[0].ToString());

                return new MatrixProperties(columns, rows, columns * rows);
            }
            catch
            {
                return null;
            }
        }
    }
}
