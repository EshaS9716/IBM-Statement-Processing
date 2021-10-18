using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using DataTable = System.Data.DataTable;
using Excel = Microsoft.Office.Interop.Excel;
using Sheets = DocumentFormat.OpenXml.Spreadsheet.Sheets;
using Workbook = DocumentFormat.OpenXml.Spreadsheet.Workbook;
using Worksheet = DocumentFormat.OpenXml.Spreadsheet.Worksheet;

namespace IBM_Statement_Processing
{
    public class SendToEssbase
    {
        private static readonly DataTable essbaseTable = new DataTable();

        public static void CopyDataTableToExcel(string excelPath)
        {
            SetEssbaseDataTable();
            var dt = essbaseTable;
            using SpreadsheetDocument document = SpreadsheetDocument.Create(excelPath, SpreadsheetDocumentType.Workbook);
            WorkbookPart workbookPart = document.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();

            WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            var sheetData = new SheetData();
            worksheetPart.Worksheet = new Worksheet(sheetData);

            Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
            Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "ESEBase_Royalty_New" };

            sheets.Append(sheet);

            Row headerRow = new Row();

            List<String> columns = new List<string>();
            foreach (System.Data.DataColumn column in dt.Columns)
            {
                columns.Add(column.ColumnName);

                Cell cell = new Cell { DataType = CellValues.String, CellValue = new CellValue(column.ColumnName) };
                headerRow.AppendChild(cell);
            }

            sheetData.AppendChild(headerRow);

            foreach (DataRow dsrow in dt.Rows)
            {
                Row newRow = new Row();
                foreach (String col in columns)
                {
                    if (col == "Sales_US" || col == "Royalty_Pct" || col == "Royalty_Amt" || col == "Sales_Units" || col == "Royalty_Rate_Amt" || col == "Country")
                    {
                        Cell cell = new Cell
                        {
                            DataType = CellValues.Number,
                            CellValue = new CellValue(dsrow[col].ToString())
                        };
                        newRow.AppendChild(cell);
                    }
                    else
                    {
                        Cell cell = new Cell
                        {
                            DataType = CellValues.String,
                            CellValue = new CellValue(dsrow[col].ToString())
                        };
                        newRow.AppendChild(cell);
                    }
                }

                sheetData.AppendChild(newRow);
            }

            workbookPart.Workbook.Save();
        }

        public static void SetEssbaseDataTable()
        {
            SetEssbaseDataTableColumns();
            MySqlConnection dbConn =
                new MySqlConnection(
                    "datasource=walstgpimcore01;port=3306;database=ibm_statement;username=statement_processing;password=8Ibm161952!;database=ibm_statement");

            var sqlEssbase = "Select * from ibm_statement.statement_essbase_output";
            dbConn.Open();

            using var mcd = new MySqlCommand(sqlEssbase, dbConn);
            using var mdr = mcd.ExecuteReader();
            essbaseTable.Load(mdr);
            var rowcnt = essbaseTable.Rows.Count;
            var colcnt = essbaseTable.Columns.Count;
            //   MessageBox.Show("Data Read from MySQL : Rows = " + rowcnt.ToString() + " Collumns = " +
            //                   colcnt.ToString());
        }

        public static void SetAutoColumnWidth(string excelPath)
        {
            var excelFileName = excelPath;

            var xApp = new Excel.Application();
            var essBaseWorkbook = xApp.Workbooks.Open(excelFileName, false, false);
            var essBaseSheet = (Excel.Worksheet)xApp.ActiveSheet;

            xApp.DisplayAlerts = false;

            var xRange = essBaseSheet.UsedRange;
            var lastRow = essBaseSheet.Rows.Count;

            //var rangeOfValues = essBaseSheet.Range["Y2","AC"+lastRow];
            //rangeOfValues.Cells.NumberFormat = "##0.00###";
            //rangeOfValues.Value = rangeOfValues.Value;

            xRange.Columns.AutoFit();
            essBaseSheet.Range["A1"].EntireRow.Font.Bold = true;

            // Marshal.ReleaseComObject(essBaseSheet);
            essBaseWorkbook.Close(true, Type.Missing, Type.Missing);
        }

        public static void SetEssbaseDataTableColumns()
        {
            essbaseTable.Columns.Add("PID", typeof(String));
            essbaseTable.Columns.Add("Product", typeof(String));
            essbaseTable.Columns.Add("Group", typeof(String));
            essbaseTable.Columns.Add("IBM_Brand", typeof(String));
            essbaseTable.Columns.Add("IBM_Sub_Brand", typeof(String));
            essbaseTable.Columns.Add("Platform", typeof(String));
            essbaseTable.Columns.Add("Category", typeof(String));
            essbaseTable.Columns.Add("Type", typeof(String));
            essbaseTable.Columns.Add("Lic_Maint", typeof(String));
            essbaseTable.Columns.Add("Rocket_L4", typeof(String));
            essbaseTable.Columns.Add("Rocket_L5", typeof(String));
            essbaseTable.Columns.Add("Royalty_Contract_Number", typeof(String));
            essbaseTable.Columns.Add("Country", typeof(String));
            essbaseTable.Columns.Add("New_Geo", typeof(String));
            essbaseTable.Columns.Add("Royalty_Country_Description", typeof(String));
            essbaseTable.Columns.Add("Alias", typeof(String));
            essbaseTable.Columns.Add("Source", typeof(String));
            essbaseTable.Columns.Add("Royalty_Source_Description", typeof(String));
            essbaseTable.Columns.Add("PID_Type", typeof(String));
            essbaseTable.Columns.Add("PID_Cat", typeof(String));
            essbaseTable.Columns.Add("IBM_Yr", typeof(String));
            essbaseTable.Columns.Add("IBM_Qtr", typeof(String));
            essbaseTable.Columns.Add("Rocket_Yr", typeof(String));
            essbaseTable.Columns.Add("Rocket_Qtr", typeof(String));
            essbaseTable.Columns.Add("Sales_US", typeof(Double));
            essbaseTable.Columns.Add("Sales_Units", typeof(Double));
            essbaseTable.Columns.Add("Royalty_Pct", typeof(Double));
            essbaseTable.Columns.Add("Royalty_Rate_Amt", typeof(Double));
            essbaseTable.Columns.Add("Royalty_Amt", typeof(Double));
            essbaseTable.Columns.Add("Statement_date", typeof(String));
            essbaseTable.Columns.Add("Update_date", typeof(String));
            essbaseTable.Columns.Add("Status", typeof(String));
        }
    }
}