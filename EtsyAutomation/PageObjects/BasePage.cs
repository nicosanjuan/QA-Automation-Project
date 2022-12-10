using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;

public class BasePage
{
	public static IWebDriver _driver = null;
	[SetUp]
	public void Initialized()
	{
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl("https://www.etsy.com");
        _driver.Manage().Window.Maximize();
	}
	[TearDown]
	public void CleanUp()
	{
		_driver.Quit();
	}
}
