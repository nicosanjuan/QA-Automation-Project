using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V106.Debugger;
using SeleniumExtras.PageObjects;

namespace EtsyAutomation.PageObjects
{
    public class EtsyHomePage : BasePage
    {

        #region Login Elements
        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Sign in')]")]
        public IWebElement SignIn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"join_neu_email_field\"]")]
        public IWebElement Text_EtsyEmailAddress { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"join_neu_password_field\"]")]
        public IWebElement Text_EtsyPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@class='shopping-window wt-display-flex-xs wt-flex-direction-column-xs wt-grid__item-xs-4 wt-grid__item-md-2 wt-pl-xl-6 wt-pr-xl-6']")]
        public IList<IWebElement> Products { get; set; }
        #endregion

        #region Shopping Elements
        [FindsBy(How = How.XPath, Using = "//a[contains(@href, '/cart?ref=hdr-cart')]")]
        public IWebElement ShoppingCartIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='search_query']")]
        public IWebElement Text_Search { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='wt-icon wt-nudge-b-2 wt-nudge-r-1']")]
        public IWebElement button_Search { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(. , 'Add to cart')]")]
        public IList<IWebElement> Buttons_AddToCart { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(. , 'Shop this item')]")]
        public IWebElement ShopThisItem { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='variation-selector-0']")]
        public IWebElement selectItem { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@id='variation-selector-1']")]
        public IWebElement selectCuffFabric { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(. ,  'Add to cart')]")]
        public IWebElement AddToCart { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(. , 'Keep shopping')]")]
        public IWebElement KeepShopping { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/?ref=lgo']")]
        public IWebElement HomePage { get; set; }
        [FindsBy(How = How.ClassName, Using = "wt-textarea-wt-textarea")]
        public IWebElement Text_Personalized { get; set; }
        #endregion
        public EtsyHomePage()
        {
            PageFactory.InitElements(_driver, this);
        }

        public void CreateSignUp()
        {
            SignIn.Click();

        }

        public void AddItemsToCart(String itemCategory, String itemSize)
        {
            IList<IWebElement> itemsinStore = _driver.FindElements(By.XPath("//li[@class='shopping-window wt-display-flex-xs wt-flex-direction-column-xs wt-grid__item-xs-4 wt-grid__item-md-2 wt-pl-xl-6 wt-pr-xl-6']"));
            if (itemsinStore.Count > 0)
            {
                foreach (IWebElement item in Products)
                {
                    if (item.Text == itemCategory)
                    {
                        item.Click();
                        Thread.Sleep(2000);

                        ShopThisItem.Click();
                        Thread.Sleep(3000);

                        try
                        {
                            selectItem.Click();
                            selectItem.SendKeys(itemSize);
                            selectItem.Click();
                            Thread.Sleep(3000);
                        }
                        catch (Exception e)
                        {
                           //do we need to log any message when an element doesn't exist?
                        }

                        AddToCart.Click();
                        Thread.Sleep(5000);

                        KeepShopping.Click();
                        Thread.Sleep(5000);

                        HomePage.Click();
                        Thread.Sleep(3000);
                        break;
                    }
                }
             }
        }

        protected Boolean isElementPresent(By selector)
        {
            _driver.Manage().Timeouts().ImplicitWait.Equals(1);
            Microsoft.VisualStudio.TestTools.UnitTesting.Logging.Logger.LogMessage("Is element present" + selector);
            Boolean returnVal = true;
            try
            {
                _driver.FindElement(selector);
            }
            catch (NoSuchElementException e)
            {
                returnVal = false;
            }
            finally
            {
                _driver.Manage().Timeouts().ImplicitWait.Equals(1);
            }
            return returnVal;
        }

        public void InformationSaved() { }
        public void CheckItemsInShoppingCart() { }
    }
}