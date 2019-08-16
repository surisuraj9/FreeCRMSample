using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;
using FreeCRMSample.testbase;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;

namespace FreeCRMSample.util
{
    public class TestUtil : TestBase
    {
        public static long PAGE_LOAD_TIMEOUT = 60;
        public static long IMPLICIT_WAIT = 60;
        public static String TESTDATA_SHEET_PATH = "FreeCRMCsharp/FreeCRMCsharp/resources/FreeCRMTestData.xlsx";
        static Excel.Application exapp = new Excel.Application();

        static Excel.Workbook book;
        static Excel.Worksheet sheet;
        static Excel.Range range;

        public void switchToFrame()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//frame[@name='mainpanel']")));
        }
        static Object[][] data;
        public static object[][] GetTestData(int sheetNo)
        {
            book = exapp.Workbooks.Open(@TESTDATA_SHEET_PATH);
            sheet = (Excel.Worksheet)exapp.Sheets[sheetNo];
            range = sheet.UsedRange;
            for (int xlRowCnt = 0; xlRowCnt < range.Rows.Count; xlRowCnt++)
            {
                for (int xlColCnt = 0; xlColCnt < range.Columns.Count; xlColCnt++)
                {
                    data[xlRowCnt][xlColCnt] = range.Cells[xlRowCnt + 1, xlColCnt];
                    Console.WriteLine(data[xlRowCnt][xlColCnt]);
                }
            }
            return data;
        }
        public static void TakeScreenshotAtEndOfTest(String scenario)
        {
            if (scenario != null)
            {
                string Runname = scenario + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
                Screenshot scrFile = ((ITakesScreenshot)driver).GetScreenshot();
                scrFile.SaveAsFile(@"\FreeCRMCsharp\screenshots\" + Runname + ".png",ScreenshotImageFormat.Png);

            }
        }
    }
}
