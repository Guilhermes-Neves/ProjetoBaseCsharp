using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing;
using System.IO;

namespace Commons.Core
{
    public abstract class Driver
    {
        internal ReportHandler reportHandler;

        internal readonly double DRIVER_TIMEOUT = 60;
        internal readonly double METHOD_TIMEOUT = 60;

        internal abstract IWebElement FindElement(By by);

        public abstract void GetScreenshot();

        public abstract void InitiateReport(Report report, string testName);

        internal Image ScreenshotToImage(Screenshot screenshot)
        {
            return Image.FromStream(new MemoryStream(screenshot.AsByteArray));
        }

        public void OnClick(By element, double timeOut)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(timeOut);
            Exception methodException = null;
            string message = $"Clicou no elemento {element} + {DateTime.Now}";

            while (DateTime.Now <= timeoutLimit)
            {
                try
                {
                    FindElement(element).Click();
                    reportHandler.AddLogLine(message, true);
                    return;
                }
                catch (Exception e)
                {
                    methodException = e;
                    continue;
                }
            }
            GetScreenshot();
            reportHandler.CatchTestException(message, methodException);
            throw methodException;
        }

        public string GetText(By element, double timeOut)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(timeOut);
            Exception methodException = null;
            string message = $"Pegou o atributo texto do elemento {element}";

            while (DateTime.Now <= timeoutLimit)
            {
                try
                {
                    string textoElemento = FindElement(element).Text;
                    reportHandler.AddLogLine($"{message} e comparou com o valor {textoElemento}", true);
                    return textoElemento;
                }
                catch (Exception e)
                {
                    methodException = e;
                    continue;
                }
            }

            GetScreenshot();
            reportHandler.CatchTestException(message, methodException);
            throw methodException;
        }

        public void ClearInput(By element, double timeOut)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(timeOut);
            Exception methodException = null;
            string message = $"Limpou o texto do elemento {element}";

            while (DateTime.Now <= timeoutLimit)
            {
                try
                {
                    FindElement(element).Clear();
                    reportHandler.AddLogLine(message, true);
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
            string message = $"Informou o texto {value} no elemento {element}";

            while (DateTime.Now <= timeoutLimit)
            {
                try
                {
                    FindElement(element).SendKeys(value);
                    reportHandler.AddLogLine(message, true);
                    return;
                }
                catch (Exception e)
                {
                    methodException = e;
                    continue;
                }
            }

            GetScreenshot();
            reportHandler.CatchTestException(message, methodException);
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
                    var selectInput = new SelectElement(FindElement(element));
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
                    var selectInput = new SelectElement(FindElement(element));
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
                IWebElement element = FindElement(by);
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
                IWebElement element = FindElement(by);
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
                IWebElement element = FindElement(by);
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
                    IWebElement element = FindElement(by);
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
                    IWebElement element = FindElement(by);
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        

    }
}
