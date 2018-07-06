using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SelAutomationBasics
{
    [TestClass]
    public class AvoidingCodeRedundency
    {
        //Types of variables
        //Static variables
        //class level variable (instance variable)
        //Local variable
        //Block level variable

        //Encapsulation - grouping of related things

        private IWebDriver driver;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            Console.WriteLine("Assembly initialize method");
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            Console.WriteLine("Class initialize method");
        }


        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Url = "http://uitestpractice.com/Students/Forms";
            Console.WriteLine("Testinitialize method");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
            Console.WriteLine("Test cleanup method");
        }


        [ClassCleanup]
        public static void ClassCleanup()
        {
            Console.WriteLine("Class cleanup method");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            Console.WriteLine("Assembly cleanup method");
        }
        [TestMethod]
        public void DemoTest()
        {
            Console.WriteLine("Within test1 methos");
        }


        [TestMethod]
        public void DemoTest1()
        {
            Console.WriteLine("Within test2 methos");
        }



    }
}
