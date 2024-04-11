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
        private WikiPage _WikiPage;
        private string targetPage = "Filozofie";

        [Test]
        public void PhilosophyTest()
        {
            OpenUrl("https://cs.wikipedia.org/wiki");
            OpenArticle("Filozofie");
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
            Thread.Sleep(300);
            _WikiPage.searchBtn.Click();
        }

        public void RedirectPage()
        {         
            int i = 0;
            List<string> pageHistory = new List<string>();
            do
            {
                _WikiPage.GetLink().Click();                                               
                if (i > 1 && pageHistory.Contains(_WikiPage.pageTitle.Text))                    
                {
                    Console.WriteLine("-------------");
                    Console.WriteLine("Cycle detected");
                    break;
                } else
                {
                    Console.WriteLine(_WikiPage.pageTitle.Text);
                    pageHistory.Add(_WikiPage.pageTitle.Text);
                    i++;
                }                
            }
            while (_WikiPage.pageTitle.Text != targetPage);
            
            Console.WriteLine("----------------------");
            Console.WriteLine("Number of redirect = " + i);
        }
     }
}