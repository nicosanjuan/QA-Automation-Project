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




        public void AddItemsToCart()
        {
            //IList<IWebElement> itemsinStore = driver.FindElements(By.XPath("//li[@class='shopping-window wt-display-flex-xs wt-flex-direction-column-xs wt-grid__item-xs-4 wt-grid__item-md-2 wt-pl-xl-6 wt-pr-xl-6']"));
            EtsyHomePage etsyHomePage = new EtsyHomePage();

            if (etsyHomePage.Products.Count > 0)
            {
                foreach (IWebElement item in etsyHomePage.Products)
                {
                    if (item.Text == "Seasonal Decor")
                    {
                        item.Click();
                        Thread.Sleep(2000);
                        ShopThisItem.Click();

                        Thread.Sleep(2000);
                        selectItem.Click();
                        selectItem.SendKeys("Eyes");

                        Thread.Sleep(4000);
                        if (selectCuffFabric.Displayed)
                        {
                            selectCuffFabric.Click();
                            Thread.Sleep(2000);
                            selectCuffFabric.SendKeys("Solid Terracotta ($25.00)");
                            Thread.Sleep(2000);
                        }
                        AddToCart.Click();
                        Thread.Sleep(2000);

                        KeepShopping.Click();
                        Thread.Sleep(2000);

                        HomePage.Click();
                        Thread.Sleep(9000);
                    }
                    break;

                    /*if (allItmes.Text == "Cozy Clothing")
                    {
                        allItmes.Click();
                    }

                     if (allItmes.Text == "Gifts for the Home")
                    {
                        allItmes.Click();
                    }
                    if (allItmes.Text == "Gifts for Kids")
                    {
                        allItmes.Click();
                    }

                    if (allItmes.Text == "On Sale")
                    {
                        allItmes.Click();
                    }*/
                }

            }
            /* if (itemsinStore.Count > 0)
             {
                 foreach (IWebElement item in itemsinStore)
                 {
                     if (item.Text == "Gifts for Kids")
                     {
                         item.Click();

                         Thread.Sleep(2000);
                         ShopThisItem.Click();

                         *//*Thread.Sleep(2000);
                         selectItem.Click();
                         selectItem.SendKeys("M US women's letter");

                         Thread.Sleep(2000);
                         selectCuffFabric.Click();
                         Thread.Sleep(2000);
                         selectCuffFabric.SendKeys("Solid Terracotta ($25.00)");
                         Thread.Sleep(1000);*//*

                         AddToCart.Click();
                         Thread.Sleep(2000);

                         KeepShopping.Click();
                         Thread.Sleep(2000);

                         HomePage.Click();
                         Thread.Sleep(2000);
                     }

                     itemsinStore = driver.FindElements(By.XPath("//li[@class='shopping-window wt-display-flex-xs wt-flex-direction-column-xs wt-grid__item-xs-4 wt-grid__item-md-2 wt-pl-xl-6 wt-pr-xl-6']"));
                     if (item.Text == "Seasonal Decor")
                     {

                         item.Click();
                         Thread.Sleep(2000);
                         ShopThisItem.Click();

                         Thread.Sleep(2000);
                         selectItem.Click();
                         selectItem.SendKeys("Eyes");

                         Thread.Sleep(4000);
                         if (selectCuffFabric.Displayed)
                         {
                             selectCuffFabric.Click();
                             Thread.Sleep(2000);
                             selectCuffFabric.SendKeys("Solid Terracotta ($25.00)");
                             Thread.Sleep(2000);
                         }
                         AddToCart.Click();
                         Thread.Sleep(2000);

                         KeepShopping.Click();
                         Thread.Sleep(2000);

                         HomePage.Click();
                         Thread.Sleep(9000);
                     }
                 }
             }*/
        }

    }
}
