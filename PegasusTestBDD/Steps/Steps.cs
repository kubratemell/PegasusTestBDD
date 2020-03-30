using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PegasusTestBDD.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace PegasusTestBDD.Steps
{
    [Binding]
    public sealed class Steps
    {
        private readonly ScenarioContext context;
        public IWebDriver driver;
        BasePage basePage;

        public Steps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [BeforeScenario]
        public void Start()
        {
            //Logging.Logger();
            // Optionns oluşturuyoruz
            ChromeOptions options = new ChromeOptions();
            // Setleme işlemini gerçekleştiriyoruz
            options.AddArgument("start-maximized");
            options.AddArgument("disable-popup-blocking");
            options.AddArgument("disable-notifications");
            options.AddArgument("test-type");
            // Driver'a setliyoruz options'ları
            driver = new ChromeDriver(options);
            // Süreler
            //30sn sayfanın yüklenmesini bekler yoksa devam eder.
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            //dolaylı bekleme.1er 1er art ış yapar.
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            // Gidilen sayfa url'i
            driver.Navigate().GoToUrl("https://www.flypgs.com/");
            basePage = new BasePage(driver);
            //log.Info("Driver ayağa kalktı...");
        }

        [Given("'(.*)' alanına tıklanır.")]
        public void Click(string obje)
        {
            basePage.ClickElement(By.XPath(obje));
        }

        [Given("'(.*)' alanına tıkla.")]
        public void CssClick(string css)
        {
            basePage.ClickElement(By.CssSelector(css)); //CssSelectorClick
        }

        [Given("'(.*)' alanına '(.*)' yaz.")]
        public void CssSend(string css, string obje)
        {
            basePage.SendKeys(By.CssSelector(css), obje); //CssSelectorSend
        }

        [Given("'(.*)' alanına '(.*)' yazılır.")]
        public void Send(String str, string obje)
        {
            basePage.SendKeys(By.ClassName(str), obje);
        }

        [Given("'(.*)' alanına '(.*)' yazıldı.")]
        public void Write(String str, string obje)
        {
            basePage.SendKeys(By.XPath(str), obje);
        }

        [Given("'(.*)' alanına '(.*)' girilir.")]
        public void DateSelect(string str, string obje)
        {
            string[] arr = obje.Split(".");

            basePage.DateSelect(str, arr);
        }

        [Given("'(.*)' saniye süreyle beklenir")]
        public void TimeSeconds(int seconds)
        {
            //log.Info(seconds + "Saniye bekleniyor....");
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }

        [AfterScenario]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
