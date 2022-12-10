using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

public class EtsyHomePage : BasePage
{
	public EtsyHomePage()
	{
		PageFactory.InitElements(_driver, this);
	}

	[FindsBy(How = How.XPath, Using = "//*[contains(text(),'Sign in')]")]
	public IWebElement SignIn { get; set; }

    [FindsBy(How = How.XPath, Using = "//*[@id=\"join_neu_email_field\"]")]
    public IWebElement Text_EtsyEmailAddress { get; set; }

    [FindsBy(How = How.XPath, Using = "//*[@id=\"join_neu_password_field\"]")]
    public IWebElement Text_EtsyPassword { get; set; }

    [FindsBy(How = How.XPath, Using = "//li[@class='shopping-window wt-display-flex-xs wt-flex-direction-column-xs wt-grid__item-xs-4 wt-grid__item-md-2 wt-pl-xl-6 wt-pr-xl-6']")]
    [CacheLookup]
    public IList<IWebElement> Products { get; set; }
    public void CreateSignUp()
	{
		SignIn.Click();
		
	}
	public void InformationSaved() { }
	public void CheckItemsInShoppingCart() { }
}
