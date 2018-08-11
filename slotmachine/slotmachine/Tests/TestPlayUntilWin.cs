using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slotmachine.Tests
{
    class TestPlayUntilWin
    {
        [Test]
        [Description("Verify if the win was added correctly to TOTAL SPINS")]

        public void PlayUntilWin()
        {
            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);
            driver.Manage().Window.Maximize();

            home.GoTo();
            home.ClickSpinButtonUntilWin();

            int totalSpinsBeforeWin = home.GetTotalSpins();
            Console.WriteLine("totalSpinsBeforeWin = " + totalSpinsBeforeWin);

            home.WaitRoundFinish();
            
            Assert.IsTrue(home.GetTotalSpins() == (totalSpinsBeforeWin + home.GetLastWinValue()));

            driver.Quit();
        }

    }
}
