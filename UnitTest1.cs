using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestySelenium1
{
    public class Tests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void ZapisPustychPLFormularza()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("First name must be filled out", CloseAlertAndGetItsText());
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("test");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("Nazwisko musi byc wypelnione", CloseAlertAndGetItsText());
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("test");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("Data urodzenia nie moze byc pusta", CloseAlertAndGetItsText());
            driver.FindElement(By.XPath("//div[@id='nazwisko']/div[2]")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("02.12.2000");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("Nazwisko musi byc wypelnione", CloseAlertAndGetItsText());
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("test");
            driver.FindElement(By.Id("imie")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("First name must be filled out", CloseAlertAndGetItsText());
        }

        [Test]
        public void aktualnaDataUroTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("Test");
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("Test");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("17-01-2021");
            driver.FindElement(By.Id("rodzice")).Click();
            driver.FindElement(By.Id("lekarz")).Click();
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
        }
            [Test]
        public void ponizejOczekiwanegoWiekuTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("Test");
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("Test");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("01-01-2011");
            driver.FindElement(By.Id("rodzice")).Click();
            driver.FindElement(By.Id("lekarz")).Click();
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
        }
        [Test]
        public void grupaSkrzatTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("test");
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("test");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("02.12.2010");
            driver.FindElement(By.XPath("//form[@id='formma']/div[4]/div/div/label")).Click();
            driver.FindElement(By.Id("lekarz")).Click();
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("Skrzat", CloseAlertAndGetItsText());
        }
        [Test]
        public void GrupaMlodzikTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("Test");
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("Test");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("01-01-2009");
            driver.FindElement(By.Id("rodzice")).Click();
            driver.FindElement(By.Id("lekarz")).Click();
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
        }
        [Test]
        public void GrupaMlodzikBrakzgodTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("Test");
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("Test");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("01-01-2009");            
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
        }
        [Test]
        public void ZaMlodyNagrupeMlodzikTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("Test");
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("Test");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("01-01-2011");
            driver.FindElement(By.Id("rodzice")).Click();
            driver.FindElement(By.Id("lekarz")).Click();
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
        }
        [Test]
        public void JuniorDolnaGranicaWiekuTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("Test");
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("Test");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("30-12-2007");
            driver.FindElement(By.Id("rodzice")).Click();
            driver.FindElement(By.Id("lekarz")).Click();
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
        }
        [Test]
        public void GrupaJuniorTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("Test");
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("Test");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("01-01-2007");
            driver.FindElement(By.Id("rodzice")).Click();
            driver.FindElement(By.Id("lekarz")).Click();
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
        }
        [Test]
        public void JuniorGornaGranicaWiekuTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("Test");
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("Test");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("01-01-2003");
            driver.FindElement(By.Id("rodzice")).Click();
            driver.FindElement(By.Id("lekarz")).Click();
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
        }
        
        [Test]
        public void GrupaDoroslyTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("Test");
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("Test");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("01-01-2002");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
        }
        [Test]
        public void DorosliZaznCheckTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("Test");
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("Test");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("01-01-2002");
            driver.FindElement(By.Id("rodzice")).Click();
            driver.FindElement(By.Id("lekarz")).Click();
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
        }
        [Test]
        public void dorosliGornaGranicaWIekuTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("Test");
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("TEst");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("17-01-1956");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
        }
        [Test]
        public void GrupaSeniorTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("Test");
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("Test");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("30-12-1955");
            driver.FindElement(By.Id("lekarz")).Click();
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
        }
        [Test]
        public void GrupaSeniorCheckBrakTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("Test");
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("Test");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("01-01-1955");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
        }
        [Test]
        public void GrupaSeniorZlaDataTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("Test");
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("Test");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("12.10.1800");
            driver.FindElement(By.Id("lekarz")).Click();
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
        }
        [Test]
        public void CYfryWImieTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("12222");
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("Test");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("12.12.1999");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
        }
        [Test]
        public void CYfryWNazwiskoTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("Test");
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("345435345");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("12.12.1999");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
        }
        [Test]
        public void LiteryWDataTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("Test");
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("Test");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("asdasd");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
        }
        [Test]
        public void BladDatyRokTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("Test");
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("Test");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("2001");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
        }
        [Test]
        public void BlednaDataTest()
        {
            driver.Navigate().GoToUrl("https://lamp.ii.us.edu.pl/~mtdyd/zawody/");
            driver.FindElement(By.Id("inputEmail3")).Click();
            driver.FindElement(By.Id("inputEmail3")).Clear();
            driver.FindElement(By.Id("inputEmail3")).SendKeys("Test");
            driver.FindElement(By.Id("inputPassword3")).Click();
            driver.FindElement(By.Id("inputPassword3")).Clear();
            driver.FindElement(By.Id("inputPassword3")).SendKeys("Test");
            driver.FindElement(By.Id("dataU")).Click();
            driver.FindElement(By.Id("dataU")).Clear();
            driver.FindElement(By.Id("dataU")).SendKeys("50-32-2021");
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}