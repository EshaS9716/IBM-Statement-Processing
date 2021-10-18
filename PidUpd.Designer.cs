
namespace IBM_Statement_Processing
{
    partial class PidUpd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtSubmitPid = new System.Windows.Forms.Button();
            this.lbNewPid = new System.Windows.Forms.Label();
            this.lbPidDescr = new System.Windows.Forms.Label();
            this.lbPcode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbPcodeInstr = new System.Windows.Forms.Label();
            this.lbP = new System.Windows.Forms.Label();
            this.TbRocketPcode = new System.Windows.Forms.MaskedTextBox();
            this.lbPidFinish = new System.Windows.Forms.Label();
            this.btUpdPidMySql = new System.Windows.Forms.Button();
            this.lbProdType = new System.Windows.Forms.Label();
            this.CbProdType = new System.Windows.Forms.ComboBox();
            this.lbProdTypeSelect = new System.Windows.Forms.Label();
            this.lvExtProdPcode = new System.Windows.Forms.ListView();
            this.lvExtProd = new System.Windows.Forms.ColumnHeader();
            this.lvExtPcode = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // BtSubmitPid
            // 
            this.BtSubmitPid.Location = new System.Drawing.Point(173, 182);
            this.BtSubmitPid.Name = "BtSubmitPid";
            this.BtSubmitPid.Size = new System.Drawing.Size(106, 38);
            this.BtSubmitPid.TabIndex = 3;
            this.BtSubmitPid.Text = "Submit";
            this.BtSubmitPid.UseVisualStyleBackColor = true;
            this.BtSubmitPid.Click += new System.EventHandler(this.BtSubmitPid_Click);
            // 
            // lbNewPid
            // 
            this.lbNewPid.AutoSize = true;
            this.lbNewPid.Location = new System.Drawing.Point(31, 19);
            this.lbNewPid.Name = "lbNewPid";
            this.lbNewPid.Size = new System.Drawing.Size(49, 15);
            this.lbNewPid.TabIndex = 4;
            this.lbNewPid.Text = "IBM PID";
            // 
            // lbPidDescr
            // 
            this.lbPidDescr.AutoSize = true;
            this.lbPidDescr.Location = new System.Drawing.Point(31, 54);
            this.lbPidDescr.Name = "lbPidDescr";
            this.lbPidDescr.Size = new System.Drawing.Size(88, 15);
            this.lbPidDescr.TabIndex = 5;
            this.lbPidDescr.Text = "PID Description";
            // 
            // lbPcode
            // 
            this.lbPcode.AutoSize = true;
            this.lbPcode.Location = new System.Drawing.Point(31, 124);
            this.lbPcode.Name = "lbPcode";
            this.lbPcode.Size = new System.Drawing.Size(42, 15);
            this.lbPcode.TabIndex = 6;
            this.lbPcode.Text = "PCode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "PID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "PID Description";
            // 
            // lbPcodeInstr
            // 
            this.lbPcodeInstr.AutoSize = true;
            this.lbPcodeInstr.Location = new System.Drawing.Point(243, 124);
            this.lbPcodeInstr.Name = "lbPcodeInstr";
            this.lbPcodeInstr.Size = new System.Drawing.Size(169, 15);
            this.lbPcodeInstr.TabIndex = 10;
            this.lbPcodeInstr.Text = "Enter # Between 1000 and 9999";
            // 
            // lbP
            // 
            this.lbP.AutoSize = true;
            this.lbP.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbP.Location = new System.Drawing.Point(116, 120);
            this.lbP.Name = "lbP";
            this.lbP.Size = new System.Drawing.Size(23, 22);
            this.lbP.TabIndex = 11;
            this.lbP.Text = "P";
            // 
            // TbRocketPcode
            // 
            this.TbRocketPcode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TbRocketPcode.Location = new System.Drawing.Point(137, 118);
            this.TbRocketPcode.Mask = "0000";
            this.TbRocketPcode.Name = "TbRocketPcode";
            this.TbRocketPcode.PromptChar = ' ';
            this.TbRocketPcode.RejectInputOnFirstFailure = true;
            this.TbRocketPcode.Size = new System.Drawing.Size(63, 26);
            this.TbRocketPcode.TabIndex = 2;
            this.TbRocketPcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbPidFinish
            // 
            this.lbPidFinish.AutoSize = true;
            this.lbPidFinish.Font = new System.Drawing.Font("Arial", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lbPidFinish.Location = new System.Drawing.Point(115, 153);
            this.lbPidFinish.Name = "lbPidFinish";
            this.lbPidFinish.Size = new System.Drawing.Size(210, 23);
            this.lbPidFinish.TabIndex = 13;
            this.lbPidFinish.Text = "PID Updates Finished";
            this.lbPidFinish.Visible = false;
            // 
            // btUpdPidMySql
            // 
            this.btUpdPidMySql.Location = new System.Drawing.Point(127, 226);
            this.btUpdPidMySql.Name = "btUpdPidMySql";
            this.btUpdPidMySql.Size = new System.Drawing.Size(185, 23);
            this.btUpdPidMySql.TabIndex = 14;
            this.btUpdPidMySql.Text = "Send PID Updates to MySQL";
            this.btUpdPidMySql.UseVisualStyleBackColor = true;
            this.btUpdPidMySql.Visible = false;
            this.btUpdPidMySql.Click += new System.EventHandler(this.BtUpdPidMySql_Click);
            // 
            // lbProdType
            // 
            this.lbProdType.AutoSize = true;
            this.lbProdType.Location = new System.Drawing.Point(31, 89);
            this.lbProdType.Name = "lbProdType";
            this.lbProdType.Size = new System.Drawing.Size(76, 15);
            this.lbProdType.TabIndex = 15;
            this.lbProdType.Text = "Product Type";
            // 
            // CbProdType
            // 
            this.CbProdType.FormattingEnabled = true;
            this.CbProdType.Items.AddRange(new object[] {
            "License",
            "Maintenance",
            "Solution Pack",
            "Subscription"});
            this.CbProdType.Location = new System.Drawing.Point(137, 85);
            this.CbProdType.Name = "CbProdType";
            this.CbProdType.Size = new System.Drawing.Size(100, 23);
            this.CbProdType.TabIndex = 1;
            this.CbProdType.SelectedIndexChanged += new System.EventHandler(this.CbProdType_SelectedIndexChanged);
            // 
            // lbProdTypeSelect
            // 
            this.lbProdTypeSelect.AutoSize = true;
            this.lbProdTypeSelect.Location = new System.Drawing.Point(243, 89);
            this.lbProdTypeSelect.Name = "lbProdTypeSelect";
            this.lbProdTypeSelect.Size = new System.Drawing.Size(110, 15);
            this.lbProdTypeSelect.TabIndex = 17;
            this.lbProdTypeSelect.Text = "Select Product Type\r\n";
            this.lbProdTypeSelect.Visible = false;
            // 
            // lvExtProdPcode
            // 
            this.lvExtProdPcode.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvExtProd,
            this.lvExtPcode});
            this.lvExtProdPcode.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lvExtProdPcode.FullRowSelect = true;
            this.lvExtProdPcode.GridLines = true;
            this.lvExtProdPcode.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvExtProdPcode.HideSelection = false;
            this.lvExtProdPcode.Location = new System.Drawing.Point(31, 226);
            this.lvExtProdPcode.Name = "lvExtProdPcode";
            this.lvExtProdPcode.Size = new System.Drawing.Size(381, 126);
            this.lvExtProdPcode.TabIndex = 18;
            this.lvExtProdPcode.UseCompatibleStateImageBehavior = false;
            this.lvExtProdPcode.View = System.Windows.Forms.View.Details;
            this.lvExtProdPcode.Visible = false;
            // 
            // lvExtProd
            // 
            this.lvExtProd.Name = "lvExtProd";
            this.lvExtProd.Text = "Existing Product";
            this.lvExtProd.Width = 325;
            // 
            // lvExtPcode
            // 
            this.lvExtPcode.Name = "lvExtPcode";
            this.lvExtPcode.Text = "PCode";
            this.lvExtPcode.Width = 50;
            // 
            // PidUpd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 356);
            this.Controls.Add(this.lvExtProdPcode);
            this.Controls.Add(this.lbProdTypeSelect);
            this.Controls.Add(this.CbProdType);
            this.Controls.Add(this.lbProdType);
            this.Controls.Add(this.btUpdPidMySql);
            this.Controls.Add(this.lbPidFinish);
            this.Controls.Add(this.TbRocketPcode);
            this.Controls.Add(this.lbP);
            this.Controls.Add(this.lbPcodeInstr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbPcode);
            this.Controls.Add(this.lbPidDescr);
            this.Controls.Add(this.lbNewPid);
            this.Controls.Add(this.BtSubmitPid);
            this.Name = "PidUpd";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtSubmitPid;
        private System.Windows.Forms.Label lbNewPid;
        private System.Windows.Forms.Label lbPidDescr;
        private System.Windows.Forms.Label lbPcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbPcodeInstr;
        private System.Windows.Forms.Label lbP;
        private System.Windows.Forms.MaskedTextBox TbRocketPcode;
        private System.Windows.Forms.Label lbPidFinish;
        private System.Windows.Forms.Button btUpdPidMySql;
        private System.Windows.Forms.Label lbProdType;
        private System.Windows.Forms.ComboBox CbProdType;
        private System.Windows.Forms.Label lbProdTypeSelect;
        private System.Windows.Forms.ListView lvExtProdPcode;
        private System.Windows.Forms.ColumnHeader lvExtProd;
        private System.Windows.Forms.ColumnHeader lvExtPcode;
    }
}