using NPOI.XSSF.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;

namespace TestNPOI
{
    public class MyXlsxTest
    {
        public MyXlsxTest()
        {

        }

        public void Save(string fileName)
        {
            var wb = new XSSFWorkbook();
            var sheet = wb.CreateSheet("Toto");
            var sheet2 = wb.CreateSheet("Error1");
            var sheet3 = wb.CreateSheet("Error2");

           

            var doubleCellStyle = wb.CreateCellStyle();
            doubleCellStyle.DataFormat = wb.CreateDataFormat().GetFormat("#,##0.00");



            var rnd = new Random();
            var header = sheet.CreateRow(0);
            header.CreateCell(0).SetCellValue("Name");
            header.CreateCell(1).SetCellValue("Value");
           
            for (int i = 0; i < 10; i++)
            {
                var row = sheet.CreateRow(i+1);
                row.CreateCell(0).SetCellValue($"Toto_{i}");
                var cell = row.CreateCell(1);
                cell.SetCellType(CellType.Numeric);
                cell.CellStyle = doubleCellStyle;
                cell.SetCellValue(50000.0*rnd.NextDouble()-25000);
            }

            sheet.SetAutoFilter(new CellRangeAddress(0, 0, 0, 1));

            for (int i = 0; i < 10; i++)
                sheet.AutoSizeColumn(i);


            // Sheet2
            var header2 = sheet2.CreateRow(0);
            header2.CreateCell(0).SetCellValue("XXXX");
            header2.CreateCell(1).SetCellValue("YYYY");

            // Write file
            var out1 = new FileStream(fileName, FileMode.Create);
            wb.Write(out1);
            out1.Close();
        }
    }
}
