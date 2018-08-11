using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace slotmachine
{
    class TestPlayOneRound
    {

        [Test]
        [Description("Verify an ability to play one round")]

        public void PlayOneRound()
        {
            IWebDriver driver = new ChromeDriver();
            HomePage home = new HomePage(driver);

            home.GoTo();
            driver.Manage().Window.Maximize();

            home.ClickSpinButton();
            home.WaitRoundFinish();

            driver.Quit();

        }
    }
}
