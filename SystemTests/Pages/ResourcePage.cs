using OpenQA.Selenium;
using TestFramework.Driver;

namespace SystemTests.Pages
{
    public interface IResourcePage
    {
        IEnumerable<IWebElement> GetBlogs(params int[] indexes);
    }

    public class ResourcePage : IResourcePage
    {
        private readonly IWebDriver driver;

        public ResourcePage(IDriverFixture driverFixture) => driver = driverFixture.Driver;

        IReadOnlyCollection<IWebElement> Blogs => driver.FindElements(By.XPath("//div[@class ='elementor-post__card']"));

        public IEnumerable<IWebElement> GetBlogs(params int[] indexes)
        {
            var blogList = Blogs.ToArray();

            foreach (var index in indexes)
            {
                yield return blogList[index];
            }
        }
    }
}
