using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace slotmachine
{
    class TestChangeBetAndPlay
    {

        [Test]
        [Description("Verify Total Spins calculated correctly after Bet double-click and one round played")]
        public void ChangeBetAndPlay()
        {
            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);
         

            home.GoTo();
            driver.Manage().Window.Maximize();

            // click twice on BetSpinUp in order to increase Bet
            int numberOfBetClick = 2;
            for (int i = 0; i < numberOfBetClick; i++)
            {
                home.betSpinUp.Click();
                            }

            int bet = home.GetBet();

            int totalSpinsBeforeSpin = home.GetTotalSpins();
            int totalSpinsBeforeWin = totalSpinsBeforeSpin - bet;

               home.ClickSpinButton();
               home.WaitRoundFinish();


            if (home.lastWin.Text.Length > 0)
            {
                
                home.WaitRoundFinish();
                int totalSpinsAfterWin = home.GetTotalSpins();
                int expectedTotalSpinsAfterWin = totalSpinsBeforeWin + home.GetLastWinValue();

                Assert.IsTrue(expectedTotalSpinsAfterWin == totalSpinsAfterWin);

            }
            else
            {
                Console.WriteLine("I am else");
                Assert.IsTrue(totalSpinsBeforeSpin == (home.GetTotalSpins() + numberOfBetClick + 1));
            }

            driver.Quit();


        }


    }
}
