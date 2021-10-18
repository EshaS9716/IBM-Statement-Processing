using MySql.Data.MySqlClient;
using DataTable = System.Data.DataTable;

namespace IBM_Statement_Processing
{
    public class GetMySqlData
    {
        public static void MySqlFillData(DataTable dataTable, int dselx)
        {
            MySqlConnection dbConn =
                new MySqlConnection(
                    "datasource=walstgpimcore01;port=3306;database=ibm_statement;username=statement_processing;password=8Ibm161952!;database=ibm_statement");
            var sqlPcode1 = "select pid, pcode, pid_description, lic_maint from ibm_statement.statement_pid_pcode";
            var sqlPcode2 = "select pid, pcode, pid_description, lic_maint from ibm_statement.statement_pid_pcode";

            dbConn.Open();
            if (dselx == 1)
            {
                using var mcd = new MySqlCommand(sqlPcode1, dbConn);
                using var mdr = mcd.ExecuteReader();
                dataTable.Load(mdr);
            }
            if (dselx == 2)
            {
                using var mcd = new MySqlCommand(sqlPcode2, dbConn);
                using var mdr = mcd.ExecuteReader();
                dataTable.Load(mdr);
            }
        }
    }
}