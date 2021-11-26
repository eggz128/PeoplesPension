using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using LumenWorks.Framework.IO.Csv;
using System.Reflection;
using System.IO;

namespace com.edgewords.webdrivertest.Utils
{
    public static class HelperLib
    {
        //To access class static methods we dont need to initalise the class first - e.g. HelperLib myhelp = new HelperLib(); is not needed
        //(That can be a perfectly valid thing to want to do though)
        public static void waitforelement(IWebDriver driver, int SecondsToWait, By locator)
        {
            WebDriverWait mysecondwait = new WebDriverWait(driver, TimeSpan.FromSeconds(SecondsToWait));
            mysecondwait.Until(drv => drv.FindElement(locator).Displayed); //The register link isnt on the Add Record "logged in" page, but is on the "login" page, so we can wait for that

        }

        public static void takescreenshot(IWebDriver driver, string filename)
        {
            ITakesScreenshot ssdriver = driver as ITakesScreenshot;
            Screenshot myscreenshot = ssdriver.GetScreenshot();
            myscreenshot.SaveAsFile(@"c:\pictures\" + filename + ".png", ScreenshotImageFormat.Png);
        }

        public static void takescreenshotofelement(IWebDriver driver, By locator, string filename)
        {
            IWebElement elm = driver.FindElement(locator);
            ITakesScreenshot sselm = elm as ITakesScreenshot;
            Screenshot myscreenshot = sselm.GetScreenshot();
            
            myscreenshot.SaveAsFile(@"c:\pictures\" + filename + ".png", ScreenshotImageFormat.Png);
        }
        //This method returns "Steve"
        //call it from a test that uses this class like so:
        //Console.WriteLine(SayMyName());
        public static string SayMyName()
        {
            return "Steve";
        }

        public static IEnumerable<string[]> GetTestData()
        {
            //Make a string that specifies where the csv file is. To find it reflection is used to figure out where the currently running dll is -- the csv file is in the same directory
            var csvFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase) + "\\Data.csv";
            csvFile = new Uri(csvFile).LocalPath; //Convert the string to a path object

            using (var csv = new CsvReader(new StreamReader(csvFile), true)) //read the csv file, ignore the header row
            {
                while (csv.ReadNextRecord()) //while there is another row to read (i.e. end of file not reached)
                {
                    string data1 = csv[0]; //Get the data and put it in to a string
                    string data2 = csv[1];
                    yield return new[] { data1, data2 }; //combine the strings in to an array
                } //run again if not at end of file. Ultimately hands back a list of string arrays - like the NUnit data driven code wants
            }
        }
    }
}
