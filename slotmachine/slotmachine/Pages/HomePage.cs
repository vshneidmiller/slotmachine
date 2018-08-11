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
    class HomePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "spinButton")]
        public IWebElement spinButton { get; set; }

        [FindsBy(How = How.Id, Using = "bet")]
        public IWebElement bet { get; set; }

        [FindsBy(How = How.Id, Using = "credits")]
        public IWebElement totalSpins { get; set; }

        [FindsBy(How = How.Id, Using = "lastWin")]
        public IWebElement lastWin { get; set; }

        [FindsBy(How = How.Id, Using = "betSpinUp")]
        public IWebElement betSpinUp { get; set; }

        [FindsBy(How = How.Id, Using = "betSpinDown")]
        public IWebElement betSpinDown { get; set; }

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void ClickSpinButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement spinButton = wait.Until<IWebElement>(d => d.FindElement(By.Id("spinButton")));
            spinButton.Click();    
        }

        public void GoTo()
        {
            driver.Navigate().GoToUrl("http://slotmachinescript.com/");
        }

        public void WaitRoundFinish()
        {
            while (spinButtonDisabled())
            {
            }
        }

        public int GetTotalSpins()
        {
            string totalSpins = driver.FindElement(By.Id("credits")).Text;
            return Convert.ToInt32(totalSpins);
        }

        bool spinButtonDisabled()
        {
            try
            {
                return driver.FindElement(By.ClassName("disabled")).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public int GetLastWinValue()
        {

            WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement lastWin = wait3.Until(ExpectedConditions.ElementExists(By.Id("lastWin")));

            // 'while' loop is just for waiting while lastWin.Text will be a text, instead of ""
            while (lastWin.Text == "")
            {

            }
            return Convert.ToInt32(lastWin.Text);

        }

        public void ClickSpinButtonUntilWin()
        {
            while (driver.FindElement(By.Id("SlotsInnerContainer")).GetCssValue("background-image") == "none")
            {
                Thread.Sleep(10);
                driver.FindElement(By.Id("spinButton")).Click();
            }
        }

        public int GetBet()
        {
            string bet = driver.FindElement(By.Id("bet")).Text;
            return Convert.ToInt32(bet);
        }

    }
}
