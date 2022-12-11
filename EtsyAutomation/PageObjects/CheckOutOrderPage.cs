using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtsyAutomation.PageObjects
{
    public class CheckOutOrderPage : BasePage
    {
        public CheckOutOrderPage()
        {
            PageFactory.InitElements(_driver, this);

        }

        [FindsBy(How = How.ClassName, Using = "submit-button-text")]
        public IWebElement ProceedCheckOutButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"join-neu-continue-as-guest\"]/div/button")]
        public IWebElement ContinueAsGuestButton { get; set; }

        [FindsBy(How = How.Name, Using = "email_address")]
        public IWebElement CheckOut_Email { get; set; }

        [FindsBy(How = How.Name, Using = "email_address_confirmation")]
        public IWebElement CheckOut_ConfirmEmail { get; set; }

        [FindsBy(How = How.Name, Using = "country_id")]
        public IWebElement CheckOut_Country { get; set; }

        [FindsBy(How = How.Name, Using = "name")]
        public IWebElement CheckOut_FullName { get; set; }

        [FindsBy(How = How.Name, Using = "first_line")]
        public IWebElement CheckOut_StreetAddress { get; set; }

        [FindsBy(How = How.Name, Using = "zip")]
        public IWebElement CheckOut_ZipCode { get; set; }

        [FindsBy(How = How.Name, Using = "city")]
        public IWebElement CheckOut_City { get; set; }

        [FindsBy(How = How.Name, Using = "state")]
        public IWebElement CheckOut_State { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"shipping-address-form\"]/div[2]/button")]
        public IWebElement CheckOut_ContinueToPayment { get; set; }

        [FindsBy(How = How.Id, Using = "cc-radio--paymentstep")]
        public IWebElement PaymentCCRadio { get; set; }

        [FindsBy(How = How.Name, Using = "card[name]")]
        public IWebElement NameOnCard { get; set; }

        [FindsBy(How = How.Name, Using = "card[number]")]
        public IWebElement CreditCardNumber { get; set; }


        [FindsBy(How = How.Name, Using = "card[exp_mon]")]
        public IWebElement ExpirationCardMonth { get; set; }


        [FindsBy(How = How.Name, Using = "card[exp_year]")]
        public IWebElement ExpirationCardYear { get; set; }

        [FindsBy(How = How.Name, Using = "card[ccv]")]
        public IWebElement CreditCardSecurityCode { get; set; }

        [FindsBy(How = How.Name, Using = "payment_submit")]
        public IWebElement ReviewOrder { get; set; }

        

        public void CheckOutOrder()
        {
            EtsyHomePage etsyHomePage = new EtsyHomePage();
            etsyHomePage.ShoppingCartIcon.Click();
            Thread.Sleep(2000);

            ProceedCheckOutButton.Click();
            Thread.Sleep(3000);

            ContinueAsGuestButton.Click();
            Thread.Sleep(2000);

            CheckOut_Email.SendKeys("testEmail@gmail.com");
            CheckOut_ConfirmEmail.SendKeys("testEmail@gmail.com");
            CheckOut_Country.Click();

            Thread.Sleep(3000);
            CheckOut_FullName.SendKeys("Mary Henderson");
            CheckOut_StreetAddress.SendKeys("2025 6th ave");
            CheckOut_ZipCode.SendKeys("10001");
            Thread.Sleep(2000);
            CheckOut_City.SendKeys("New York City");
            CheckOut_State.SendKeys("New York");
            CheckOut_ContinueToPayment.Click();

        }
        public void PaymentMethod()
        {
            Thread.Sleep(3000);
            IWebElement ccpayment = _driver.FindElement(By.Id("cc-radio--paymentstep"));
            _driver.ExecuteJavaScript("arguments[0].click();", ccpayment);

            //PaymentCCRadio.Click();

            NameOnCard.SendKeys("Mary Henderson");
            CreditCardNumber.SendKeys("4056458912631001");
            ExpirationCardMonth.SendKeys("12");
            ExpirationCardYear.SendKeys("2026");
            CreditCardSecurityCode.SendKeys("123");
            ReviewOrder.Click();
        }

    }
}
