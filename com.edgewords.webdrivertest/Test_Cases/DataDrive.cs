using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace com.edgewords.webdrivertest.Test_Cases
{
    [TestFixture]
    public class DataDrive : Utils.TestBase
    {
        [Test, TestCaseSource(typeof (Utils.HelperLib),"GetTestData")] //Calls helper method to get data
        public void MyDataDrivenTest(string Username, string Password)
        {
            driver.Url = "https://www.edgewordstraining.co.uk/webdriver2/sdocs/auth.php";
            driver.FindElement(By.Id("username")).SendKeys(Username);
            driver.FindElement(By.Id("password")).SendKeys(Password);
            driver.FindElement(By.LinkText("Submit")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.LinkText("Log Out")).Click();
        }

       
    }
}
