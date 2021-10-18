using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace IBM_Statement_Processing
{
    public class ConvertCoverSheet : GatherExcel
    {
        public static bool CoverSheetProcessing(string compFileName, string csvFileName)
        {
            // setting up excel access
            var coverExcel = new Excel.Application();
            coverExcel.Workbooks.Open(compFileName, false, true);
            var coverSheet = (Excel.Worksheet)coverExcel.ActiveSheet;
            var fileName = Path.GetFileName(compFileName);
            int sheetCount = coverExcel.Sheets.Count;
            int[,] rangeArray = new int[13, 2];
            var fileReject = false;

            if (sheetCount == 1)
            {
                coverSheet.Activate();
                coverExcel.Sheets[1].Activate();
                coverExcel.Range["A1"].Activate();

                string[] srchArray = new string[]
                {
                    "CONTRACT", "ROYALTY PERIOD:", "STATEMENT DATE:", "PRIOR BALANCE FORWARD",
                    "ROYALTY EARNED FOR STATEMENT PERIOD", " CURRENT BALANCE FORWARD", " TOTAL PARTICIPANT PAYMENT"
                };

                for (int i = 0; i <= 6; i++)
                {
                    var prx = (Excel.Range)coverExcel.Sheets[1].Range("A1:Z500").Find(what: srchArray[i]);

                    if (prx != null)
                    {
                        rangeArray[i, 0] = prx.Column;
                        rangeArray[i, 1] = prx.Row;
                    }
                    else
                    {
                        fileReject = true;
                    }
                }

                if (fileReject)
                {
                    MessageBox.Show("Unsuccessful Conversion of Cover File - Parsing Error :");
                    return false;
                }
                else
                {
                    string currentContract = coverSheet.Cells[rangeArray[0, 1], rangeArray[0, 0]].Value.ToString().ToUpper()
                        .Replace("ROYALTY PAYMENT SUMMARY FOR CONTRACT NUMBER:", "").Trim();
                    string currentPeriod = coverSheet.Cells[rangeArray[1, 1], rangeArray[1, 0]].Value.ToString().ToUpper()
                        .Replace("ROYALTY PERIOD:", "").Trim();
                    var stmEndDt = DateTime.ParseExact("01/" + currentPeriod.Substring(currentPeriod.Length - 7, 7),
                        "dd/MM/yyyy", CultureInfo.InvariantCulture).AddMonths(1).AddDays(-1);
                    string currentStatementIn = coverSheet.Cells[rangeArray[2, 1], rangeArray[2, 0]].Value.ToString()
                        .ToUpper().Replace("STATEMENT DATE:", "").Trim();
                    var currentStatement = DateTime.ParseExact(currentStatementIn, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                    double balanceForward = coverSheet.Cells[rangeArray[3, 1], rangeArray[1, 0] + 2].Value;
                    double royaltyEarned = coverSheet.Cells[rangeArray[4, 1], rangeArray[1, 0] + 2].Value;
                    double currentBalance = coverSheet.Cells[rangeArray[5, 1], rangeArray[1, 0] + 2].Value;
                    double currentPayout = coverSheet.Cells[rangeArray[6, 1], rangeArray[1, 0] + 2].Value;

                    var uniqStr = string.Concat(currentContract, currentPeriod, currentStatement.ToString(),
                        balanceForward.ToString(), royaltyEarned.ToString(), currentBalance.ToString(),
                        currentPayout.ToString());
                    // MessageBox.Show(uniqStr);
                    string coverId = ComputeSha256Hash(uniqStr);

                    var convCoverRow = excelConvCover.NewRow();
                    convCoverRow[0] = coverId;
                    convCoverRow[1] = currentContract;
                    convCoverRow[2] = currentPeriod;
                    convCoverRow[3] = stmEndDt.ToString("yyyy-MM-dd");
                    convCoverRow[4] = currentStatement.ToString("yyyy-MM-dd");
                    convCoverRow[5] = balanceForward.ToString();
                    convCoverRow[6] = royaltyEarned.ToString();
                    convCoverRow[7] = currentBalance.ToString();
                    convCoverRow[8] = currentPayout.ToString();
                    convCoverRow[9] = fileName;
                    excelConvCover.Rows.Add(convCoverRow);

                    StringBuilder iCsv = new StringBuilder();

                    for (int jx = 0; jx < 10; jx++)
                    {
                        string lv2 = "\"" + convCoverRow.ItemArray[jx] + "\"";
                        iCsv.Append(lv2);

                        if (jx < 9)
                        {
                            iCsv.Append(',');
                        }
                    }

                    var newCsvLine = iCsv.ToString();

                    File.AppendAllText(csvFileName,
                        newCsvLine + "\n");
                }
            }
            else
            {
                MessageBox.Show("Unsuccessful Conversion of Cover File - More than 1 Sheet :");
                return false;
            }
            Marshal.ReleaseComObject(coverSheet);
            coverExcel.Workbooks.Close();
            return true;
        }
    }
}