using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;
using NUnit.Framework.Legacy;

namespace MessageContactTests
{
	[TestFixture]
	public class MessageContactTests
	{
		private IWebDriver driver;

		[SetUp]
		public void SetUp()
		{
			var options = new ChromeOptions();
			var service = ChromeDriverService.CreateDefaultService(@"C:\Users\lenovo\Desktop\Testimi dhe Mirëmbajtja e Softuerit\Testimi me Selenium\SeleniumProject\packages\Selenium.WebDriver.ChromeDriver.125.0.6422.6000\driver\win32");
			driver = new ChromeDriver(service, options);
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			driver.Manage().Window.Maximize();
		}

		[Test]
		public void TestTextareaMesazhi()
		{
			driver.Navigate().GoToUrl("http://localhost:5174/contact"); // Adjust URL to your local server

			// Find the textarea by its placeholder attribute and enter some text
			IWebElement textareaMesazhi = driver.FindElement(By.XPath("//textarea[@id='contact-message']"));
			string testMessage = " Pershendetje, ne jemi student te UBT-se !";
			textareaMesazhi.SendKeys(testMessage);

			// Verify the entered text in the textarea
			ClassicAssert.AreEqual(testMessage, textareaMesazhi.GetAttribute("value"));

			// Find the submit button and click it
			IWebElement submitButton = driver.FindElement(By.XPath("//input[@type='submit' and @value='Dergo']"));
			submitButton.Click();

			// Optionally, verify the success message after form submission
			IWebElement successMessage = driver.FindElement(By.XPath("//p[contains(text(),'Mesazhi u dërgua me sukses!')]"));
			ClassicAssert.IsTrue(successMessage.Displayed);

			// Print a success message
			Console.WriteLine(" Testi u krye me sukses: Mesazhi u shkrua dhe forma u dergua me sukses !");
		}

		[TearDown]
		public void TearDown()
		{
			driver.Quit();
		}
	}
}
