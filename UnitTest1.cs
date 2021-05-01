using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace JoePizzaTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://shashwatsapp.azurewebsites.net/");

                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(
                    d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                    );
                var cheeseburst = driver.FindElementById("add-1");
                Assert.IsNotNull(cheeseburst);
                cheeseburst.Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(
                    d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                    );

                var cartbtn = driver.FindElementById("cart-btn");
                Assert.IsNotNull(cartbtn);
                cartbtn.Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(
                    d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                    );
                var result = driver.PageSource.Contains("Cheese burst");
                Assert.IsTrue(result);
                var placeorderbuton = driver.FindElementById("order-btn");
                Assert.IsNotNull(placeorderbuton);
                placeorderbuton.Click();
                var alert = driver.SwitchTo().Alert();
                var orderstatus = alert.Text;
                Assert.AreEqual("order successful", orderstatus);
            }
        }
    }
}
