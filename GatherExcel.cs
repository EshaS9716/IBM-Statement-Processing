using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace IBM_Statement_Processing
{
    public partial class GatherExcel : Form
    {
        // List<ProductDataReference> productData = new();
        public static readonly DataTable excelConv = new DataTable();

        public static readonly DataTable excelConvCover = new DataTable();
        public static readonly DataTable existingpcodes = new System.Data.DataTable();
        public static readonly DataTable newpids = new System.Data.DataTable();
        public static readonly DataTable sqlstatements = new System.Data.DataTable();

        private static int FileNumber;
        private static int FileRejected;

        private static int CoverFileCount;
        private static int CoverRecsCnt;
        protected int CurRecCnt;
        protected int FileCount;
        protected int RecCnt;

        public double ProcessFileReport;
        public double ProcessFileTotal;

        protected string CompDirectory;
        protected string ProbDirectory;
        protected string OutputDirectory;
        protected string RejectFile;
        protected string CompFileName;

        public DateTime ElapseStartTime;

        //public bool ExcelCompleted = true;

        protected string FileName;
        protected string LogDirectory;
        protected string LogFile;
        protected string MySqlDataLoad;
        protected string MySqlDataLoadCover;
        protected string EssbaseFile;

        private const string ParseComp = "Parsing Completed";
        private const string ParseCompRecs = "Parsing Completed - Number Of Records = ";
        private const string excelFilter = "Excel Files|*.xls;*.xlsx;*.xlsm";
        private const string excelTitle = "Select Excel Files";

        public GatherExcel()
        {
            InitializeComponent();
        }

        public void BeginProcess()
        {
            SetDataTable();

            openFileDialog.FileName = null;
            openFileDialog.Filter = excelFilter;
            openFileDialog.Title = excelTitle;
            ElapseStartTime = DateTime.Now;
            timer.Enabled = true;
            timer.Interval = 100;

            // get collection of files to process
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileCount = openFileDialog.FileNames.Length;
                tbTotalFiles.Text = FileCount.ToString();
                LogDirectory = Path.GetDirectoryName(openFileDialog.FileNames[0]) + "/Log/";
                CompDirectory = Path.GetDirectoryName(openFileDialog.FileNames[0]) + "/Processed/";
                ProbDirectory = Path.GetDirectoryName(openFileDialog.FileNames[0]) + "/Problem/";
                OutputDirectory = Path.GetDirectoryName(openFileDialog.FileNames[0]) + "/Output/";
                Directory.CreateDirectory(LogDirectory);
                Directory.CreateDirectory(CompDirectory);
                Directory.CreateDirectory(ProbDirectory);
                Directory.CreateDirectory(OutputDirectory);
                LogFile = LogDirectory + $"log_{DateTime.Now:yyyyMMddhhmm}.txt";
                RejectFile = LogDirectory + $"reject_{DateTime.Now:yyyyMMddhhmm}.txt";
                MySqlDataLoad = OutputDirectory + $"MySqlDataLoad_{DateTime.Now:yyyyMMddhhmm}.csv";
                MySqlDataLoadCover = OutputDirectory + $"MySqlDataLoadCover_{DateTime.Now:yyyyMMddhhmm}.csv";
                EssbaseFile = OutputDirectory + $"Essbase_{DateTime.Now:yyyy-MM-dd hhmm}.xlsx";
                BtGetFile.Visible = false;
                timer.Start();
                tbFilesRejected.Text = FileRejected.ToString();

                // load existing pcodes into datatable
                GetMySqlData.MySqlFillData(existingpcodes, 1);
                tbPcodesLoaded.Text = existingpcodes.Rows.Count.ToString("n0");
                // tbPcodesLoaded = existingpcodes.Rows.Count;
                // MessageBox.Show("PCode Cnt = " + existingpcodes.Rows.Count);

                // process through files
                for (int i = 0; i <= FileCount - 1; i++)
                {
                    FileNumber++;
                    FileName = Path.GetFileName(openFileDialog.FileNames[i]);
                    CurRecCnt = 0;
                    CompFileName = openFileDialog.FileNames[i];
                    lblCurrentFile.Text = Path.GetFileName(openFileDialog.FileNames[i]);
                    TbTimer.Text = DateTime.Now.Subtract(ElapseStartTime).ToString().Substring(0, 8);

                    {
                        int fileType = ParseExcel(CompFileName, MySqlDataLoad, FileNumber);
                        tbFilesProc.Text = FileNumber.ToString();
                        //   MessageBox.Show("Total Records : " + RecCnt);
                        if (fileType == 1)
                        {
                            CoverFileCount++;
                            tbCoverFile.Text = CoverFileCount.ToString();
                            tbFilesProc.Text = FileNumber.ToString();
                            tbFilesRejected.Text = FileRejected.ToString();
                        }
                        else
                        {
                            if (fileType == 2)
                            {
                                File.AppendAllText(LogFile,
                                    FileName + " - " + CurRecCnt.ToString("n0") + " recs" + Environment.NewLine);
                                // move completed file to processed directory
                                File.Copy(CompFileName, Path.Combine(CompDirectory, FileName), true);
                                File.Delete(CompFileName);
                            }
                            else if (fileType == 3)
                            {
                                File.AppendAllText(RejectFile,
                                    FileName + " - More than 1 Sheet " + Environment.NewLine);
                                FileRejected += 1;
                                tbFilesRejected.Text = FileRejected.ToString();
                                File.Copy(CompFileName, Path.Combine(ProbDirectory, FileName), true);
                                File.Delete(CompFileName);
                            }

                            if (fileType == 4)
                            {
                                File.AppendAllText(RejectFile,
                                    FileName + " - Cell Asignment Problem " + Environment.NewLine);
                                FileRejected += 1;
                                tbFilesRejected.Text = FileRejected.ToString();
                                File.Copy(CompFileName, Path.Combine(ProbDirectory, FileName), true);
                                File.Delete(CompFileName);
                            }
                        }
                    }
                }

                TbTimer.Text = DateTime.Now.Subtract(ElapseStartTime).ToString().Substring(0, 8);
                timer.Stop();
                tbRecsProc.Text = RecCnt.ToString("n0");
                // MessageBox.Show("Total Rec Cnt = " + RecCnt.ToString("n0") +
                //                "\nData Table Cnt = " + excelConv.Rows.Count);
                tbFilesRejected.Text = FileRejected.ToString();
                tbFilesProc.Text = FileNumber.ToString();
                tbCurrentPayout.TextAlign = HorizontalAlignment.Center;
                tbCurrentPayout.Font = new Font("Arial", 8f);
                tbCurrentPayout.Text = ParseComp;
                tbSupTotal.TextAlign = HorizontalAlignment.Center;
                tbSupTotal.Font = new Font("Arial", 8f);
                tbSupTotal.Text = ParseComp;
                lblCurrentFile.TextAlign = ContentAlignment.MiddleCenter;
                lblCurrentFile.Text = ParseCompRecs + RecCnt.ToString("n0");

                if (RecCnt > 0)
                {
                    if (newpids.Rows.Count > 0)
                    {
                        MessageBox.Show("Appears to be new PIDs or missing PCodes : " + newpids.Rows.Count.ToString());
                        BtUpdPid.Visible = true;
                    }
                    BtExportMySQL.Visible = true;
                }
                else
                {
                    MessageBox.Show("No Records have been Converted !");
                    //        this.Close();
                }

                LbFile.Visible = false;
            }
        }

        // parsing of selected files
        public int ParseExcel(string CompFileName, string sqlDirectory, int FileNumber)

        {
            var processedFileNumber = FileNumber;
            var excelFileName = CompFileName;
            var mySqlDataLoad = sqlDirectory;
            var fileName = Path.GetFileName(excelFileName);

            // checking if cover sheet & exiting method
            if (excelFileName.Contains("Cover"))
            {
                var coverStatus = ConvertCoverSheet.CoverSheetProcessing(compFileName: excelFileName, MySqlDataLoadCover);
                //    MessageBox.Show("Identified Cover Sheet : " + ProcessedFileNumber);
                if (coverStatus == false)
                {
                    FileRejected += 1;
                    File.AppendAllText(RejectFile, excelFileName + " - Cell Asignment Problem " + Environment.NewLine);
                    File.Copy(excelFileName, Path.Combine(ProbDirectory, fileName), true);
                    File.Delete(excelFileName);
                }
                else
                {
                    CoverRecsCnt++;
                    File.Copy(excelFileName, Path.Combine(CompDirectory, fileName), true);
                    File.Delete(excelFileName);
                }

                return 1;
            }

            var detailExcel = new Excel.Application();
            detailExcel.Workbooks.Open(excelFileName, false, true);
            var detailSheet = (Excel.Worksheet)detailExcel.ActiveSheet;
            int sheetCount = detailExcel.Sheets.Count;

            int[,] rangeArray = new int[13, 2];
            string[] valueArray = new string[10];

            string currentPid = " ";
            string currentPcode = " ";
            double supTotal = 0.00;
            var fileReject = false;

            if (sheetCount == 1)
            {
                //     MessageBox.Show(sheetCount.ToString());
                detailSheet.Activate();
                detailExcel.Sheets[1].Activate();
                detailExcel.Range["A1"].Activate();

                string[] srchArray = new string[]
                {
                    "CONTRACT", "ROYALTY PERIOD:", "STATEMENT DATE:", "PRODUCT",
                    "DESCRIPTION", "ACTIVITY TYPE", "GEOGRAPHY", "COUNTRY", "REVENUE",
                    "RATE", "DUE", "PRODUCT TOTALS", "NET ROYALTY PAYMENT"
                };

                for (int i = 0; i <= 12; i++)
                {
                    Excel.Range prx;
                    if (i <= 2)
                    {
                        prx = (Excel.Range)detailExcel.Sheets["Sheet1"].Range("B1:Z50").Find(what: srchArray[i]);
                    }
                    else
                    {
                        prx = (Excel.Range)detailExcel.Sheets["Sheet1"].Range("B25:Z20000").Find(what: srchArray[i]);
                    }

                    if (prx == null && i == 8)
                    {
                        prx = (Excel.Range)detailExcel.Sheets["Sheet1"].Range("B25:Z20000").Find(what: "VOLUME");
                    }

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
                    Marshal.ReleaseComObject(detailSheet);
                    detailExcel.Workbooks.Close();
                    detailExcel.Quit();
                    return 3;
                }
                else
                {
                    var firstRow = rangeArray[10, 1];
                    var lastRow = rangeArray[11, 1];

                    string currentContract = detailSheet.Cells[rangeArray[0, 1], rangeArray[0, 0]].Value.ToString()
                        .ToUpper()
                        .Replace("ROYALTY EARNED FOR CONTRACT NUMBER:", "").Trim();
                    string currentPeriod = detailSheet.Cells[rangeArray[1, 1], rangeArray[1, 0]].Value.ToString()
                        .ToUpper()
                        .Replace("ROYALTY PERIOD:", "").Trim();
                    var stmEndDt = DateTime.ParseExact("01/" + currentPeriod.Substring(currentPeriod.Length - 7, 7),
                        "dd/MM/yyyy", CultureInfo.InvariantCulture).AddMonths(1).AddDays(-1);
                    string currentStatement = detailSheet.Cells[rangeArray[2, 1], rangeArray[2, 0]].Value.ToString()
                        .ToUpper().Replace("STATEMENT DATE:", "").Trim();
                    var updDate = DateTime.ParseExact(currentStatement, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                    double currentPayout = detailSheet.Cells[rangeArray[11, 1], rangeArray[10, 0]].Value;
                    double actualPayout = detailSheet.Cells[rangeArray[12, 1], rangeArray[10, 0]].Value;
                    // if (actualPayout != currentPayout)
                    // {
                    //MessageBox.Show("Current Total : " + currentPayout.ToString() + "\n" + "Actual Total : " +
                    //                actualPayout.ToString());
                    // }

                    tbCurrentPayout.Text = $@"{currentPayout:n}";
                    ProcessFileReport += currentPayout;
                    tbReportedTotal.Text = $@"{ProcessFileReport:n}";

                    for (int rw = (firstRow + 1); rw < lastRow; rw++)
                    {
                        if (detailSheet.Cells[rw, rangeArray[7, 0]].Text.Trim() != "PRODUCT SUBTOTAL" &&
                            detailSheet.Cells[rw, rangeArray[10, 0]].Value2 != null &&
                            detailSheet.Cells[rw, 1].Value2 != "PRODUCT SUBTOTAL01")

                        {
                            var convRow = excelConv.NewRow();
                            convRow[1] = currentPeriod;
                            convRow[2] = stmEndDt.ToString("yyyy-MM-dd");
                            convRow[3] = currentContract;
                            convRow[12] = updDate.ToString("yyyy-MM-dd");
                            convRow[13] = FileName;

                            if (actualPayout != 0)
                            {
                                convRow[14] = stmEndDt.ToString("yyyy-MM-dd");
                            }
                            else
                            {
                                convRow[14] = stmEndDt.AddMonths(3).AddDays(0).ToString("yyyy-MM-dd");
                            }

                            for (int rc = 3; rc <= 10; rc++)
                            {
                                if (detailSheet.Cells[rw, rangeArray[rc, 0]].Value2 != null)
                                {
                                    if (rc == 9)
                                    {
                                        convRow[rc + 1] = detailSheet.Cells[rw, rangeArray[rc, 0]].Text.Trim()
                                            .Replace("%", "");
                                    }
                                    else if (rc == 8 || rc == 10)
                                    {
                                        convRow[rc + 1] = detailSheet.Cells[rw, rangeArray[rc, 0]].Value2;
                                    }
                                    else if (rc == 5)
                                    {
                                        string acTemp = detailSheet.Cells[rw, rangeArray[rc, 0]].Text.Trim() + "  ";
                                        convRow[rc + 1] = acTemp.Substring(0,
                                            acTemp.IndexOf("  ", StringComparison.Ordinal));
                                        valueArray[rc] = acTemp.Substring(0,
                                            acTemp.IndexOf("  ", StringComparison.Ordinal));
                                    }
                                    else
                                    {
                                        convRow[rc + 1] = detailSheet.Cells[rw, rangeArray[rc, 0]].Text.Trim();
                                        valueArray[rc] = detailSheet.Cells[rw, rangeArray[rc, 0]].Text.Trim();
                                    }
                                }
                                else
                                {
                                    convRow[rc + 1] = valueArray[rc];
                                }
                            }

                            var pidx = (convRow[4] + "       ").Substring(0, 7);
                            convRow[15] = pidx;
                            convRow[16] = (convRow[4] + "                    ").Substring(7, 20);

                            if (pidx != currentPid)
                            {
                                string pcodex = CkForPid(pidx, convRow[5].ToString());
                                currentPcode = pcodex;
                                currentPid = pidx;
                            }

                            convRow[17] = currentPcode;
                            var uniqStr = string.Concat(convRow[1].ToString(), convRow[3].ToString(),
                                convRow[4].ToString(),
                                convRow[6].ToString(), convRow[7].ToString(), convRow[8].ToString(),
                                convRow[9].ToString(), convRow[10].ToString(), convRow[11].ToString());

                            convRow[0] = ComputeSha256Hash(uniqStr);

                            excelConv.Rows.Add(convRow);
                            ProcessFileTotal += detailSheet.Cells[rw, rangeArray[10, 0]].Value2;
                            supTotal += detailSheet.Cells[rw, rangeArray[10, 0]].Value2;
                            tbSupTotal.Text = $@"{supTotal:n}";
                            RecCnt += 1;
                            CurRecCnt += 1;

                            tbRecsProc.Text = $@"{RecCnt:n0}";
                        }
                    }

                    if (currentPayout.ToString("N2") != supTotal.ToString("N2"))
                    {
                        File.AppendAllText(RejectFile,
                            FileName + " Unmatched Totals " + currentPayout.ToString("N2") + " - " +
                            supTotal.ToString("N2") + Environment.NewLine);
                        FileRejected += 1;
                        tbFilesRejected.Text = FileRejected.ToString();
                    }

                    tbProcessedPayouts.Text = $@"{ProcessFileTotal:n}";
                }

                if (CurRecCnt > 0)
                {
                    var lvCount = LVList.Items.Count;
                    if (processedFileNumber < 2 || lvCount <= 200)
                    // place first 200 rows in the listview
                    {
                        SendToLv.CopyDataTableToListView(excelConv, LVList);
                    }

                    //    MessageBox.Show("Total Records : " + RecCnt);
                    CreateCsvOutput.DataToSql(excelConv, mySqlDataLoad);
                    Marshal.ReleaseComObject(detailSheet);
                    detailExcel.Workbooks.Close();
                    detailExcel.Quit();
                    return 2;
                }
                Marshal.ReleaseComObject(detailSheet);
                detailExcel.Workbooks.Close();
                detailExcel.Quit();
                return 4;
            }
            else
            {
                Marshal.ReleaseComObject(detailSheet);
                detailExcel.Workbooks.Close();
                detailExcel.Quit();
                return 3;
            }
        }

        // checking for existing PID
        public string CkForPid(string pid, string description)
        {
            string chkpid = pid;
            string pcode;
            int pidrow = 0;
            if (!string.IsNullOrEmpty(chkpid))
            {
                for (int i = 0; i < existingpcodes.Rows.Count; i++)
                {
                    if (chkpid == existingpcodes.Rows[i][0].ToString())
                    {
                        pcode = existingpcodes.Rows[i][1].ToString();
                        return pcode;
                    }
                }

                if (pidrow == 0 || String.IsNullOrEmpty(existingpcodes.Rows[pidrow][1].ToString()))
                {
                    for (int i = 0; i <= newpids.Rows.Count - 1; i++)
                    {
                        if (chkpid == newpids.Rows[i][0].ToString())
                        {
                            chkpid = null;
                        }
                    }

                    if (chkpid != null)
                    {
                        newpids.Rows.Add(chkpid, description);
                        tbNewPid.Text = newpids.Rows.Count.ToString();
                    }
                }

                pcode = null;
                return pcode;
            }

            return null;
        }

        // creating hash to identify unique records
        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256
            using SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(buffer: Encoding.UTF8.GetBytes(s: rawData));
            // Convert byte array to a string
            StringBuilder builder = new StringBuilder();
            foreach (var t in bytes)
            {
                builder.Append(value: t.ToString(format: "x2"));
            }

            return builder.ToString();
        }

        public static void SetDataTable()
        {
            excelConv.Columns.Add("TransId", typeof(String));
            excelConv.Columns.Add("PeriodDate", typeof(String));
            excelConv.Columns.Add("StmDate", typeof(String));
            excelConv.Columns.Add("Contract", typeof(String));
            excelConv.Columns.Add("Prod", typeof(String));
            excelConv.Columns.Add("ProdDesc", typeof(String));
            excelConv.Columns.Add("ActType", typeof(String));
            excelConv.Columns.Add("GeoCode", typeof(String));
            excelConv.Columns.Add("Country", typeof(String));
            excelConv.Columns.Add("SalesRev", typeof(Double));
            excelConv.Columns.Add("RoyaltyPct", typeof(String));
            excelConv.Columns.Add("RoyaltyAmt", typeof(Double));
            excelConv.Columns.Add("UpdDate", typeof(String));
            excelConv.Columns.Add("FileRef", typeof(String));
            excelConv.Columns.Add("RevenueDate", typeof(String));
            excelConv.Columns.Add("Pid", typeof(String));
            excelConv.Columns.Add("FeatureCode", typeof(String));
            excelConv.Columns.Add("PCode", typeof(String));

            excelConvCover.Columns.Add("CoverId", typeof(String));
            excelConvCover.Columns.Add("CurrentContract", typeof(String));
            excelConvCover.Columns.Add("CurrentPeriod", typeof(String));
            excelConvCover.Columns.Add("StmEndDt", typeof(String));
            excelConvCover.Columns.Add("CurrentStatement", typeof(String));
            excelConvCover.Columns.Add("BalanceForward", typeof(String));
            excelConvCover.Columns.Add("RoyaltyEarned", typeof(String));
            excelConvCover.Columns.Add("CurrentBalance", typeof(String));
            excelConvCover.Columns.Add("CurrentPayout", typeof(String));
            excelConvCover.Columns.Add("FileName", typeof(String));

            sqlstatements.Columns.Add("sorc", typeof(int));
            sqlstatements.Columns.Add("sqlst", typeof(int));
            newpids.Columns.Add("pid", typeof(String));
            newpids.Columns.Add("descr", typeof(String));
            newpids.Columns.Add("prodtype", typeof(String));
            newpids.Columns.Add("pcode", typeof(String));
            existingpcodes.Columns.Add(new DataColumn("pid", typeof(string)));
            existingpcodes.Columns.Add(new DataColumn("pcode", typeof(string)));
            existingpcodes.Columns.Add(new DataColumn("pid_description", typeof(string)));
            existingpcodes.Columns.Add(new DataColumn("lic_maint", typeof(string)));
        }

        private void BtExportMySQL_Click_1(object sender, EventArgs e)
        {
            SendToMySql.UpdatingMySql(RecCnt, CoverRecsCnt, MySqlDataLoad, MySqlDataLoadCover);
            BtExportMySQL.Visible = false;
            BtExportToExcel.Visible = true;
        }

        private void BtGetFile_Click(object sender, EventArgs e)
        {
            BeginProcess();
        }

        private void BtQuit_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you wish to exit", "Exit Application",
                MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void BtUpdPid_Click(object sender, EventArgs e)
        {
            PidUpd frm1 = new PidUpd();
            frm1.ShowDialog();
        }

        private void BtExportToExcel_Click(object sender, EventArgs e)
        {
            SendToEssbase.CopyDataTableToExcel(EssbaseFile);
            SendToEssbase.SetAutoColumnWidth(EssbaseFile);
            BtExportToExcel.Visible = false;
        }
    }
}