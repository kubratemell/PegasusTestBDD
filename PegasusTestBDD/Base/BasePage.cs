using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PegasusTestBDD.Base
{
    class BasePage
    {
        IWebDriver driver;
        WebDriverWait wait;
        IReadOnlyList<IWebElement> result;
        IJavaScriptExecutor scriptExecutor;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
        }

        public IWebElement FindElement(By by)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            HighLightElement(by);
            return driver.FindElement(by);
        }

        public void ClickElement(By by)
        {
            Thread.Sleep(5);
            FindElement(by).Click();
        }

        public void SendKeys(By by, string location)
        {
            FindElement(by).SendKeys(location);
            FindElement(by).SendKeys(Keys.Enter);
        }

        public void DateSelect(string str, string[] arr)
        {
            if(str.Contains("Gidiş"))
            {
                YearSelect(str, arr[2], "//*[@id='search-flight-datepicker-departure']/div/div[1]/div/div/span[2]");
                MonthSelect(str, arr[1], "//*[@id='search-flight-datepicker-departure']/div/div[1]/div/div/span[1]");
                DaySelect(str, arr[0], "//*[@id='search-flight-datepicker-departure']/div/div[1]//tbody//a");
            }
            else if(str.Contains("Dönüş"))
            {
                YearSelect(str, arr[2], "//*[@id='search-flight-datepicker-arrival']/div/div[1]/div/div/span[2]");
                MonthSelect(str,arr[1], "//*[@id='search-flight-datepicker-arrival']/div/div[1]/div/div/span[1]");
                DaySelect(str, arr[0], "//*[@id='search-flight-datepicker-arrival']/div/div[1]//tbody//a");
            }
        }

       
        public void YearSelect(string arrowClick, string year, string str)
        {
            if(arrowClick.Contains("Gidiş"))
            {
                SelectYear(By.XPath(str), year, "//*[@id='search-flight-datepicker-departure']/div/div[2]/div/a");
            }
            else if(arrowClick.Contains("Dönüş"))
            {
                SelectYear(By.XPath(str), year, "//*[@id='search-flight-datepicker-arrival']/div/div[2]/div/a");
            }
        }

        public void MonthSelect(string arrowClick, string month, string str)
        {
            if(arrowClick.Contains("Gidiş"))
            {
                SelectMonth(By.XPath(str), month, "//*[@id='search-flight-datepicker-departure']/div/div[2]/div/a");
            }
            else if(arrowClick.Contains("Dönüş"))
            {
                SelectMonth(By.XPath(str), month, "//*[@id='search-flight-datepicker-arrival']/div/div[2]/div/a");
            }
        }

        public void DaySelect(string click, string day, string str)
        {
            SelectDay(str, day);
        }

        public void SelectYear(By by, string years, string arrowclick)
        {
            string str;
            while (true)
            {
                str = FindElement(by).Text;
                if (str.Equals(years))
                    break;
                ClickElement(By.XPath(arrowclick));
            }
        }

        public void SelectMonth(By by, string months, string arrowclick)
        {
            string str;
            while (true)
            {
                str = FindElement(by).Text;
                if (str.Equals(months))
                    break;
                ClickElement(By.XPath(arrowclick));
            }
        }

        public void SelectDay(string value, string days)
        {
            result = driver.FindElements(By.XPath(value));

            foreach (var res in result)
            {
                if (res.Text.Equals(days))
                {
                    res.Click();
                    break;
                }
            }
        }

        public void HighLightElement(By by)
        {
            scriptExecutor = (IJavaScriptExecutor)driver;
            scriptExecutor.ExecuteScript("arguments[0].setAttribute('style', 'background: yellow; border: 2px solid red;');", driver.FindElement(by));
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
        }
    }
}
