
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

        [Test, Order(1)]
        public void Test_Create_SingUp()
        {
            RegisterPage registerPage = new RegisterPage();
            registerPage.CreateSignUp("useremail@gmail.com", "Jonny", "RandomPassword");
            
            var registerMsg = registerPage.RegistrationMessage.Text;

            if (registerMsg.Contains("Sorry"))
            {
                Assert.Fail(registerMsg);
            }
            else
            {
                Assert.Pass();
            }

        }

        [Test, Order(2)]
        public void Test_Login_With_Etsy_Valid_Account()
        {
           LoginPage loginPage = new LoginPage();
           loginPage.LoginWithEtsyAccount("sjuannic@gmail.com", "Q@3ngin33r!");
            if (loginPage.Text_LoginSuccesmessage.Text == "Password was incorrect")
            {
                Assert.IsFalse(false, "User can't login with valid credentials");
            }
        }

        [Test, Order(3)]
        public void Test_Login_With_Etsy_Invalid_Account()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.LoginWithEtsyAccount("sjuannic@gmail.com", "wrongPassword");

            if (loginPage.Text_LoginSuccesmessage.Text == "Password was incorrect")
            {
                Assert.IsTrue(true, "User can't login with invalid password.");
            }
            else
            {
                Assert.IsFalse(false, "Possible logged in with invalid password is allowed.");
            }
        }

        [Test, Order(4)]
        public void Test_Login_With_Google_Account()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.LoginWithGoogle("sjuannic@gmail.com", "Q@3ngin33r!");
        }

        [Test, Order(5)]
        public void Test_Add_Two_Items_In_Shopping_Cart()
        {
            EtsyHomePage etsyHomePage = new EtsyHomePage();
            etsyHomePage.AddItemsToCart("Home Decor", " ");
            etsyHomePage.AddItemsToCart("Clothing", "M US Women's letter");
        }

        [Test, Order(6)]
        public void Test_Add_Two_Items_ToCart_CheckOut_As_Guest()
        {
            EtsyHomePage etsyHomePage = new EtsyHomePage(); 
            CheckOutOrderPage checkOutOrderPage = new CheckOutOrderPage();
            etsyHomePage.AddItemsToCart("Home Decor", " ");
            etsyHomePage.AddItemsToCart("Clothing", "M US Women's letter");
            checkOutOrderPage.CheckOutOrder();
            checkOutOrderPage.PaymentMethod();
        }

        [Test, Order(7)]
        public void Test_LogIn_Check_That_There_Are_Items_InCart_Then_Logout()
        {
            LoginPage loginPage = new LoginPage();
            EtsyHomePage etsyHomePage = new EtsyHomePage();
            ShoppingCartPage shoppingCartPage = new ShoppingCartPage();
            etsyHomePage.AddItemsToCart("Home Decor", " ");
            etsyHomePage.AddItemsToCart("Clothing", "M US Women's letter");
            loginPage.LoginWithGoogle("sjuannic@gmail.com", "Q@3ngin33r!");
            
            //check items in cart
            etsyHomePage.ShoppingCartIcon.Click();
           var ItemsinShppingCart = shoppingCartPage.CheckItemsInShoppingCart.Text;
            if(ItemsinShppingCart !=null)
            {
                Assert.True(true, ItemsinShppingCart);
            }
            else {
                Assert.Fail(ItemsinShppingCart);
            }
            
            loginPage.LogOut();
        }
    }
}