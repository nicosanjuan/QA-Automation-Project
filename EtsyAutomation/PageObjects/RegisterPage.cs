using System;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Assert = NUnit.Framework.Assert;

namespace EtsyAutomation.PageObjects
{
    public class RegisterPage : BasePage
    {

        [FindsBy(How = How.XPath, Using = "//*[@id=\"join-neu-form\"]/div[1]/div/div[1]/div/button")]
        public IWebElement Register { get; set; }

        [FindsBy(How = How.Id, Using = "join_neu_email_field")]
        public IWebElement EmailAddress { get; set; }

        [FindsBy(How = How.Id, Using = "join_neu_first_name_field")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "join_neu_password_field")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Name, Using = "submit_attempt")]
        public IWebElement RegisterButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@id,'join-neu-overlay')]")]
        public IWebElement RegistrationMessage { get; set; }
        public RegisterPage()
        {
            PageFactory.InitElements(_driver, this);
        }
        public void CreateSignUp()
        {
            EtsyHomePage etsyHomePage = new EtsyHomePage();
            etsyHomePage.SignIn.Click();
            Thread.Sleep(3000);

            Register.Click();
            EmailAddress.Click();

            Thread.Sleep(3000);
            EmailAddress.SendKeys("testmail@gmail.com");

            FirstName.Click();
            FirstName.SendKeys("Nicolas");

            Password.Click();
            Password.SendKeys("Password1");

            RegisterButton.Click();
            Thread.Sleep(3000);
            var registerMsg = RegistrationMessage.Text;

            if (registerMsg.Contains("Sorry! There was a problem on our end. Please try registering again or email support@etsy.com for assistance."))
            {
                Assert.That(registerMsg, Is.False);
            }

        }
    }
}
