using System;
using System.Drawing;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace SelAutomationBasics
{
    [TestClass]//test class attribute 
    public class _01Locators
    {
        [TestMethod]
        public void Navigation()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://uitestpractice.com/Students/Forms";
            driver.Navigate().GoToUrl("https://crickinfo.com");
            driver.Navigate().Back();
            driver.Navigate().Forward();
            driver.Navigate().Refresh();
            driver.Quit();
        }

        [TestMethod]
        public void IWebElementDemo()
        {
            IWebDriver driver = new ChromeDriver();
            //driver.Url = "https://uitestpractice.com/Students/Widget";
            //string tagname = driver.FindElement(By.TagName("h2")).TagName;
            //Console.WriteLine("Tagname: " + tagname);

            //string text = driver.FindElement(By.TagName("h2")).Text;
            //Console.WriteLine("text name: " + text);
            driver.Url = "http://uitestpractice.com/Students/Form";
            //driver.FindElement(By.XPath("//input[@value='dance']")).Click();

            //bool enabled = driver.FindElement(By.XPath("//*[@value='dance']")).Enabled;
            //Console.WriteLine("Enabled: " +enabled);

            //bool displayed = driver.FindElement(By.XPath("//input[@value='dance']")).Displayed;
            //Console.WriteLine("Displayed: " + displayed);


            //bool selected = driver.FindElement(By.XPath("//input[@value='dance']")).Selected;
            //Console.WriteLine("Selected: " + selected);

            Point point = driver.FindElement(By.XPath("//input[@value='dance']")).Location;
            Console.WriteLine("Location: X " +point.X + "\t Location Y" + point.Y );

            Size size = driver.FindElement(By.XPath("//input[@value='dance']")).Size;
            Console.WriteLine("Element Hight:  " + size.Height + "\t Element width" + size.Width);

            //Implicit and explicit wait are using poling machanism. Default poling time is 500ms
            
            driver.Quit();
        }


        [TestMethod]
        public void ContextClick()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "file:///D:/Selenium%20Practice/SeleniumUsingCSharp-master/SeleniumUsingCSharp-master/HTML/Selectable.html";
            Actions actions = new Actions(driver);
            actions.ContextClick(driver.FindElement(By.Name("one"))).Perform();
            Thread.Sleep(5000);


            driver.Quit();
        }

        [TestMethod]
        public void ClickHoldAndRelease()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "file:///D:/Selenium%20Practice/SeleniumUsingCSharp-master/SeleniumUsingCSharp-master/HTML/Selectable.html";
            Actions actions = new Actions(driver);
            actions.ClickAndHold(driver.FindElement(By.Name("one"))).MoveToElement(driver.FindElement(By.Name("twelve"))).Perform();
            Thread.Sleep(5000);

            
            driver.Quit();
        }

        [TestMethod]
        public void JavascriptExecution()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://uitestpractice.com/Students/Widget";



            ((IJavaScriptExecutor)driver).ExecuteScript("alert('Hi hello')");
            Thread.Sleep(2000);
            driver.Quit();
        }

        [TestMethod]
        public void Takescreenshot()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://uitestpractice.com/Students/Widget";


            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("Test.Png", ScreenshotImageFormat.Png);
            Thread.Sleep(2000);
            driver.Quit();
        }


        [TestMethod]
        public void SwitchToFrame()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://uitestpractice.com/Students/Switchto";
            driver.SwitchTo().Frame("iframe_a");
            string text = driver.FindElement(By.TagName("h1")).Text;
            Console.WriteLine(text);
            driver.SwitchTo().DefaultContent();
           
            driver.Quit();
        }


        [TestMethod]
        public void SwitchToWindow()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://uitestpractice.com/Students/Switchto";
            Console.WriteLine("Before click: " +driver.WindowHandles.Count);
            driver.FindElement(By.XPath("//a[contains(text(), 'Opens in a new window')]")).Click();
            Console.WriteLine("after click: " +driver.WindowHandles.Count);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            string dragText = driver.FindElement(By.Id("draggable")).Text;
            Console.WriteLine("Session id's");
            foreach (var items in driver.WindowHandles)
            {
                Console.WriteLine(items);
            }
            driver.Close();
            Console.WriteLine("After close: " +driver.WindowHandles.Count);
            driver.Quit();
        }

        [TestMethod]
        public void HandlingAlerts()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://uitestpractice.com/Students/Switchto";
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("alert")).Click();
           
            IAlert alert = driver.SwitchTo().Alert();
            Console.WriteLine(alert.Text);
            alert.Accept();

            driver.Quit();
        }

        [TestMethod]
        public void SwitchToPrompt()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://uitestpractice.com/Students/Switchto";
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("prompt")).Click();

            IAlert alert = driver.SwitchTo().Alert();

            alert.SendKeys("Hello World");

            driver.Quit();
        }


        [TestMethod]
        public void VerifyAsserts()
        {
            Assert.IsTrue(true, "jhjk");
            string expected = "xyz";
            string actual = "abc";
            Assert.AreEqual(expected, actual);
        }
    }
}
