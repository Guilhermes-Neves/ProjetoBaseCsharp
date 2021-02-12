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

            while (DateTime.Now <= timeoutLimit)
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

        public string GetText(By element, double timeOut)
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
                        string textoElemento = driver.FindElement(element).Text;
                        Thread.Sleep(waitTime);
                        return textoElemento;
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

        public void SendKey(By element, string value, double timeOut)
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

        public string GetUrl(string projeto)
        {

            if (projeto == "escritorio")
            {
                string urlEscritorio = "https://hlg-escritorio.styllus.online/#/";
                return urlEscritorio;
            }
            if (projeto == "gestor")
            {
                string urlGestor = "http://localhost:8080/#/";
                return urlGestor;
            }
            if (projeto == "paginaCaptura")
            {
                string urlPaginaCaptura = "https://hlg-revenda.styllus.online/#/";
                return urlPaginaCaptura;
            }
            else
            {
                return "Projeto não entontrado";
            }
        }

        public string UsuarioLogin(string projeto)
        {
            if (projeto == "escritorio")
            {
                string usuarioEscritorio = "650083";
                return usuarioEscritorio;
            }
            if (projeto == "gestor")
            {
                string usuarioGestor = "pedro.albani@portalstyllus.com.br";
                return usuarioGestor;
            }
            else
            {
                return "Projeto não entontrado";
            }

        }

        public string SenhaLogin(string projeto)
        {
            if (projeto == "escritorio")
            {
                string senhaEscritorio = "000158";
                return senhaEscritorio;
            }
            if (projeto == "gestor")
            {
                string senhaGestor = "Styllus2020!@#";
                return senhaGestor;
            }
            else
            {
                return "Projeto não entontrado";
            }

        }

    }
}
