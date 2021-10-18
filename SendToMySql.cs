using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace IBM_Statement_Processing
{
    public class SendToMySql : GatherExcel
    {
        public static void UpdatingMySql(int statementCnt, int coverCnt, string statementCsv, string coverCsv)
        {
            var goodInsertStatement = "IBM Statement Records inserted into MySQL = ";
            var goodInsertCover = "IBM Cover Records inserted into MySQL = ";
            MySqlConnection dbConn =
                new MySqlConnection("datasource=walstgpimcore01;port=3306;username=statement_processing;password=8Ibm161952!;database=ibm_statement;AllowLoadLocalInfile=true;");

            dbConn.Open();

            var statementCount = statementCnt;
            var coverCount = coverCnt;

            if (statementCount > 0)
            {
                string file = statementCsv;
                MySqlBulkLoader bl = new MySqlBulkLoader(dbConn)
                {
                    Local = true,
                    TableName = "ibm_statement.statement_raw",
                    FieldTerminator = ",",
                    FieldQuotationCharacter = '"',
                    LineTerminator = "\n",
                    FileName = file
                };

                try
                {
                    //MessageBox.Show("Connecting to MySQL...");

                    // Upload data from file
                    int recsMySql = bl.Load();

                    MessageBox.Show(goodInsertStatement + recsMySql.ToString("n0"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            if (coverCount > 0)
            {
                string cfile = coverCsv;

                MySqlBulkLoader bl2 = new MySqlBulkLoader(dbConn)
                {
                    Local = true,
                    TableName = "ibm_statement.cover_raw",
                    FieldTerminator = ",",
                    FieldQuotationCharacter = '"',
                    LineTerminator = "\n",
                    FileName = cfile
                };

                try
                {
                    // Upload data from file
                    int recsMySql2 = bl2.Load();

                    MessageBox.Show(goodInsertCover + recsMySql2.ToString("n0"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            MySqlCommand updProc = new MySqlCommand
            {
                Connection = dbConn,
                CommandText = "update_essbase_table",
                CommandType = CommandType.StoredProcedure
            };
            updProc.ExecuteNonQuery();
            dbConn.Close();
        }
    }
}