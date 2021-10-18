
namespace IBM_Statement_Processing
{
    partial class GatherExcel
    {

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtGetFile = new System.Windows.Forms.Button();
            this.LbFile = new System.Windows.Forms.Label();
            this.BtQuit = new System.Windows.Forms.Button();
            this.BtExportMySQL = new System.Windows.Forms.Button();
            this.LVList = new System.Windows.Forms.ListView();
            this.unq_x = new System.Windows.Forms.ColumnHeader();
            this.period_date = new System.Windows.Forms.ColumnHeader();
            this.stm_date = new System.Windows.Forms.ColumnHeader();
            this.contract = new System.Windows.Forms.ColumnHeader();
            this.prod = new System.Windows.Forms.ColumnHeader();
            this.prod_desc = new System.Windows.Forms.ColumnHeader();
            this.act_type = new System.Windows.Forms.ColumnHeader();
            this.geo_code = new System.Windows.Forms.ColumnHeader();
            this.country = new System.Windows.Forms.ColumnHeader();
            this.sales_rev = new System.Windows.Forms.ColumnHeader();
            this.royalty_pct = new System.Windows.Forms.ColumnHeader();
            this.royalty_amt = new System.Windows.Forms.ColumnHeader();
            this.upd_date = new System.Windows.Forms.ColumnHeader();
            this.file_ref = new System.Windows.Forms.ColumnHeader();
            this.LbFileNumber = new System.Windows.Forms.Label();
            this.LbFilesProcessed = new System.Windows.Forms.Label();
            this.LbFilesRejected = new System.Windows.Forms.Label();
            this.LbRecsProcessed = new System.Windows.Forms.Label();
            this.LbProcessedPayouts = new System.Windows.Forms.Label();
            this.LbReportedTotal = new System.Windows.Forms.Label();
            this.LbAllFiles = new System.Windows.Forms.Label();
            this.LbCurrentPayout = new System.Windows.Forms.Label();
            this.LbTotalPayoutCurrent = new System.Windows.Forms.Label();
            this.tbTotalFiles = new System.Windows.Forms.TextBox();
            this.tbFilesProc = new System.Windows.Forms.TextBox();
            this.tbFilesRejected = new System.Windows.Forms.TextBox();
            this.tbRecsProc = new System.Windows.Forms.TextBox();
            this.tbReportedTotal = new System.Windows.Forms.TextBox();
            this.tbProcessedPayouts = new System.Windows.Forms.TextBox();
            this.tbCurrentPayout = new System.Windows.Forms.TextBox();
            this.tbSupTotal = new System.Windows.Forms.TextBox();
            this.lbCurrentFile = new System.Windows.Forms.Label();
            this.llbElapsedTime = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.TbTimer = new System.Windows.Forms.TextBox();
            this.lbCoverFiles = new System.Windows.Forms.Label();
            this.tbCoverFile = new System.Windows.Forms.TextBox();
            this.lbNewPidCount = new System.Windows.Forms.Label();
            this.tbNewPid = new System.Windows.Forms.TextBox();
            this.BtUpdPid = new System.Windows.Forms.Button();
            this.lblCurrentFile = new System.Windows.Forms.Label();
            this.BtExportToExcel = new System.Windows.Forms.Button();
            this.lbPcodesLoaded = new System.Windows.Forms.Label();
            this.tbPcodesLoaded = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtGetFile
            // 
            this.BtGetFile.Location = new System.Drawing.Point(706, 24);
            this.BtGetFile.Name = "BtGetFile";
            this.BtGetFile.Size = new System.Drawing.Size(125, 23);
            this.BtGetFile.TabIndex = 1;
            this.BtGetFile.Text = "Select File(s)";
            this.BtGetFile.UseVisualStyleBackColor = true;
            this.BtGetFile.Click += new System.EventHandler(this.BtGetFile_Click);
            // 
            // LbFile
            // 
            this.LbFile.AutoSize = true;
            this.LbFile.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.LbFile.Location = new System.Drawing.Point(44, 28);
            this.LbFile.Name = "LbFile";
            this.LbFile.Size = new System.Drawing.Size(74, 15);
            this.LbFile.TabIndex = 0;
            this.LbFile.Text = "Current File";
            // 
            // BtQuit
            // 
            this.BtQuit.Location = new System.Drawing.Point(1132, 24);
            this.BtQuit.Name = "BtQuit";
            this.BtQuit.Size = new System.Drawing.Size(89, 23);
            this.BtQuit.TabIndex = 3;
            this.BtQuit.Text = "Quit";
            this.BtQuit.UseVisualStyleBackColor = true;
            this.BtQuit.Click += new System.EventHandler(this.BtQuit_Click_1);
            // 
            // BtExportMySQL
            // 
            this.BtExportMySQL.Location = new System.Drawing.Point(834, 24);
            this.BtExportMySQL.Name = "BtExportMySQL";
            this.BtExportMySQL.Size = new System.Drawing.Size(125, 23);
            this.BtExportMySQL.TabIndex = 4;
            this.BtExportMySQL.Text = "Export List to MySQL";
            this.BtExportMySQL.UseVisualStyleBackColor = true;
            this.BtExportMySQL.Visible = false;
            this.BtExportMySQL.Click += new System.EventHandler(this.BtExportMySQL_Click_1);
            // 
            // LVList
            // 
            this.LVList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.unq_x,
            this.period_date,
            this.stm_date,
            this.contract,
            this.prod,
            this.prod_desc,
            this.act_type,
            this.geo_code,
            this.country,
            this.sales_rev,
            this.royalty_pct,
            this.royalty_amt,
            this.upd_date,
            this.file_ref});
            this.LVList.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LVList.FullRowSelect = true;
            this.LVList.GridLines = true;
            this.LVList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LVList.HideSelection = false;
            this.LVList.Location = new System.Drawing.Point(47, 79);
            this.LVList.MultiSelect = false;
            this.LVList.Name = "LVList";
            this.LVList.Size = new System.Drawing.Size(1176, 345);
            this.LVList.TabIndex = 0;
            this.LVList.UseCompatibleStateImageBehavior = false;
            this.LVList.View = System.Windows.Forms.View.Details;
            // 
            // unq_x
            // 
            this.unq_x.Name = "unq_x";
            this.unq_x.Text = "Transaction ID";
            this.unq_x.Width = 100;
            // 
            // period_date
            // 
            this.period_date.Name = "period_date";
            this.period_date.Text = "Period Date";
            this.period_date.Width = 100;
            // 
            // stm_date
            // 
            this.stm_date.Name = "stm_date";
            this.stm_date.Text = "Statement Date";
            this.stm_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.stm_date.Width = 100;
            // 
            // contract
            // 
            this.contract.Name = "contract";
            this.contract.Text = "Contract";
            this.contract.Width = 75;
            // 
            // prod
            // 
            this.prod.Name = "prod";
            this.prod.Text = "Product";
            this.prod.Width = 75;
            // 
            // prod_desc
            // 
            this.prod_desc.Name = "prod_desc";
            this.prod_desc.Text = "Product Description";
            this.prod_desc.Width = 120;
            // 
            // act_type
            // 
            this.act_type.Name = "act_type";
            this.act_type.Text = "Activity Type";
            this.act_type.Width = 80;
            // 
            // geo_code
            // 
            this.geo_code.Name = "geo_code";
            this.geo_code.Text = "GEO Code";
            this.geo_code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.geo_code.Width = 75;
            // 
            // country
            // 
            this.country.Name = "country";
            this.country.Text = "Country";
            // 
            // sales_rev
            // 
            this.sales_rev.Name = "sales_rev";
            this.sales_rev.Text = "Sales Revenue";
            this.sales_rev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sales_rev.Width = 100;
            // 
            // royalty_pct
            // 
            this.royalty_pct.Name = "royalty_pct";
            this.royalty_pct.Text = "Royalty %";
            this.royalty_pct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.royalty_pct.Width = 75;
            // 
            // royalty_amt
            // 
            this.royalty_amt.Name = "royalty_amt";
            this.royalty_amt.Text = "Royalty Amount";
            this.royalty_amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.royalty_amt.Width = 100;
            // 
            // upd_date
            // 
            this.upd_date.Name = "upd_date";
            this.upd_date.Text = "Update Date";
            this.upd_date.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.upd_date.Width = 100;
            // 
            // file_ref
            // 
            this.file_ref.Name = "file_ref";
            this.file_ref.Text = "File Reference";
            this.file_ref.Width = 200;
            // 
            // LbFileNumber
            // 
            this.LbFileNumber.AutoSize = true;
            this.LbFileNumber.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.LbFileNumber.Location = new System.Drawing.Point(47, 439);
            this.LbFileNumber.Name = "LbFileNumber";
            this.LbFileNumber.Size = new System.Drawing.Size(97, 15);
            this.LbFileNumber.TabIndex = 1;
            this.LbFileNumber.Text = "# Files Selected";
            // 
            // LbFilesProcessed
            // 
            this.LbFilesProcessed.AutoSize = true;
            this.LbFilesProcessed.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.LbFilesProcessed.Location = new System.Drawing.Point(47, 470);
            this.LbFilesProcessed.Name = "LbFilesProcessed";
            this.LbFilesProcessed.Size = new System.Drawing.Size(109, 15);
            this.LbFilesProcessed.TabIndex = 2;
            this.LbFilesProcessed.Text = "# Files Processed";
            // 
            // LbFilesRejected
            // 
            this.LbFilesRejected.AutoSize = true;
            this.LbFilesRejected.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.LbFilesRejected.Location = new System.Drawing.Point(217, 439);
            this.LbFilesRejected.Name = "LbFilesRejected";
            this.LbFilesRejected.Size = new System.Drawing.Size(98, 15);
            this.LbFilesRejected.TabIndex = 3;
            this.LbFilesRejected.Text = "# Files Rejected";
            // 
            // LbRecsProcessed
            // 
            this.LbRecsProcessed.AutoSize = true;
            this.LbRecsProcessed.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.LbRecsProcessed.Location = new System.Drawing.Point(217, 470);
            this.LbRecsProcessed.Name = "LbRecsProcessed";
            this.LbRecsProcessed.Size = new System.Drawing.Size(112, 15);
            this.LbRecsProcessed.TabIndex = 4;
            this.LbRecsProcessed.Text = "# Recs Processed";
            // 
            // LbProcessedPayouts
            // 
            this.LbProcessedPayouts.AutoSize = true;
            this.LbProcessedPayouts.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.LbProcessedPayouts.Location = new System.Drawing.Point(417, 439);
            this.LbProcessedPayouts.Name = "LbProcessedPayouts";
            this.LbProcessedPayouts.Size = new System.Drawing.Size(119, 15);
            this.LbProcessedPayouts.TabIndex = 5;
            this.LbProcessedPayouts.Text = "Processed Payouts";
            // 
            // LbReportedTotal
            // 
            this.LbReportedTotal.AutoSize = true;
            this.LbReportedTotal.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.LbReportedTotal.Location = new System.Drawing.Point(417, 470);
            this.LbReportedTotal.Name = "LbReportedTotal";
            this.LbReportedTotal.Size = new System.Drawing.Size(141, 15);
            this.LbReportedTotal.TabIndex = 6;
            this.LbReportedTotal.Text = "Reported Total Payouts";
            // 
            // LbAllFiles
            // 
            this.LbAllFiles.AutoSize = true;
            this.LbAllFiles.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.LbAllFiles.Location = new System.Drawing.Point(452, 415);
            this.LbAllFiles.Name = "LbAllFiles";
            this.LbAllFiles.Size = new System.Drawing.Size(187, 17);
            this.LbAllFiles.TabIndex = 11;
            this.LbAllFiles.Text = "All Files Being Processed";
            // 
            // LbCurrentPayout
            // 
            this.LbCurrentPayout.AutoSize = true;
            this.LbCurrentPayout.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.LbCurrentPayout.Location = new System.Drawing.Point(821, 470);
            this.LbCurrentPayout.Name = "LbCurrentPayout";
            this.LbCurrentPayout.Size = new System.Drawing.Size(94, 15);
            this.LbCurrentPayout.TabIndex = 7;
            this.LbCurrentPayout.Text = "Current Payout";
            // 
            // LbTotalPayoutCurrent
            // 
            this.LbTotalPayoutCurrent.AutoSize = true;
            this.LbTotalPayoutCurrent.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.LbTotalPayoutCurrent.Location = new System.Drawing.Point(1027, 470);
            this.LbTotalPayoutCurrent.Name = "LbTotalPayoutCurrent";
            this.LbTotalPayoutCurrent.Size = new System.Drawing.Size(78, 15);
            this.LbTotalPayoutCurrent.TabIndex = 8;
            this.LbTotalPayoutCurrent.Text = "Total Payout";
            // 
            // tbTotalFiles
            // 
            this.tbTotalFiles.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbTotalFiles.Location = new System.Drawing.Point(168, 436);
            this.tbTotalFiles.Name = "tbTotalFiles";
            this.tbTotalFiles.ReadOnly = true;
            this.tbTotalFiles.Size = new System.Drawing.Size(38, 21);
            this.tbTotalFiles.TabIndex = 14;
            this.tbTotalFiles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbFilesProc
            // 
            this.tbFilesProc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbFilesProc.Location = new System.Drawing.Point(168, 467);
            this.tbFilesProc.Name = "tbFilesProc";
            this.tbFilesProc.ReadOnly = true;
            this.tbFilesProc.Size = new System.Drawing.Size(38, 21);
            this.tbFilesProc.TabIndex = 15;
            this.tbFilesProc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbFilesRejected
            // 
            this.tbFilesRejected.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbFilesRejected.Location = new System.Drawing.Point(337, 436);
            this.tbFilesRejected.Name = "tbFilesRejected";
            this.tbFilesRejected.ReadOnly = true;
            this.tbFilesRejected.Size = new System.Drawing.Size(65, 21);
            this.tbFilesRejected.TabIndex = 16;
            this.tbFilesRejected.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbRecsProc
            // 
            this.tbRecsProc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbRecsProc.Location = new System.Drawing.Point(337, 467);
            this.tbRecsProc.Name = "tbRecsProc";
            this.tbRecsProc.ReadOnly = true;
            this.tbRecsProc.Size = new System.Drawing.Size(65, 21);
            this.tbRecsProc.TabIndex = 17;
            this.tbRecsProc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbReportedTotal
            // 
            this.tbReportedTotal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbReportedTotal.Location = new System.Drawing.Point(561, 467);
            this.tbReportedTotal.Name = "tbReportedTotal";
            this.tbReportedTotal.ReadOnly = true;
            this.tbReportedTotal.Size = new System.Drawing.Size(102, 21);
            this.tbReportedTotal.TabIndex = 19;
            this.tbReportedTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbProcessedPayouts
            // 
            this.tbProcessedPayouts.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbProcessedPayouts.Location = new System.Drawing.Point(561, 436);
            this.tbProcessedPayouts.Name = "tbProcessedPayouts";
            this.tbProcessedPayouts.ReadOnly = true;
            this.tbProcessedPayouts.Size = new System.Drawing.Size(102, 21);
            this.tbProcessedPayouts.TabIndex = 18;
            this.tbProcessedPayouts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbCurrentPayout
            // 
            this.tbCurrentPayout.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbCurrentPayout.Location = new System.Drawing.Point(921, 467);
            this.tbCurrentPayout.Name = "tbCurrentPayout";
            this.tbCurrentPayout.ReadOnly = true;
            this.tbCurrentPayout.Size = new System.Drawing.Size(106, 21);
            this.tbCurrentPayout.TabIndex = 20;
            this.tbCurrentPayout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbSupTotal
            // 
            this.tbSupTotal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbSupTotal.Location = new System.Drawing.Point(1112, 467);
            this.tbSupTotal.Name = "tbSupTotal";
            this.tbSupTotal.ReadOnly = true;
            this.tbSupTotal.Size = new System.Drawing.Size(110, 21);
            this.tbSupTotal.TabIndex = 21;
            this.tbSupTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbCurrentFile
            // 
            this.lbCurrentFile.AutoSize = true;
            this.lbCurrentFile.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lbCurrentFile.Location = new System.Drawing.Point(927, 447);
            this.lbCurrentFile.Name = "lbCurrentFile";
            this.lbCurrentFile.Size = new System.Drawing.Size(214, 17);
            this.lbCurrentFile.TabIndex = 22;
            this.lbCurrentFile.Text = "Current File Being Processed";
            // 
            // llbElapsedTime
            // 
            this.llbElapsedTime.AutoSize = true;
            this.llbElapsedTime.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.llbElapsedTime.Location = new System.Drawing.Point(1130, 416);
            this.llbElapsedTime.Name = "llbElapsedTime";
            this.llbElapsedTime.Size = new System.Drawing.Size(70, 14);
            this.llbElapsedTime.TabIndex = 23;
            this.llbElapsedTime.Text = "Elapsed Time";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.RestoreDirectory = true;
            this.openFileDialog.ShowHelp = true;
            this.openFileDialog.SupportMultiDottedExtensions = true;
            // 
            // TbTimer
            // 
            this.TbTimer.BackColor = System.Drawing.SystemColors.Control;
            this.TbTimer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbTimer.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.TbTimer.Location = new System.Drawing.Point(1123, 428);
            this.TbTimer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TbTimer.Name = "TbTimer";
            this.TbTimer.Size = new System.Drawing.Size(95, 13);
            this.TbTimer.TabIndex = 24;
            this.TbTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbCoverFiles
            // 
            this.lbCoverFiles.AutoSize = true;
            this.lbCoverFiles.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lbCoverFiles.Location = new System.Drawing.Point(678, 439);
            this.lbCoverFiles.Name = "lbCoverFiles";
            this.lbCoverFiles.Size = new System.Drawing.Size(82, 15);
            this.lbCoverFiles.TabIndex = 25;
            this.lbCoverFiles.Text = "# Cover Files";
            // 
            // tbCoverFile
            // 
            this.tbCoverFile.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbCoverFile.Location = new System.Drawing.Point(771, 436);
            this.tbCoverFile.Name = "tbCoverFile";
            this.tbCoverFile.ReadOnly = true;
            this.tbCoverFile.Size = new System.Drawing.Size(38, 21);
            this.tbCoverFile.TabIndex = 26;
            this.tbCoverFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbNewPidCount
            // 
            this.lbNewPidCount.AutoSize = true;
            this.lbNewPidCount.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lbNewPidCount.Location = new System.Drawing.Point(678, 471);
            this.lbNewPidCount.Name = "lbNewPidCount";
            this.lbNewPidCount.Size = new System.Drawing.Size(73, 15);
            this.lbNewPidCount.TabIndex = 27;
            this.lbNewPidCount.Text = "# New PIDs";
            // 
            // tbNewPid
            // 
            this.tbNewPid.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbNewPid.Location = new System.Drawing.Point(771, 467);
            this.tbNewPid.Name = "tbNewPid";
            this.tbNewPid.ReadOnly = true;
            this.tbNewPid.Size = new System.Drawing.Size(38, 21);
            this.tbNewPid.TabIndex = 28;
            this.tbNewPid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtUpdPid
            // 
            this.BtUpdPid.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtUpdPid.Location = new System.Drawing.Point(964, 24);
            this.BtUpdPid.Name = "BtUpdPid";
            this.BtUpdPid.Size = new System.Drawing.Size(160, 23);
            this.BtUpdPid.TabIndex = 29;
            this.BtUpdPid.Text = "Update New PIDs - PCodes";
            this.BtUpdPid.UseVisualStyleBackColor = true;
            this.BtUpdPid.Visible = false;
            this.BtUpdPid.Click += new System.EventHandler(this.BtUpdPid_Click);
            // 
            // lblCurrentFile
            // 
            this.lblCurrentFile.BackColor = System.Drawing.SystemColors.Window;
            this.lblCurrentFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCurrentFile.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentFile.Location = new System.Drawing.Point(119, 25);
            this.lblCurrentFile.Name = "lblCurrentFile";
            this.lblCurrentFile.Size = new System.Drawing.Size(581, 20);
            this.lblCurrentFile.TabIndex = 30;
            this.lblCurrentFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtExportToExcel
            // 
            this.BtExportToExcel.Location = new System.Drawing.Point(834, 51);
            this.BtExportToExcel.Name = "BtExportToExcel";
            this.BtExportToExcel.Size = new System.Drawing.Size(125, 23);
            this.BtExportToExcel.TabIndex = 31;
            this.BtExportToExcel.Text = "Export List to Excel";
            this.BtExportToExcel.UseVisualStyleBackColor = true;
            this.BtExportToExcel.Visible = false;
            this.BtExportToExcel.Click += new System.EventHandler(this.BtExportToExcel_Click);
            // 
            // lbPcodesLoaded
            // 
            this.lbPcodesLoaded.AutoSize = true;
            this.lbPcodesLoaded.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lbPcodesLoaded.Location = new System.Drawing.Point(489, 55);
            this.lbPcodesLoaded.Name = "lbPcodesLoaded";
            this.lbPcodesLoaded.Size = new System.Drawing.Size(107, 15);
            this.lbPcodesLoaded.TabIndex = 32;
            this.lbPcodesLoaded.Text = "# PCodes Loaded";
            // 
            // tbPcodesLoaded
            // 
            this.tbPcodesLoaded.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPcodesLoaded.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbPcodesLoaded.Location = new System.Drawing.Point(611, 53);
            this.tbPcodesLoaded.Name = "tbPcodesLoaded";
            this.tbPcodesLoaded.ReadOnly = true;
            this.tbPcodesLoaded.Size = new System.Drawing.Size(52, 14);
            this.tbPcodesLoaded.TabIndex = 33;
            this.tbPcodesLoaded.TabStop = false;
            this.tbPcodesLoaded.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GatherExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 514);
            this.Controls.Add(this.tbPcodesLoaded);
            this.Controls.Add(this.lbPcodesLoaded);
            this.Controls.Add(this.BtExportToExcel);
            this.Controls.Add(this.lblCurrentFile);
            this.Controls.Add(this.BtUpdPid);
            this.Controls.Add(this.tbNewPid);
            this.Controls.Add(this.lbNewPidCount);
            this.Controls.Add(this.tbCoverFile);
            this.Controls.Add(this.lbCoverFiles);
            this.Controls.Add(this.TbTimer);
            this.Controls.Add(this.llbElapsedTime);
            this.Controls.Add(this.lbCurrentFile);
            this.Controls.Add(this.tbSupTotal);
            this.Controls.Add(this.tbCurrentPayout);
            this.Controls.Add(this.tbReportedTotal);
            this.Controls.Add(this.tbProcessedPayouts);
            this.Controls.Add(this.tbRecsProc);
            this.Controls.Add(this.tbFilesRejected);
            this.Controls.Add(this.tbFilesProc);
            this.Controls.Add(this.tbTotalFiles);
            this.Controls.Add(this.LbTotalPayoutCurrent);
            this.Controls.Add(this.LbCurrentPayout);
            this.Controls.Add(this.LbAllFiles);
            this.Controls.Add(this.LbReportedTotal);
            this.Controls.Add(this.LbProcessedPayouts);
            this.Controls.Add(this.LbRecsProcessed);
            this.Controls.Add(this.LbFilesRejected);
            this.Controls.Add(this.LbFilesProcessed);
            this.Controls.Add(this.LbFileNumber);
            this.Controls.Add(this.LVList);
            this.Controls.Add(this.BtExportMySQL);
            this.Controls.Add(this.BtQuit);
            this.Controls.Add(this.LbFile);
            this.Controls.Add(this.BtGetFile);
            this.Name = "GatherExcel";
            this.Text = "IBM Royalty Processing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtGetFile;
        private System.Windows.Forms.Label LbFile;
        private System.Windows.Forms.Button BtQuit;
        private System.Windows.Forms.Button BtExportMySQL;
        public System.Windows.Forms.ListView LVList;
        private System.Windows.Forms.ColumnHeader unq_x;
        private System.Windows.Forms.ColumnHeader period_date;
        private System.Windows.Forms.ColumnHeader contract;
        private System.Windows.Forms.ColumnHeader prod;
        private System.Windows.Forms.ColumnHeader prod_desc;
        private System.Windows.Forms.ColumnHeader act_type;
        private System.Windows.Forms.ColumnHeader geo_code;
        private System.Windows.Forms.ColumnHeader country;
        private System.Windows.Forms.ColumnHeader sales_rev;
        private System.Windows.Forms.ColumnHeader royalty_pct;
        private System.Windows.Forms.ColumnHeader royalty_amt;
        private System.Windows.Forms.ColumnHeader upd_date;
        private System.Windows.Forms.ColumnHeader file_ref;
        private System.Windows.Forms.Label LbFileNumber;
        private System.Windows.Forms.Label LbFilesProcessed;
        private System.Windows.Forms.Label LbFilesRejected;
        private System.Windows.Forms.Label LbRecsProcessed;
        private System.Windows.Forms.Label LbProcessedPayouts;
        private System.Windows.Forms.Label LbReportedTotal;
        private System.Windows.Forms.Label LbAllFiles;
        private System.Windows.Forms.Label LbCurrentPayout;
        private System.Windows.Forms.Label LbTotalPayoutCurrent;
        private System.Windows.Forms.TextBox tbTotalFiles;
        public System.Windows.Forms.TextBox tbFilesProc;
        public System.Windows.Forms.TextBox tbFilesRejected;
        public System.Windows.Forms.TextBox tbRecsProc;
        public System.Windows.Forms.TextBox tbReportedTotal;
        public System.Windows.Forms.TextBox tbProcessedPayouts;
        public System.Windows.Forms.TextBox tbCurrentPayout;
        public System.Windows.Forms.TextBox tbSupTotal;
        private System.Windows.Forms.Label lbCurrentFile;
        private System.Windows.Forms.Label llbElapsedTime;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Timer timer;
        public System.Windows.Forms.TextBox TbTimer;
        public static System.Windows.Forms.ProgressBar progBar;
        private System.Windows.Forms.ColumnHeader stm_date;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label lbCoverFiles;
        private System.Windows.Forms.TextBox tbCoverFile;
        private System.Windows.Forms.Label lbNewPidCount;
        private System.Windows.Forms.TextBox tbNewPid;
        private System.Windows.Forms.Button BtUpdPid;
        private System.Windows.Forms.Label lblCurrentFile;
        private System.Windows.Forms.Button BtExportToExcel;
        private System.Windows.Forms.Label lbPcodesLoaded;
        private System.Windows.Forms.TextBox tbPcodesLoaded;
    }
}

