using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Font = System.Drawing.Font;

namespace IBM_Statement_Processing
{
    public partial class PidUpd : Form
    {
        private static int pd;
        public string newPcode;
        public string prodType;
        public List<MatchDataClass> matchlist = new List<MatchDataClass>();
        public List<ProdDataClass> xinplist = new List<ProdDataClass>();

        public PidUpd()
        {
            InitializeComponent();
            Loadcurpcode();
            pd = 0;
            AddNewPidData(pd);
        }

        // Displaying the possible matches & assigning a score

        public void DispPossMatchs(string newProd)
        {
            List<ProdDataClass> xlist = xinplist.GroupBy(d => new { d.Prodx, d.Pcodex })
                .Select(d => d.First())
                .ToList();
            matchlist.Clear();
            var strn1 = newProd;

            foreach (var lind in xlist)
            {
                int msx;
                if (strn1 == lind.Prodx)
                {
                    msx = 100;
                }
                else
                {
                    //   MessageBox.Show("? Match Product : " + lind.Prodx.ToString());
                    var ms2 = strn1.ToLower().ScoreMatch(lind.Prodx.ToLower()) * 100;
                    msx = (int)ms2;
                }

                matchlist.Add(new MatchDataClass() { Prodm = lind.Prodx, Pcodem = lind.Pcodex, Scorem = msx });
            }
            // Sorting of the matching product descriptions in reverse order
            matchlist.Sort();
            matchlist.Reverse();

            // Outputting products to listview
            foreach (var mind in matchlist.Take(20))

            {
                lvExtProdPcode.Items.Add(new ListViewItem(new[] { mind.Prodm, mind.Pcodem }));
            }
        }

        public void AddNewPidData(int pd)
        {
            label1.Text = GatherExcel.newpids.Rows[pd][0].ToString();
            label2.Text = GatherExcel.newpids.Rows[pd][1].ToString();
            var srchProdName = GatherExcel.newpids.Rows[pd][1].ToString().ToUpper();
            lvExtProdPcode.Visible = true;
            DispPossMatchs(srchProdName);

            prodType = null;
            CbProdType.ResetText();
            lbPcodeInstr.Font = new Font(lbPcodeInstr.Font, FontStyle.Regular);
            lbProdTypeSelect.Visible = false;
            TbRocketPcode.Clear();
            TbRocketPcode.Select();
            if (srchProdName.Contains("LIC"))
            {
                CbProdType.SelectedIndex = 0;
            }
            else
            if (srchProdName.Contains("SS") || srchProdName.Contains("S&S") || srchProdName.Contains("MAINT"))
            {
                CbProdType.SelectedIndex = 1;
            }
            else
            if (srchProdName.Contains("SOLU") || srchProdName.Contains("SUITE"))
            {
                CbProdType.SelectedIndex = 2;
            }
            else
            if (srchProdName.Contains("SUB"))
            {
                CbProdType.SelectedIndex = 3;
            }
        }

        private void BtSubmitPid_Click(object sender, EventArgs e)
        {
            if (pd <= GatherExcel.newpids.Rows.Count - 1)
            {
                if (!String.IsNullOrEmpty(TbRocketPcode.Text) &&
                    int.Parse(TbRocketPcode.Text) >= 1000 &&
                    int.Parse(TbRocketPcode.Text) <= 9999 &&
                    !String.IsNullOrEmpty(prodType))

                {
                    newPcode = TbRocketPcode.Text;
                    if (Dispx())
                    {
                        GatherExcel.newpids.Rows[pd][2] = prodType;
                        GatherExcel.newpids.Rows[pd][3] = "P" + newPcode;
                        GatherExcel.newpids.AcceptChanges();
                        // MessageBox.Show("New PCode :" + GatherExcel.newpids.Rows[pd][2]);
                        // dispx();
                        pd++;
                        if (pd < GatherExcel.newpids.Rows.Count)
                        {
                            lvExtProdPcode.Items.Clear();
                            AddNewPidData(pd);
                        }
                        else
                        {
                            BtSubmitPid.Visible = false;
                            lbNewPid.Visible = false;
                            lbPidDescr.Visible = false;
                            lbPcode.Visible = false;
                            label1.Visible = false;
                            label2.Visible = false;
                            lbPcodeInstr.Visible = false;
                            lbP.Visible = false;
                            TbRocketPcode.Visible = false;
                            lbPidFinish.Visible = true;
                            btUpdPidMySql.Visible = true;
                            CbProdType.Visible = false;
                            lbProdType.Visible = false;
                            lbProdTypeSelect.Visible = false;
                            lvExtProdPcode.Visible = false;
                        }
                    }
                    else
                    {
                        TbRocketPcode.Clear();
                        TbRocketPcode.Select();
                    }
                }
                else
                {
                    lbPcodeInstr.Font = new Font(lbPcodeInstr.Font, FontStyle.Bold);
                    if (prodType == null)
                    {
                        lbProdTypeSelect.Visible = true;
                        lbProdTypeSelect.Font = new Font(lbProdTypeSelect.Font, FontStyle.Bold);
                    }

                    TbRocketPcode.Clear();
                    TbRocketPcode.Select();
                }
            }
        }

