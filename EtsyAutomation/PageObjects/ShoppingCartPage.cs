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
        public ShoppingCartPage()
        {
            PageFactory.InitElements(_driver, this);
        }
    }
}
