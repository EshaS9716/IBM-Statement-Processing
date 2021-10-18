using System.Data;
using System.IO;
using System.Text;

namespace IBM_Statement_Processing
{
    public class CreateCsvOutput : GatherExcel
    {
        public static void DataToSql(DataTable dt, string csvFileName)
        {
            for (int ix = 0; ix < dt.Rows.Count; ix++)
            {
                StringBuilder iCsv = new StringBuilder();

                for (int jx = 0; jx < dt.Columns.Count; jx++)
                {
                    if (jx == 9 || jx == 11)
                    {
                        double lv2X = (double)dt.Rows[ix].ItemArray[jx];
                        iCsv.Append(lv2X);
                    }
                    else
                    {
                        string lv2 = "\"" + dt.Rows[ix].ItemArray[jx] + "\"";
                        iCsv.Append(lv2);
                    }

                    if (jx < dt.Columns.Count - 1)
                    {
                        iCsv.Append(',');
                    }
                }

                var newCsvLine = iCsv.ToString();

                File.AppendAllText(csvFileName,
                    newCsvLine + "\n");
            }
        }
    }
}