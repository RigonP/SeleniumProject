using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

[TestFixture]
public class FansTest
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
	public void fansTest()
	{
		driver.Navigate().GoToUrl("http://localhost:5174/fansDashboard");

		// Kliko ne butonin "Add Fans"
		IWebElement addFansButton = driver.FindElement(By.CssSelector(".btn.btn-primary"));
		addFansButton.Click();

		
		//Prisni derisa te shfaqet modaliteti
		WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
		wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".modal-title")));

		//Plotesoni fushat si ne vijim
		driver.FindElement(By.Id("title")).SendKeys("Sample Title");
		driver.FindElement(By.Id("company")).SendKeys("Sample Title Description");
		driver.FindElement(By.Id("priceDescription")).SendKeys("Sample Price Description");
		driver.FindElement(By.Id("price")).SendKeys("100");
		driver.FindElement(By.Id("description")).SendKeys("Sample Description");


		//Selektoni kategorine prej dropdown
		IWebElement categoryDropdown = driver.FindElement(By.Id("category"));
		SelectElement selectCategory = new SelectElement(categoryDropdown);
		selectCategory.SelectByText("Kategoria 1");

		//Ngarkoni fotografine
		IWebElement imageInput = driver.FindElement(By.Id("image"));
		imageInput.SendKeys("C:/Users/lenovo/Pictures/Screenshots/Barrel.png");

		//Klikoni butonin Save Image
		IWebElement saveImageButton = driver.FindElement(By.XPath("//button[contains(text(), 'Save Image')]"));
		saveImageButton.Click();

		//Prisni derisa foto te ngarkohet komplet dhe imazhi te shfaqet
		wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
		wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("img[src*='Save image']")));

		// Dorezoni (Submit) formen
		IWebElement submitButton = driver.FindElement(By.CssSelector(".btn.btn-primary"));
		submitButton.Click();

		//Verifikoni mesazhin e suksesit
		IWebElement successMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".text-success")));
		ClassicAssert.AreEqual("U postua me sukses !", successMessage.Text);
	}

	[OneTimeTearDown]
	public void TearDown()
	{
		driver.Quit();
	}
}
