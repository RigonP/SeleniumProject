using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System;
using NUnit.Framework.Legacy;

[TestFixture]
public class EmailFooterTest
{
	private IWebDriver driver;

	[OneTimeSetUp]
	public void Setup()
	{
		var options = new ChromeOptions();
		var service = ChromeDriverService.CreateDefaultService(@"C:\Users\lenovo\Desktop\Testimi dhe Mirëmbajtja e Softuerit\Testimi me Selenium\SeleniumProject\packages\Selenium.WebDriver.ChromeDriver.125.0.6422.6000\driver\win32");
		driver = new ChromeDriver(service, options);
	}

	[Test]
	public void TestEmailSubmission()
	{
		driver.Navigate().GoToUrl("http://localhost:5174");

		// Find the email input field and enter the email
		IWebElement emailInput = driver.FindElement(By.Id("contact-email"));
		emailInput.SendKeys("pira.rigon@gmail.com");

		// Find the submit button and click it						 
		IWebElement submitButton = driver.FindElement(By.XPath("//input[@input type='submit' and @value='Dergo']"));
		submitButton.Click();
										
		// Wait for the success message to be displayed
		WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
		IWebElement successMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".text-success")));

		// Verify the success message
		ClassicAssert.AreEqual("Jeni bërë subscribe me sukses !", successMessage.Text);
	}

	[OneTimeTearDown]
	public void TearDown()
	{
		driver.Quit();
	}
}
