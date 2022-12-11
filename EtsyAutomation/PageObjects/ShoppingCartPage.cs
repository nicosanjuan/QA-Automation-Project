using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtsyAutomation.PageObjects
{
    public class ShoppingCartPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//h1[@class='wt-text-heading-01']")]
        public IWebElement CheckItemsInShoppingCart { get; set; }
        public ShoppingCartPage()
        {
            PageFactory.InitElements(_driver, this);
        }

    }
}
