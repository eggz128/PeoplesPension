using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Interactions;
using static com.edgewords.webdrivertest.Utils.Globals;


namespace com.edgewords.webdrivertest.Test_Cases
{
    [TestFixture]
    public class FirstTest : Utils.TestBase //This class inherits from Utils.TestBase.cs
    {
        /*
         * [SetUp] and [TearDown] methods and Fields have been moved in to Utils/TestBase.cs
         * This test class now inherits these (see line 21)
         */

        [Test, Order(2), Category("Functional")] //Impose a run order, and categorise this test
        public void SecondTestA()
        {
            driver.Url = GLOBAL_BASE_URL; //Navigates to URL set above
            driver.FindElement(By.LinkText("Login To Restricted Area")).Click();
            //driver.FindElement(By.Id("username")).SendKeys("edgewords"); //Instead of all one line you can get a reference to a web element and re use it as follows


            IWebElement usernameField = driver.FindElement(By.Id("username")); //Just find the element and store the reference in usernameField
            usernameField.SendKeys("edgewords" + Keys.Enter); //Then usernameField...
            //Clear the field like a user might (select all then delete)
            usernameField.SendKeys(Keys.Control + "a");
            usernameField.SendKeys(Keys.Delete);
            //usernameField.Clear(); //or do it in one line

            driver.FindElement(By.Id("password")).SendKeys("edgewords123");
            driver.FindElement(By.CssSelector("#Login > table > tbody > tr:nth-child(3) > td:nth-child(2) > a:nth-child(1)")).Click();
            
            //Report out that this "test" is done.
            Console.WriteLine("Test Finished!");
        }

        //Another test
        //If you run the class which test runs first?
        [Test, Order(1)]
        public void SecondTestB()
        {
            driver.Url = "https://edgewordstraining.co.uk/webdriver2/docs/cssXPath.html";
            IWebElement gripper = driver.FindElement(By.CssSelector("#slider > a")); //Find the gripper element

            Actions actions = new Actions(driver); //Create an Actions object (& pass it Chrome to work with)
            
            //Create an action using the actions object
            IAction myaction = actions  //white space isn't important, so we can break a long line in to multiple lines to make it easier to read
                .ClickAndHold(gripper) //Left click and hold the gripper
                .MoveByOffset(100, 0) //Move the mouse
                .Release() //Let go of the left mouse button (important!)
                .Build(); //Finishes the action step "list", but doesn't actually *do* it yet

            myaction.Perform(); //do the action
        }
    }
}
