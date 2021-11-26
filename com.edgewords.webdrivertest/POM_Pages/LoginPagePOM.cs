using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace com.edgewords.webdrivertest.POM_Pages
{
    public class LoginPagePOM
    {
        IWebDriver driver;

        public LoginPagePOM(IWebDriver driver)
        {
            this.driver = driver;
        }

        //How to find elements
        IWebElement UsernameField => driver.FindElement(By.Id("username"));
        IWebElement PasswordField => driver.FindElement(By.Id("password"));
        IWebElement SubmitButton => driver.FindElement(By.LinkText("Submit"));
        IWebElement ClearButton => driver.FindElement(By.LinkText("Clear"));

        //Service Methods
        public LoginPagePOM TypeUsername(string Username)
        {
            UsernameField.SendKeys(Username);
            return this;
        }

        public void TypePassword(string Password)
        {
            PasswordField.SendKeys(Password);
        }

        public void SubmitForm()
        {
            SubmitButton.Click();
        }

        public void Login(string Username, string Password)
        {
            ClearButton.Click();
            TypeUsername(Username);
            TypePassword(Password);
            SubmitForm();
        }
    }
}
