using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace NUnitTestProject
{
    public class Tests
    {

        IWebDriver driver;
        private readonly string startPage = "http://localhost:49961";
        private readonly string artPage = "http://localhost:44306/artview";
        private readonly string teamPage = "http://localhost:49961/Team/ShowTeams";
        private readonly string coachPage = "http://localhost:49961/Coach/ShowCoaches";
        private readonly string studentPage = "http://localhost:49961/Student/ShowStudents";

        [SetUp]
        public void Start_Browser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(startPage);
        }

        [Test]
        public void Test_Start_Page_Blocks_Buttons()
        {
            var inputBlock = driver.FindElement(By.Id("data"));
            Assert.IsNotNull(inputBlock);
            Waiting();
            var btnBlocks = driver.FindElements(By.TagName("a"));
            Assert.IsNotEmpty(btnBlocks);
            var btnBlock = driver.FindElement(By.Id("btnRead"));
            btnBlock.Click();
        }

        [Test]
        public void Test_Add_Delete_Edit_Art()
        {
            driver.Navigate().GoToUrl(artPage);
            var countBeforeAdding = driver.FindElements(By.TagName("tr")).Count;
            var inputData = driver.FindElement(By.Id("addName"));
            inputData.SendKeys("Art");
            inputData = driver.FindElement(By.Id("addCountCountry"));
            inputData.SendKeys("12");
            inputData = driver.FindElement(By.Id("addYear"));
            inputData.SendKeys("1968");
            var btnSubmit = driver.FindElement(By.Id("addArt"));
            btnSubmit.Click();
            Waiting();
            var countAfterAdding = driver.FindElements(By.TagName("tr")).Count;
            Assert.IsTrue(countBeforeAdding < countAfterAdding);
            
            var rowsValues = driver.FindElements(By.TagName("tr"));          
            var chooseValue = rowsValues[8].FindElement(By.Id("editItem"));
            chooseValue.Click();
            inputData = driver.FindElement(By.Id("editName"));
            inputData.Clear();
            inputData.SendKeys("New art");
            inputData = driver.FindElement(By.Id("editCountCountry"));
            inputData.Clear();
            inputData.SendKeys("21");
            inputData = driver.FindElement(By.Id("editYear"));
            inputData.Clear();
            inputData.SendKeys("1986");
            btnSubmit = driver.FindElement(By.Id("editArt"));       
            btnSubmit.Click();
            Waiting();
          
            var count = driver.FindElements(By.Id("delItem")).Count;
            var countBeforeDelete = driver.FindElements(By.TagName("tr")).Count;
            rowsValues = driver.FindElements(By.TagName("tr"));
            chooseValue = rowsValues[count + 7].FindElement(By.Id("delItem"));
            chooseValue.Click();
            Waiting();
            var countAfterDelete = driver.FindElements(By.TagName("tr")).Count;     
            Assert.IsTrue(countBeforeDelete > countAfterDelete);    
        }

        [Test]
        public void Test_Add_Edit_Delete_Team()
        {
            driver.Navigate().GoToUrl(teamPage);
            var addLink = driver.FindElement(By.LinkText("Create a new team"));
            addLink.Click();
            var rowsBeforeCreation = driver.FindElements(By.TagName("tr")).Count;
            addLink = driver.FindElement(By.Id("name"));
            addLink.SendKeys("New team");
            addLink = driver.FindElement(By.Id("coach"));
            addLink.SendKeys("New coach");
            addLink = driver.FindElement(By.Id("organization"));
            addLink.SendKeys("New organization");
            addLink.SendKeys(Keys.Enter);
            var rowsAfterCreation = driver.FindElements(By.TagName("tr")).Count;
            Assert.IsTrue(rowsBeforeCreation < rowsAfterCreation);
          
            var rows = driver.FindElements(By.TagName("tr"));
            var count = driver.FindElements(By.TagName("tr")).Count;
            var choose = rows[count - 1].FindElement(By.LinkText("Edit"));
            choose.Click();
            var inputBlock = driver.FindElement(By.Id("name"));
            inputBlock.Clear();
            inputBlock.SendKeys("Pasha");
            inputBlock.SendKeys(Keys.Enter);
            Waiting();

            var rowsBeforeDeleting = driver.FindElements(By.TagName("tr")).Count;
            rows = driver.FindElements(By.TagName("tr"));
            choose = rows[rowsBeforeDeleting-1].FindElement(By.LinkText("Delete"));
            choose.Click();
            var btnconfirmed = driver.FindElement(By.Id("btnDelete"));
            btnconfirmed.Click();
            var rowsAfterDeleting = driver.FindElements(By.TagName("tr")).Count;
            Assert.IsTrue(rowsBeforeDeleting > rowsAfterDeleting);
            Waiting();
        }

        [Test]
        public void Test_Add_Delete_Coach()
        {
            driver.Navigate().GoToUrl(coachPage);
            var countBeforeAdding = driver.FindElements(By.TagName("tr")).Count;
            var inputData = driver.FindElement(By.Id("name"));
            inputData.SendKeys("Coach");
            inputData = driver.FindElement(By.Id("lastName"));
            inputData.SendKeys("Coach surname");
            inputData = driver.FindElement(By.Id("age"));
            inputData.SendKeys("12");
            var btnSubmit = driver.FindElement(By.Id("addCoach"));
            btnSubmit.Click();
            Waiting();
            var countAfterAdding = driver.FindElements(By.TagName("tr")).Count;
            Assert.IsTrue(countBeforeAdding < countAfterAdding);

            var countBeforeDeleting = driver.FindElements(By.TagName("tr")).Count;
            var rows = driver.FindElements(By.TagName("tr"));
            var chooseValue = rows[countBeforeDeleting - 1].FindElement(By.Id("delete"));
            chooseValue.Click();
            Waiting();
            var countAfterDeleting = driver.FindElements(By.TagName("tr")).Count;
            Assert.IsTrue(countBeforeDeleting > countAfterDeleting);
        }

        [Test]
        public void Test_Action_Link()
        {
            driver.Navigate().GoToUrl(studentPage);
            var addLink = driver.FindElement(By.LinkText("Create New"));
            Assert.IsNotNull(addLink);
            addLink.Click();
            addLink = driver.FindElement(By.LinkText("Back to show students"));
            addLink.Click();
            var currentUrl = driver.Url;
            Assert.AreEqual(studentPage, currentUrl);
            Assert.IsTrue(studentPage.Contains(currentUrl));
            Waiting();
           

        }

        [TearDown]
        public void Close()
        {
            driver.Close();
        }

        private void Waiting()
        {
            Thread.Sleep(5000);
        }

    }
}