namespace Selenium.PageObject
{
    using OpenQA.Selenium;

    public class WikiPage
    {
        public IWebDriver driver;

        public WikiPage(IWebDriver _driver)
        {
            driver = _driver;
        }

        public IWebElement searchField => driver.FindElement(By.Name("search"));
        public IWebElement searchBtn => driver.FindElement(By.XPath(".//*[@class='cdx-button cdx-button--action-default cdx-button--weight-normal cdx-button--size-medium cdx-button--framed cdx-search-input__end-button']"));
        public IWebElement bodyContent => driver.FindElement(By.Id("bodyContent")).FindElement(By.Id("mw-content-text")).FindElement(By.CssSelector(".mw-content-ltr.mw-parser-output")).FindElement(By.TagName("p"));
        public IWebElement wikiLink => bodyContent.FindElement(By.CssSelector("[href ^= '/wiki/']"));
        public IWebElement firstHeading => driver.FindElement(By.Id("firstHeading"));
        public IWebElement pageTitle => firstHeading.FindElement(By.ClassName("mw-page-title-main"));
        public IWebElement GetLink()
        {
            try
            {
                Console.WriteLine("-> p: " + wikiLink.Text);
                return wikiLink;
            }
            catch (NoSuchElementException)
            {
                try
                {
                    IWebElement wikiLink = driver.FindElement(By.Id("bodyContent")).FindElement(By.Id("mw-content-text")).FindElement(By.CssSelector(".mw-content-ltr.mw-parser-output")).FindElement(By.TagName("ul")).FindElement(By.CssSelector("[href ^= '/wiki/']"));
                    Console.WriteLine("-> ul: " + wikiLink.Text);
                    return wikiLink;
                }
                catch (NoSuchElementException)
                {
                    IWebElement wikiLink = driver.FindElement(By.Id("bodyContent")).FindElement(By.Id("mw-content-text")).FindElement(By.CssSelector(".mw-content-ltr.mw-parser-output")).FindElement(By.CssSelector("[href ^= '/wiki/']"));
                    Console.WriteLine("-> " + wikiLink.Text);
                    return wikiLink;
                }             
            }       
        }
    }
}