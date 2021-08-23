using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace TestNPOI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //CalendarDemo.Test(args);
                var xlsx = new MyXlsxTest();
                var fileName = $@"c:\tmp\MyXlsxTest.{Process.GetCurrentProcess().Id}.xlsx";
                xlsx.Save(fileName);
                //Process.Start(fileName);
                //Process.Start(@"C:\Program Files (x86)\Microsoft Office\root\Office16\EXCEL.EXE", fileName);

                new Process
                {
                    StartInfo = new ProcessStartInfo(fileName)
                    {
                        UseShellExecute = true
                    }
                }.Start();
            }
            catch (Exception e) 
            { 
                Console.WriteLine(e); 
            }
        }
    }
}
