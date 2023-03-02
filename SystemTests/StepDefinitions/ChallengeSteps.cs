using SystemTests.Pages;

namespace SystemTests.StepDefinitions
{
    [Binding]
    public class ChallengeSteps
    {
        private readonly ILoginPage _loginPage;
        private readonly IBlogPage _blogPage;
        private readonly IResourcePage _resourcePage;

        public ChallengeSteps(ILoginPage loginPage, IBlogPage blogPage, IResourcePage resourcePage)
        {
            _loginPage = loginPage;
            _blogPage = blogPage;
            _resourcePage = resourcePage;
        }
        
        [Given(@"I login to the app with (.*) (.*) and navigate to resources page")]
        public void GivenILoginToTheAppAndNavigateToResourcesPage(string userName, string password)
        {
            _loginPage.SignIn(userName, password);
            _loginPage.NavigateToResources();
        }

        [When(@"I Access the first blog in the list of blog posts")]
        public void WhenIAccessTheFirstBloginTheListofBlogPosts()
        {
            _resourcePage.GetBlogs(0).Single().Click();          
        }

        [Then(@"I Export a blog model into the json file")]
        public void ThenIExportTheBlogModelIntoTheJsonFile()
        {
            _blogPage.ExtractBlogDataToJson();
        }
    }
}
