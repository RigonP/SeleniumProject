using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using NUnit.Framework.Legacy;

[TestFixture]
public class NameContactTest
{
	private IWebDriver driver; // Deklarimi i instancës së WebDriver

	// Metoda e konfigurimit OneTimeSetUp për të inicializuar WebDriver
	[OneTimeSetUp]
	public void Setup()
	{
		var options = new ChromeOptions();//Konfigurimi i ChromeOption nese duhet

		// Definimi i shërbimit të ChromeDriver me path drejt ekzekutuesit të ChromeDriver
		var service = ChromeDriverService.CreateDefaultService(@"C:\Users\lenovo\Desktop\Testimi dhe Mirëmbajtja e Softuerit\Testimi me Selenium\SeleniumProject\packages\Selenium.WebDriver.ChromeDriver.125.0.6422.6000\driver\win32");
		driver = new ChromeDriver(service, options); //Inicializimi i ChromeDriver me shërbimin dhe opsionet e definuara
	}

	/*[Test]
	public void Test1()
	{
		driver.Navigate().GoToUrl("http://www.ubt-uni.net");
		ClassicAssert.AreEqual("Kolegji UBT – Higher Education Institution", driver.Title);
	}*/

	[Test]
	public void testimiEmritKontaktit() // Metoda e testimit për të shënuar emrin në formularin e kontaktit
	{
		driver.Navigate().GoToUrl("http://localhost:5174/contact"); // Navigimi në faqen e kontaktit të serverit lokal

		//Gjeni inputin per emrin dhe shenoni emrin
		IWebElement emriKontaktit = driver.FindElement(By.XPath("//input[@id='contact-name']"));
		emriKontaktit.SendKeys("Ri gon");

		// Opsionale: Verifikoni nëse emri është shenuar saktë
		ClassicAssert.AreEqual("Rigon", emriKontaktit.GetAttribute("value"));

		// Gjeni butonin Submit klikoni mbi të
		IWebElement submitButton = driver.FindElement(By.XPath("//input[@type='submit' and @value='Dergo']"));
		submitButton.Click();
	}
}
