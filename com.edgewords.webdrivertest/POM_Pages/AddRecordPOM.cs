using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace com.edgewords.webdrivertest.POM_Pages
{
    class AddRecordPOM
    {
        IWebDriver driver;

        public AddRecordPOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement heading => driver.FindElement(By.CssSelector("#right-column > h1:nth-child(1)"));

        public string GetPageHeading()
        {
            string headingtext = heading.Text;
            return headingtext;
        }
    }
}
