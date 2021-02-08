using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Common
{
    public class Utilitarios
    {
        private IWebDriver driver;
        int waitTime = 800;

        public Utilitarios(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OnClick(By element, double timeOut)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(timeOut);
            Exception methodException = null;

            while(DateTime.Now <= timeoutLimit)
            {
                try
                {
                    if (true)
                    {
                        Thread.Sleep(waitTime);
                        driver.FindElement(element).Click();
                        Thread.Sleep(waitTime);
                        return;
                    }
                }
                catch (Exception e)
                {
                    methodException = e;
                    continue;
                }
            }
            Thread.Sleep(waitTime);
            throw methodException;
        }

        public void ClearInput(By element, double timeOut)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(timeOut);
            Exception methodException = null;

            while (DateTime.Now <= timeoutLimit)
            {
                try
                {
                    if (true)
                    {
                        Thread.Sleep(waitTime);
                        driver.FindElement(element).Clear();
                        Thread.Sleep(waitTime);
                        return;
                    }
                }
                catch (Exception e)
                {
                    methodException = e;
                    continue;
                }
            }
            Thread.Sleep(waitTime);
            throw methodException;
        }

        public void SendKey(By element, string value ,double timeOut)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(timeOut);
            Exception methodException = null;

            while (DateTime.Now <= timeoutLimit)
            {
                try
                {
                    if (true)
                    {
                        Thread.Sleep(waitTime);
                        driver.FindElement(element).SendKeys(value);
                        Thread.Sleep(waitTime);
                        return;
                    }
                }
                catch (Exception e)
                {
                    methodException = e;
                    continue;
                }
            }
            Thread.Sleep(waitTime);
            throw methodException;
        }

        public void SelectValue(By element, string value, double timeOut)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(timeOut);
            Exception methodException = null;

            while (DateTime.Now <= timeoutLimit)
            {
                try
                {
                    if (true)
                    {
                        Thread.Sleep(waitTime);
                        var selectInput = new SelectElement(driver.FindElement(element));
                        selectInput.SelectByValue(value);

                        Thread.Sleep(waitTime);
                        return;
                    }
                }
                catch (Exception e)
                {
                    methodException = e;
                    continue;
                }
            }
            Thread.Sleep(waitTime);
            throw methodException;
        }

        public void SelectText(By element, string value, double timeOut)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(timeOut);
            Exception methodException = null;

            while (DateTime.Now <= timeoutLimit)
            {
                try
                {
                    if (true)
                    {
                        Thread.Sleep(waitTime);
                        var selectInput = new SelectElement(driver.FindElement(element));
                        selectInput.SelectByText(value);

                        Thread.Sleep(waitTime);
                        return;
                    }
                }
                catch (Exception e)
                {
                    methodException = e;
                    continue;
                }
            }
            Thread.Sleep(waitTime);
            throw methodException;
        }
    }
}
