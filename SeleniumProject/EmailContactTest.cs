using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using NUnit.Framework.Legacy;

[TestFixture]
public class EmailContactTest
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


	public void testimiEmailAdresa()
	{
		driver.Navigate().GoToUrl("http://localhost:5174/contact");


		//Gjeni inputin per emrin dhe shenoni emrin
		IWebElement emailKontakti = driver.FindElement(By.XPath("//input[@id='contact-email']"));
		emailKontakti.SendKeys("pira.rigon@gmail.com");

		// Find the login button and click it
		IWebElement submitButton = driver.FindElement(By.XPath("//input[@type='submit' and @value='Dergo']"));
		submitButton.Click();
	}

}
