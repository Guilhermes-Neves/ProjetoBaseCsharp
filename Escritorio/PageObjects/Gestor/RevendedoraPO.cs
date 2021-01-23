using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gestor.PageObjects
{
    public class RevendedoraPO
    {
        private IWebDriver driver;
        private By byInputCpf;
        private By byBotaoBuscar;
        private By byEditarRevendedora;
        private By byTabCashBack;
        private By byBotaoAdicionarCashback;
        private By byInputValorCashback;
        private By byInputDataCashback;
        private By byBotaoSalvar;
        private By byMensagemSucesso;
        private By byInputAccount;
        private By byLinkRevendedoras;
        private By byBotaoDeletar;
        private By byBotaoProssiga;

        public RevendedoraPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputCpf = By.XPath("/html/body/div[1]/div/main/div/div[2]/div[1]/div[2]/div/div[1]/div[3]/div/div/div/input");
            byBotaoBuscar = By.CssSelector("button.v-btn.primary");
            byLinkRevendedoras = By.XPath("/html/body/div[1]/div/nav/div[2]/div[2]/a[2]");
            byEditarRevendedora = By.XPath("/html/body/div[1]/div/main/div/div[2]/div[1]/div[2]/div/div[2]/div[1]/table/tbody/tr/td[10]/a");
            byTabCashBack = By.XPath("/html/body/div[1]/div/main/div/div[2]/div/div/div/div/div[1]/div[2]/div/div[6]");
            byBotaoAdicionarCashback = By.CssSelector("button.indigo");
            byInputValorCashback = By.CssSelector("input[name='valor']");
            byInputDataCashback = By.CssSelector("input[name='expiresAt']");
            byBotaoSalvar = By.CssSelector("button.success--text");
            byMensagemSucesso = By.CssSelector("p.toast-text");
            byInputAccount = By.ClassName("mdi-account");
            byBotaoDeletar = By.XPath("/html/body/div/div/main/div/div[2]/div[2]/div/div/div/div[2]/div/div[2]/div/div/div[1]/div/div[1]/div[2]/div[1]/table/tbody/tr/td[6]/button");
            byBotaoProssiga = By.XPath("/html/body/div/div[3]/div/div/div[3]/button[2]");
        }

        public string MensagemSucesso => driver.FindElement(byMensagemSucesso).Text;

        public void Visitar(string url)
        {
            Thread.Sleep(2000);
            driver.Navigate().GoToUrl(url + "pages/clientes");
        }

        private WebDriverWait Esperar()
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public void FiltrarRevendedora(string cpf)
        {
            driver.FindElement(byInputCpf).SendKeys(cpf);
            Thread.Sleep(5000);
            driver.FindElement(byBotaoBuscar).Click();
        }

        public void EditarRevendedora()
        {
            Thread.Sleep(2000);
            driver.FindElement(byEditarRevendedora).Click();
        }

        public void AdicionarCashBack(string valor, string data)
        {
            Thread.Sleep(2000);
            driver.FindElement(byTabCashBack).Click();
            Thread.Sleep(1000);
            driver.FindElement(byBotaoAdicionarCashback).Click();
            driver.FindElement(byInputValorCashback).SendKeys(valor);
            driver.FindElement(byInputDataCashback).SendKeys(data);
            driver.FindElement(byBotaoSalvar).Click();
        } 

        public void DeletarCashback()
        {
            driver.FindElement(byTabCashBack).Click();
            driver.FindElement(byBotaoDeletar).Click();
            driver.FindElement(byBotaoProssiga).Click();
        }
    }
}
