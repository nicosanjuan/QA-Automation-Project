
using System.Runtime.Serialization;
using EtsyAutomation.PageObjects;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace EtsyNUnitTests
{
    public class Tests : BasePage
    {

        /*[Test, Order(1)]
        public void Test_LoginToGoogleGmailSetSession()
        {
            CreateGmailSessionPage gmailSession = new CreateGmailSessionPage( driver);
            gmailSession.LoginToGoogleFirst();
        }*/

        [Test, Order(2)]
        public void Test_CreateSingUp()
        {
            RegisterPage registerPage = new RegisterPage();
            registerPage.CreateSignUp();
           
        }

        [Test, Order(3)]
        public void Test_LoginWithEtsyAccount()
        {
            LoginPage loginPage = new LoginPage();
           loginPage.LoginWithEtsyAccount();
        }

        [Test, Order(4)]
        public void Test_LoginWithGoogleAccount()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.LoginWithGoogle();
        }
        [Test, Order(5)]
        public void Test_CheckOUtOrder()
        {
            EtsyHomePage etsyHomePage = new EtsyHomePage(); 
            CheckOutOrderPage checkOutOrderPage = new CheckOutOrderPage();
            etsyHomePage.AddItemsToCart();
            checkOutOrderPage.CheckOutOrder();
            checkOutOrderPage.PaymentMethod();
        }

        [Test, Order(6)]
        public void Test_LogIn_LogOut()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.LoginWithGoogle();
            loginPage.LogOut();
        }
    }
}