using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using com.edgewords.webdrivertest.POM_Pages;
using OpenQA.Selenium;

namespace com.edgewords.webdrivertest.Test_Cases
{
    [TestFixture]
    public class TestThatPOMs:Utils.TestBase
    {
        [Test]
        public void CheckLogin()
        {
            driver.Url = baseurl; //set in TestBase

            HomePagePOM home = new HomePagePOM(driver);
            home.LoginToDBSite().TypeUsername("Edgewords").TypePassword("Edgewords123"); //fluid coding - relies on appropriate class instance being returned back by page

            //LoginPagePOM loginpage = new LoginPagePOM(driver);
            //Thread.Sleep(1000);
            //loginpage.Login("edgewords", "edgewords123");
            //AddRecordPOM AddRecord = new AddRecordPOM(driver);
            //Thread.Sleep(1000); Hack to wait for page to load. Without it the below assertion fails as we're still on the old page.
            //Assert.That(AddRecord.GetPageHeading(), Is.EqualTo("Add A Record To the Database"), "We are not on the right page");
            //Thread.Sleep(3000);
        }
    }
}
