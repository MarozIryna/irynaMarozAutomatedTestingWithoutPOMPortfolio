using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace piguLtLoginScenario
{
    public class PiguLtLoginTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test, Order(1)]
        public void LoginToPiguLtWithValidCredentials()
        {
            driver.Navigate().GoToUrl("https://pigu.lt/lt/");
            System.Threading.Thread.Sleep(1000);
            IWebElement closeCookies = driver.FindElement(By.XPath("//*[@id='cookie_block']/div/div/div[2]/div[2]/button[3]"));
            closeCookies.Click();
            System.Threading.Thread.Sleep(1000);
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='headeMenu']/li[1]/a/i"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(loginButton);
            actions.Perform();
            IWebElement prisijungtiButton = driver.FindElement(By.XPath("//*[@id='headeMenu']/li[1]/div/div/div[2]/a[1]"));
            prisijungtiButton.Click();
            IWebElement usernameInput = driver.FindElement(By.XPath("//*[@id='loginModal']/div[1]/div[1]/form/div[3]/input"));
            IWebElement passwordInput = driver.FindElement(By.XPath("//*[@id='passwordCont']/input"));

            usernameInput.SendKeys("testastest40@gmail.com");
            passwordInput.SendKeys("testas");

            IWebElement loginSubmitButton = driver.FindElement(By.XPath("//*[@id='loginModal']/div[1]/div[1]/form/div[6]/input"));
            loginSubmitButton.Click();

            IWebElement loginButton2 = driver.FindElement(By.XPath("//*[@id='headeMenu']/li[1]/a/i"));
            actions.MoveToElement(loginButton2);
            actions.Perform();
            string expectedLogInSuccessed = "Sveiki, testastest40@gmail.com!";
            IWebElement logInResult = driver.FindElement(By.XPath("//*[@id='headeMenu']/li[1]/div/div/div/div[2]/p"));
            Assert.That(expectedLogInSuccessed, Is.EqualTo(logInResult.Text));
        }   
        [TearDown]
            public void TearDown()
            {
                driver.Quit();
            }
    }
}