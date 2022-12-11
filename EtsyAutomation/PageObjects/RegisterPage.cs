using System;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Assert = NUnit.Framework.Assert;

namespace EtsyAutomation.PageObjects
{
    public class RegisterPage : BasePage
    {

        [FindsBy(How = How.XPath, Using = "//button[contains(. , 'Register')]")]
        public IWebElement Register { get; set; }

        [FindsBy(How = How.Id, Using = "join_neu_email_field")]
        public IWebElement EmailAddress { get; set; }

        [FindsBy(How = How.Id, Using = "join_neu_first_name_field")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "join_neu_password_field")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Name, Using = "submit_attempt")]
        public IWebElement RegisterButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'wt-validation__message wt-mt-xs-1')]")]
        public IWebElement RegistrationMessage { get; set; }
        public RegisterPage()
        {
            PageFactory.InitElements(_driver, this);
        }
        public void CreateSignUp(string emailAddress, string firstName, string password)
        {
            EtsyHomePage etsyHomePage = new EtsyHomePage();
            etsyHomePage.SignIn.Click();
            Thread.Sleep(3000);

            Register.Click();
            EmailAddress.Click();

            Thread.Sleep(3000);
            EmailAddress.SendKeys(emailAddress);

            FirstName.Click();
            FirstName.SendKeys(firstName);

            Password.Click();
            Password.SendKeys(password);

            RegisterButton.Click();
            Thread.Sleep(3000);
        }
    }
}
