namespace Selenium
{
    using System;
    using System.Threading;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using Selenium.PageObject;

    public class Test
    {
        private IWebDriver driver = new ChromeDriver();
        private WikiPage? _WikiPage;
        private string page = "Filozofie";

        [Test]
        public void PhilosophyTest()
        {
            OpenUrl("https://cs.wikipedia.org/wiki");
            OpenArticle(page);
            RedirectPage();
            driver.Close();
        }

        public void OpenUrl(string url)
        {            
            driver.Manage().Window.Maximize();
            driver.Url = url;            
        }

        public void OpenArticle(string article)
        {
            _WikiPage = new WikiPage(driver);
            _WikiPage.searchField.SendKeys(article);
            Thread.Sleep(100);
            _WikiPage.searchBtn.Click();
        }

        public void RedirectPage()
        {
            _WikiPage = new WikiPage(driver);            
            int i = 0; 
            do
            {
                _WikiPage.GetLink().Click();
                Console.WriteLine(_WikiPage.pageTitle.Text);
                i++;
            }
            while (_WikiPage.pageTitle.Text != page);
            
            Console.WriteLine("----------------------");
            Console.WriteLine("Number of redirect = " + i);
        }

        
    }
}