using OpenQA.Selenium;
using System.Threading;

namespace Escritorio.PageObjects
{
    public class Produtos
    {
        private IWebDriver driver;
        private By byInputRef;
        private By byBotaoBuscar;
        private By byInputQuantidade;
        private By byBotaoAdicionar;

        public Produtos(IWebDriver driver)
        {
            this.driver = driver;
            byInputRef = By.Id("search_ref");
            byBotaoBuscar = By.ClassName("btn-buscar");
            byInputQuantidade = By.CssSelector("input[type='number']");
            byBotaoAdicionar = By.ClassName("btn-add");
        }

        public void PesquisarPorRef(string referencia)
        {
            driver.FindElement(byInputRef).Clear();
            driver.FindElement(byInputRef).SendKeys(referencia);
            Thread.Sleep(1000);
            driver.FindElement(byBotaoBuscar).Click();
            driver.FindElement(byInputRef).Clear();
        }

        public void AdicionarProdutos(string quantidade)
        {
            driver.FindElement(byInputQuantidade).Clear();
            driver.FindElement(byInputQuantidade).SendKeys(quantidade);
            driver.FindElement(byBotaoAdicionar).Click();

        }

    }
}
