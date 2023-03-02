using OpenQA.Selenium;
using TestFramework.Driver;

namespace SystemTests.Pages;

public interface ILoginPage
{
    void SignIn(string userName, string password);
    void NavigateToResources();
}

public class LoginPage : ILoginPage
{
    private readonly IWebDriver _driver;

    public LoginPage(IDriverFixture driverFixture) => _driver = driverFixture.Driver;

    IWebElement UserNameInput => _driver.FindElement(By.XPath("//input[@id='username']"));
    IWebElement PasswordInput => _driver.FindElement(By.XPath("//input[@id='password']"));
    IWebElement SubmitBtn => _driver.FindElement(By.XPath("//button[@id='submit']"));
    IWebElement ResourcesBtn => _driver.FindElement(By.XPath("//a[@href='https://www.gainchanger.com/resources/']"));

    public void SignIn(string userName, string password)
    {
        UserNameInput.SendKeys(userName);
        PasswordInput.SendKeys(password);

        SubmitBtn.Click();
    }

    public void NavigateToResources()
    {
        ResourcesBtn.Click();
    }
}
