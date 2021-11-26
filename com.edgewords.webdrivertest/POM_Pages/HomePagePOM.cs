using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace com.edgewords.webdrivertest.POM_Pages
{
    public class HomePagePOM
    {
        IWebDriver driver; //Holds the webdriver instance that the test passes in

        //Runs when class is initialised. Takes the driver that is passed and puts it in the field above
        public HomePagePOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Find our objects that we want to interact with
        IWebElement LoginLink => driver.FindElement(By.LinkText("Login To Restricted Area"));


        //Service Methods
        public LoginPagePOM LoginToDBSite()
        {
            LoginLink.Click();
            return new LoginPagePOM(driver);
        }

    }
}