        // Confirming update
        private bool Dispx()
        {
            var message = "PID : " + GatherExcel.newpids.Rows[pd][0] +
                          "\nDescription : " + GatherExcel.newpids.Rows[pd][1] +
                          "\nProduct Type : " + prodType +
                          "\nEntered PCode : P" + newPcode +
                          "\n\nContinue with Update ?";
            string title = "Update PID-PCode";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult updPidAnswer = MessageBox.Show(message, title, buttons);

            if (updPidAnswer == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Outputting data to MySQL table
        private void BtUpdPidMySql_Click(object sender, EventArgs e)
        {
            var goodInsert = "Records inserted into MySQL = ";
            var rejectInsert = "\nRecords Rejected by MySQL = ";
            int recsMySql = 0;
            int recsRejectedMySql = 0;

            MySqlConnection dbConn =
                new MySqlConnection("datasource=walstgpimcore01;port=3306;username=statement_processing;password=8Ibm161952!;database=ibm_statement");

            dbConn.Open();

            var onDup =
                "on duplicate key update pid_description = new.pid_description,lic_maint = new.lic_maint,pcode = new.pcode,upd_date = new.upd_date ";

            var updDate = DateTime.Now.ToString("yyyy-MM-dd");

            for (int ix = 0; ix < GatherExcel.newpids.Rows.Count; ix++)
            {
                var iQ = new StringBuilder(
                    "insert into statement_pid_pcode (pid, pid_description, lic_maint, pcode, upd_date) values(");
                for (int jx = 0; jx < GatherExcel.newpids.Columns.Count; jx++)
                {
                    string lv2 = "\"" + GatherExcel.newpids.Rows[ix].ItemArray[jx] + "\",";
                    iQ.Append(lv2);
                }

                iQ.Append("\"" + updDate + "\") as new " + onDup);

                // MessageBox.Show(iQ.ToString());

                var insertRec = new MySqlCommand(iQ.ToString(), dbConn);
                try
                {
                    if (insertRec.ExecuteNonQuery() == 1)
                        recsMySql += 1;
                    else
                    {
                        recsRejectedMySql += 1;
                        // File.AppendAllText(SqlRejectFile, item.SqlSm + Environment.NewLine);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            dbConn.Close();
            MessageBox.Show(goodInsert + recsMySql.ToString("n0") +
                            rejectInsert + recsRejectedMySql.ToString("n0"));
        }

        private void CbProdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            prodType = CbProdType.Text;
            lbProdTypeSelect.Visible = false;
        }

        private void Loadcurpcode()
        {
            for (int i = 0; i < GatherExcel.existingpcodes.Rows.Count; i++)
            {
                var prodName = GatherExcel.existingpcodes.Rows[i][2].ToString().ToUpper();
                var prodPcode = GatherExcel.existingpcodes.Rows[i][1].ToString();

                if (prodPcode.Length == 5)
                {
                    xinplist.Add(new ProdDataClass { Prodx = prodName, Pcodex = prodPcode });
                }
            }
        }
    }

    // Matching of product descriptions
    public static class LocateMatchScore
    {
        private struct MatchWork
        {
            public int Matches;
            public int Transpositions;
        }

        private static MatchWork Matches(string s1, string s2)
        {
            string text;
            string text2;
            if (s1.Length > s2.Length)
            {
                text = s1;
                text2 = s2;
            }
            else
            {
                text = s2;
                text2 = s1;
            }
            int num = Math.Max(text.Length / 2 - 1, 0);
            int[] array = new int[text2.Length];
            int i;
            for (i = 0; i < array.Length; i++)
            {
                array[i] = -1;
            }
            bool[] array2 = new bool[text.Length];
            int num2 = 0;
            for (int j = 0; j < text2.Length; j++)
            {
                char c = text2[j];
                int k = Math.Max(j - num, 0);
                int num3 = Math.Min(j + num + 1, text.Length);
                while (k < num3)
                {
                    if (!array2[k] && c == text[k])
                    {
                        array[j] = k;
                        array2[k] = true;
                        num2++;
                        break;
                    }
                    k++;
                }
            }
            char[] array3 = new char[num2];
            char[] ms2 = new char[num2];
            i = 0;
            int num4 = 0;
            while (i < text2.Length)
            {
                if (array[i] != -1)
                {
                    array3[num4] = text2[i];
                    num4++;
                }
                i++;
            }
            i = 0;
            num4 = 0;
            while (i < text.Length)
            {
                if (array2[i])
                {
                    ms2[num4] = text[i];
                    num4++;
                }
                i++;
            }
            int num5 = array3.Where((t, mi) => t != ms2[mi]).Count();
            MatchWork result;
            result.Matches = num2;
            result.Transpositions = num5 / 2;
            return result;
        }

        public static float ScoreMatch(this string s1, string s2)
        {
            var matchScore = LocateMatchScore.Matches(s1, s2);
            float num = matchScore.Matches;
            int transpositions = matchScore.Transpositions;
            float result;
            if (num == 0f)
            {
                result = 0f;
            }
            else
            {
                float num2 = (num / s1.Length + num / s2.Length + (num - transpositions) / num) / 3f;
                result = num2;
            }
            return result;
        }
    }

    public class ProdDataClass
    {
        public string Pcodex { get; set; }
        public string Prodx { get; set; }
    }

    public class MatchDataClass : IComparable<MatchDataClass>
    {
        public string Prodm { get; set; }
        public string Pcodem { get; set; }
        public int Scorem { get; set; }

        public int CompareTo(MatchDataClass other)
        {
            return this.Scorem.CompareTo(other.Scorem);
        }
    }
}