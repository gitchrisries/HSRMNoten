using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.IO;
using HtmlAgilityPack;
using System.Data;
using System.Collections;
using HSRMNoten;
using System.Reflection;

namespace HSRMNoten.Classes
{
    public class ReadHTML
    {


        public static HtmlDocument navigateToGradesFirefox(string user, string pw, bool dual)
        {

                string geckoDriverDirectory = Environment.CurrentDirectory;
                var geckoService = FirefoxDriverService.CreateDefaultService(geckoDriverDirectory);
                geckoService.Host = "::1";
                var firefoxOptions = new FirefoxOptions();
                firefoxOptions.AddArgument("-headless");
                geckoService.HideCommandPromptWindow = true;
                firefoxOptions.AcceptInsecureCertificates = true;
                var driver = new FirefoxDriver(geckoService, firefoxOptions);

            driver.Navigate().GoToUrl(@"https://wwwqis-2rz.itmz.hs-rm.de/qisserver/rds?state=user&type=0&topitem=&breadCrumbSource=&topitem=functions");

            IWebElement userName = driver.FindElement(By.Id("asdf"));
            userName.Clear();
            userName.SendKeys(user);

            IWebElement passwordBox = driver.FindElement(By.Id("fdsa"));
            passwordBox.Clear();
            passwordBox.SendKeys(pw);

            IWebElement loginButton = driver.FindElement(By.Id("loginForm:login"));
            loginButton.Click();

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            try
            {
                IWebElement pruefung = driver.FindElement(By.XPath("//*[contains(text(), 'Prüfungsverwaltung')]"));
                pruefung.Click();
            }
            catch (Exception)
            {
                driver.Close();
                geckoService.Dispose();
                return null;
            }


            IWebElement notenspiegel = driver.FindElement(By.XPath("//*[contains(text(), 'Notenspiegel (NUR ZUR INFO!!!)')]"));
            notenspiegel.Click();

            IWebElement bachelor = driver.FindElement(By.XPath("//*[contains(text(), 'Abschluss Bachelor')]"));
            bachelor.Click();

            if (dual)
            {
                try
                {
                    IWebElement info = driver.FindElement(By.XPath("//a[@title='Leistungen für Angewandte Informatik (dual)  (PO-Version 2016)  anzeigen']"));
                    info.Click();
                }
                catch (Exception)
                {
                    driver.Close();
                    geckoService.Dispose();
                    return null;
                }

            }
            else
            {
                try
                {
                    IWebElement info = driver.FindElement(By.XPath("//a[@title='Leistungen für Angewandte Informatik  (PO-Version 2017)  anzeigen']"));
                    info.Click();
                }
                catch (Exception)
                {
                    driver.Close();
                    geckoService.Dispose();
                    return null;
                }

            }


            var doc = new HtmlDocument();
            doc.LoadHtml(@driver.PageSource);
            driver.Close();
            geckoService.Dispose();
            return doc;

        }

        public static HtmlDocument navigateToGradesChrome(string user, string pw, bool dual)
        {

            string geckoDriverDirectory = Environment.CurrentDirectory;
            var geckoService = ChromeDriverService.CreateDefaultService(geckoDriverDirectory);
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("-headless");
            geckoService.HideCommandPromptWindow = true;
            chromeOptions.AcceptInsecureCertificates = true;
            var driver = new ChromeDriver(geckoService, chromeOptions);

            driver.Navigate().GoToUrl(@"https://wwwqis-2rz.itmz.hs-rm.de/qisserver/rds?state=user&type=0&topitem=&breadCrumbSource=&topitem=functions");

            IWebElement userName = driver.FindElement(By.Id("asdf"));
            userName.Clear();
            userName.SendKeys(user);

            IWebElement passwordBox = driver.FindElement(By.Id("fdsa"));
            passwordBox.Clear();
            passwordBox.SendKeys(pw);

            IWebElement loginButton = driver.FindElement(By.Id("loginForm:login"));
            loginButton.Click();

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            try
            {
                IWebElement pruefung = driver.FindElement(By.XPath("//*[contains(text(), 'Prüfungsverwaltung')]"));
                pruefung.Click();
            }
            catch (Exception)
            {
                driver.Close();
                geckoService.Dispose();
                return null;
            }
            

            IWebElement notenspiegel = driver.FindElement(By.XPath("//*[contains(text(), 'Notenspiegel (NUR ZUR INFO!!!)')]"));
            notenspiegel.Click();

            IWebElement bachelor = driver.FindElement(By.XPath("//*[contains(text(), 'Abschluss Bachelor')]"));
            bachelor.Click();
            
            if (dual)
            {
                try
                {
                    IWebElement info = driver.FindElement(By.XPath("//a[@title='Leistungen für Angewandte Informatik (dual)  (PO-Version 2016)  anzeigen']"));
                    info.Click();
                }
                catch (Exception)
                {
                    driver.Close();
                    geckoService.Dispose();
                    return null;
                }

            }
            else
            {
                try
                {
                    IWebElement info = driver.FindElement(By.XPath("//a[@title='Leistungen für Angewandte Informatik  (PO-Version 2017)  anzeigen']"));
                    info.Click();
                }
                catch (Exception)
                {
                    driver.Close();
                    geckoService.Dispose();
                    return null;
                }

            }


            var doc = new HtmlDocument();
            doc.LoadHtml(@driver.PageSource);
            driver.Close();
            geckoService.Dispose();
            return doc;
        }


        public static List<List<string>> parseTable(HtmlDocument doc)
        {
            if (doc == null) return null;

            List<List<string>> table = doc.DocumentNode.SelectNodes("//table/tbody")
            .Descendants("tr")
            .Skip(1)
            .Where(tr => tr.Elements("td").Count() > 1)
            .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
            .ToList();

            return table;
        }


    }
}
