using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor.PageObjects
{
    public class Useful
    {
        private IWebDriver driver;
        private By elemento;
        private IJavaScriptExecutor webDriver;
        

        public Useful(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FindElement(By elemento)
        {
            return driver.FindElement(elemento);
        }
                       
        public void ClickOn(By elemento, Double timeout)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(timeout);
            Exception methodException = null;

            while (DateTime.Now <= timeoutLimit)
            {
                try
                {
                    IWebElement element = FindElement(elemento);

                    if (element.Displayed && element.Enabled)
                    {
                        IJavaScriptExecutor executor = (IJavaScriptExecutor)webDriver;
                        executor.ExecuteScript("arguments[0].click();", element);
                        return;
                    }
                }
                catch (Exception e)
                {
                    methodException = e;
                    continue;
                }
            }
            throw methodException;

        }
    }
}
