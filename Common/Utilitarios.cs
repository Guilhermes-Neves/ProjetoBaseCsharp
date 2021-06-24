using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Common
{
    public class Utilitarios
    {
        internal ReportHandler reportHandler;
        private IWebDriver driver;
        int waitTime = 900;

        public Utilitarios(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GetScreenshot()
        {
            string message = "Tirou screenshot";

            try
            {
                reportHandler.AddEvidence();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void OnClick(By element, double timeOut)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(timeOut);
            Exception methodException = null;

            while (DateTime.Now <= timeoutLimit)
            {
                try
                {
                    driver.FindElement(element).Click();
                    return;
                }
                catch (Exception e)
                {
                    methodException = e;
                    continue;
                }
            }
            throw methodException;
        }

        public string GetText(By element, double timeOut)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(timeOut);
            Exception methodException = null;

            while (DateTime.Now <= timeoutLimit)
            {
                try
                {
                    string textoElemento = driver.FindElement(element).Text;
                    return textoElemento;
                }
                catch (Exception e)
                {
                    methodException = e;
                    continue;
                }
            }
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
                    driver.FindElement(element).Clear();
                    return;
                }
                catch (Exception e)
                {
                    methodException = e;
                    continue;
                }
            }
            throw methodException;
        }

        public void SendKey(By element, string value, double timeOut)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(timeOut);
            Exception methodException = null;

            while (DateTime.Now <= timeoutLimit)
            {
                try
                {
                    driver.FindElement(element).SendKeys(value);
                    return;
                }
                catch (Exception e)
                {
                    methodException = e;
                    continue;
                }
            }
        }

        public void SelectValue(By element, string value, double timeOut)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(timeOut);
            Exception methodException = null;

            while (DateTime.Now <= timeoutLimit)
            {
                try
                {
                    var selectInput = new SelectElement(driver.FindElement(element));
                    selectInput.SelectByValue(value);
                    return;
                }
                catch (Exception e)
                {
                    methodException = e;
                    continue;
                }
            }
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
                    var selectInput = new SelectElement(driver.FindElement(element));
                    selectInput.SelectByText(value);
                    return;
                }
                catch (Exception e)
                {
                    methodException = e;
                    continue;
                }
            }
            throw methodException;
        }

        public bool IsElementDisplayed(By by)
        {
            try
            {
                IWebElement element = driver.FindElement(by);
                return element.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public bool IsElementEnabled(By by)
        {
            try
            {
                IWebElement element = driver.FindElement(by);
                return element.Enabled;
            }
            catch
            {
                return false;
            }
        }

        public bool IsElementSelected(By by)
        {
            try
            {
                IWebElement element = driver.FindElement(by);
                return element.Selected;
            }
            catch
            {
                return false;
            }
        }

        public void WaitUntilElementAppear(By by, double timeout)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(timeout);

            while (DateTime.Now <= timeoutLimit)
            {
                try
                {
                    IWebElement element = driver.FindElement(by);
                    return;
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }

        public void WaitUntilElementDesappear(By by, double timeout)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(timeout);

            while (DateTime.Now <= timeoutLimit)
            {
                try
                {
                    IWebElement element = driver.FindElement(by);
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        public int GetElementCount(string by, double timeout)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(timeout);
            Exception methodException = new Exception();

            while (DateTime.Now <= timeoutLimit)
            {
                try
                {
                    return driver.ElementCount(by);
                } 
                catch
                {

                }
                
            }

            return 0;
        }

        public void Refresh()
        {
            try
            {
                driver.Navigate().Refresh();
            }
            catch (Exception methodException)
            {
                throw methodException;
            }
        }
    }
}
