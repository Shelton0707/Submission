using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using UITestDemo;
using AventStack.ExtentReports;
using FinalProjectSubmit;

namespace FinalProjectSubmit
{

    public class Luma 
    {
        public IWebDriver wdriver;
        private string url = "https://luma.enablementadobe.com/content/luma/us/en.html";

        [SetUp]
        public void Setup()

        {
            //Setup for Extend Report
            //StartExtentTest(TestContext.CurrentContext.Test.Name);

            //Setting up WebDriver Manager
            new DriverManager().SetUpDriver(new EdgeConfig());
            wdriver = new EdgeDriver();

            //Navigate to URL
            wdriver.Navigate().GoToUrl(url);
            wdriver.Manage().Window.Maximize();

        }

        [Test]
        public void TestLogin()
        {
            //For waits
            WebDriverWait wait = new WebDriverWait(wdriver, TimeSpan.FromSeconds(10));

            //Action Login
            wdriver.FindElement(By.XPath("//a[contains(text(),'Login')]")).Click();
            IWebElement emailNameField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@type='text']")));
            emailNameField.SendKeys("Sarah1102@gmail.com");
            IWebElement passwordField = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@type='password']")));
            passwordField.SendKeys("Captain01");
            wdriver.FindElement(By.XPath("//button[@type='submit']")).Click();
            IWebElement link = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Men")));
            link.Click();

            //Verifying successful LOGIN 

            if (wdriver.FindElement(By.XPath("//a[contains(text(),'Log out')]")).Displayed)
            {
                IWebElement LogoutMsg = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(),'Log out')]")));
                Console.WriteLine("logout");

            }

            else

            {

                Console.WriteLine(wdriver.FindElement(By.XPath("//a[contains(text(),'Login')]")).Text);
            }


            //[Test, Order(2)]

            //public void Cart()
            //{

            //For waits
            //WebDriverWait wait = new WebDriverWait(wdriver, TimeSpan.FromSeconds(10));
            //Locators




        }
    }
}

