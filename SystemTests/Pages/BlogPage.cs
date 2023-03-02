using OpenQA.Selenium;
using TestFramework.Contracts;
using TestFramework.Driver;
using TestFramework.Extensions;

namespace SystemTests.Pages
{
    public interface IBlogPage
    {
        void ExtractBlogDataToJson();
    }

    public class BlogPage : IBlogPage
    {
        private readonly IWebDriver _driver;

        public BlogPage(IDriverFixture driverFixture) => _driver = driverFixture.Driver;

        IWebElement Title => _driver.FindElement(By.XPath("//meta[@property='og:title']"));
        IWebElement Description => _driver.FindElement(By.XPath("//meta[@property='og:description']"));
        IWebElement H1Header => _driver.FindElement(By.XPath("//div[@class = 'elementor-widget-container']//h1"));
        IReadOnlyCollection<IWebElement> H2Headers => _driver.FindElements(By.XPath("//div[@class = 'elementor-widget-container']//h2"));
        IReadOnlyCollection<IWebElement> Paragraphs => _driver.FindElements(By.XPath("//div[@class = 'elementor-widget-container']//p"));
  
        public void ExtractBlogDataToJson()
        { 
            var data = new BlogSource
            {
                Title = Title.GetAttribute("content"),
                Description = Description.GetAttribute("content"),
                H1Header = H1Header.Text,
                H2Headers = H2Headers.Select(x => x.Text).ToArray(),
                Paragraphs = Paragraphs.Select(x => x.Text).ToArray()
            };

            data.ExtractToJson<BlogSource>();
        }
    }
}
