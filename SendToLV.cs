using System;
using System.Data;
using System.Windows.Forms;

namespace IBM_Statement_Processing
{
    public class SendToLv
    {
        public static void CopyDataTableToListView(DataTable dt, ListView lv)
        {
            var lvCount = Math.Min(201 - lv.Items.Count, dt.Rows.Count);
            for (int ix = 0; ix < lvCount; ix++)
            {
                string lv1 = dt.Rows[ix].ItemArray[0].ToString();
                var lvitem = lv.Items.Add(lv1);
                for (int jx = 1; jx < dt.Columns.Count; jx++)
                {
                    string lv2;
                    if (jx == 9 || jx == 11)
                    {
                        double lv2X = (double)dt.Rows[ix].ItemArray[jx];
                        lv2 = lv2X.ToString("#,##0.00");
                    }
                    else
                    {
                        lv2 = dt.Rows[ix].ItemArray[jx].ToString();
                    }

                    lvitem.SubItems.AddRange(new[] { lv2 });
                }
            }
        }
    }
}