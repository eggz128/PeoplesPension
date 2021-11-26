using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Firefox;
using System.IO;
using NUnit.Framework.Interfaces;
using static com.edgewords.webdrivertest.Utils.HelperLib;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;

namespace com.edgewords.webdrivertest.Utils
{
    public class TestBase
    {
        //Fields and methods must be public if other classes are to be allowed to call in
        //In particular, Test SetUp and TearDown methods must be public to allow the test runner (NUnit) to find them

        public IWebDriver driver;
        public string baseurl = "https://www.google.com/";
        public string baseurl2 = "http://google.com";


        [SetUp]
        public void SetUp() //Method name not important - the annotation above is!
        {

            //string browser = TestContext.Parameters["browser"];

            string browser = Environment.GetEnvironmentVariable("BrowserEnv");
            browser = browser.Replace("\"", "").Trim();
            Console.WriteLine("The browser chosen was: " + browser);

            if (browser == "chrome")
            {
                driver = new ChromeDriver(); //Opens chrome
            } else if (browser== "firefox")
            {
                driver = new FirefoxDriver();
            }

            
            Console.WriteLine("Starting browser");
        }

        [TearDown]
        public void ICanCallThisWhateverIWant() //See the annotation is important, not the name. This is a terrible name though.
        {
            //Check if a test has just errored out - if so take a screenshot
            //Looks like this is harder to do with MSTest
            //https://stackoverflow.com/questions/57121562/how-to-get-error-message-with-mstest-testcontext
            Console.WriteLine(TestContext.CurrentContext.Result.Outcome);
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Error)
            {
                takescreenshot(driver, "testfailed");
            }
            driver.Quit();
        }
    }
}
