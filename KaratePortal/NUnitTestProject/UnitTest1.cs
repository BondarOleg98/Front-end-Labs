using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace NUnitTestProject
{
    public class Tests
    {

        IWebDriver driver = new ChromeDriver();

        //[SetUp]
        //public void startBrowser()
        //{
        //    driver = new ChromeDriver("C:\\Program Files(x86)\\Google\\Chrome\\Application\\chromedriver.exe");
        //}

        [Test]
        public void test()
        {
            driver.Navigate().GoToUrl("http://localhost:49961/Team/ShowStudentTeam");
           
        }

        //[TearDown]
        //public void closeBrowser()
        //{
        //    driver.Close();
        //}
    }
}