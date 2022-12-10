using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtsyAutomation.PageObjects
{
    public class LoginPage : BasePage
    {
        public LoginPage()
        {
            PageFactory.InitElements(_driver, this);

        }

        /// <summary>
        /// EtsyLogin
        /// </summary>
        /// 
        [FindsBy(How = How.XPath, Using = "//*[@id='join_neu_email_field']")]
        public IWebElement Text_EtsyEmailAddress { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='join_neu_password_field']")]
        public IWebElement Text_EtsyPassword { get; set; }

        [FindsBy(How = How.Name, Using = "submit_attempt")]
        public IWebElement Btn_EtsySignIn { get; set; }

        [FindsBy(How = How.Id, Using = "aria-join_neu_password_field-error")]
        public IWebElement Text_LoginSuccesmessage { get; set; }

        /// <summary>
        /// Login with Goolgle
        /// </summary>
        [FindsBy(How = How.XPath, Using = "//button[contains(. , 'Continue with Google')]")]
        public IWebElement btn_LoginWithGoogleAccount { get; set; }

        [FindsBy(How = How.Id, Using = "identifierId")]
        public IWebElement Text_EmailAddress { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(., 'Next')]")]
        public IWebElement NextButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='password']")]
        public IWebElement Text_Passord { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@class='wt-circle wt-icon']")]
        public IWebElement AccountImg { get; set; }


        [FindsBy(How = How.XPath, Using = "//a[contains(@href, 'ref=hdr_user_menu-signout')]")]
        public IWebElement AccountLogout { get; set; }


        public void LoginWithEtsyAccount()
        {
            OpenSignIn();

            Text_EtsyEmailAddress.SendKeys("sjuannic@gmail.com");
            Text_EtsyPassword.SendKeys("Q@3ngin33r!");
            Btn_EtsySignIn.Click();

            Thread.Sleep(3000);
            var successMessage = Text_LoginSuccesmessage.Text;
            if (successMessage.Contains("Password was incorrect"))
            {
                Assert.Fail("FAILED to log in with etsy account");
            }
        }

        public void LoginWithGoogle()
        {
            OpenSignIn();
            Thread.Sleep(2000);
            btn_LoginWithGoogleAccount.Click();
            Thread.Sleep(1000);

            IEnumerable<string> windows = _driver.WindowHandles;
            var parentWindow = windows.First();
            var childWindow = windows.Last();
            _driver.SwitchTo().Window(childWindow);
            Thread.Sleep(2000);

            Text_EmailAddress.Click();
            Text_EmailAddress.SendKeys("sjuannic@gmail.com");
            NextButton.Click();
            Thread.Sleep(2000);

            Text_Passord.Click();
            Thread.Sleep(2000);

            Text_Passord.SendKeys("Q@3ngin33r!");
            NextButton.Click();
            Thread.Sleep(200);
            //switch to maing window
            _driver.SwitchTo().Window(parentWindow);
        }

        public void LogOut()
        {
            Thread.Sleep(5000);
            AccountImg.Click();
            Thread.Sleep(1000);

            AccountLogout.Click();
        }

        public void OpenSignIn()
        {
            EtsyHomePage etsyHomePage = new EtsyHomePage();
            etsyHomePage.SignIn.Click();
            Thread.Sleep(3000);
        }


    }
}
