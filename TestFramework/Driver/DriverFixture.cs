using TestFramework.Settings;
using OpenQA.Selenium;

namespace TestFramework.Driver;

public class DriverFixture : IDriverFixture, IDisposable
{
    IWebDriver driver;
    private readonly TestSettings testSettings;
    private readonly IBrowserDriver browserDriver;

    public DriverFixture(TestSettings testSettings, IBrowserDriver browserDriver)
    {
        this.testSettings = testSettings;
        this.browserDriver = browserDriver;
        driver = GetWebDriver();
        driver.Navigate().GoToUrl(testSettings.ApplicationUrl);
    }

    public IWebDriver Driver => driver;

    private IWebDriver GetWebDriver()
    {
        return testSettings.BrowserType switch
        {
            BrowserType.Chrome => browserDriver.GetChromeDriver(),
            BrowserType.Firefox => browserDriver.GetFirefoxDriver(),
            _ => browserDriver.GetChromeDriver()
        };
    }

    public void Dispose()
    {
        driver.Quit();
    }
}
