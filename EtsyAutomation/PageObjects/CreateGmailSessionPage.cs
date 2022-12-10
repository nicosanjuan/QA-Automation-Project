using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtsyAutomation.PageObjects
{
    public class CreateGmailSessionPage
    {
        public CreateGmailSessionPage()
        {

            IWebDriver driver2 = new ChromeDriver();
            driver2.Navigate().GoToUrl("https://gmail.com");
            driver2.Manage().Window.Maximize();
            PageFactory.InitElements(driver2, this);

        }


        [FindsBy(How = How.Id, Using = "identifierId")]
        public IWebElement Text_EmailAddress { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(., 'Next')]")]
        public IWebElement NextButton { get; set; }

        [FindsBy(How = How.Name, Using = "Passwd")]
        public IWebElement Text_Passord { get; set; }

        [FindsBy(How = How.ClassName, Using = "stUf5b")]
        IWebElement UseAnotherAccount;

        //Login into google the very first time to create a session so you can Login on etsy with a google account
        //repleace your own gmail and password to login
        public void LoginToGoogleFirst()
        {
            Thread.Sleep(3000);
            Text_EmailAddress.Click();
            Text_EmailAddress.SendKeys("sjuannic@gmail.com");
            NextButton.Click();
            Thread.Sleep(3000);

            Text_Passord.Click();
            Text_Passord.SendKeys("Q@3ngin33r!");
            NextButton.Click();
        }
    }
}
