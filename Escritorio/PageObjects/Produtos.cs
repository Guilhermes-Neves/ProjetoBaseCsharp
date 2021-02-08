using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Escritorio.Helpers;
using System.Threading;
using Common;

namespace Escritorio.PageObjects
{
    public class Produtos
    {
        Utilitarios util;
        private IWebDriver driver;
        private By byInputRef;
        private By byBotaoBuscar;
        private By byInputQuantidade;
        private By byBotaoAdicionar;
        private By bySelectTamanho;
        private By bySelectCor;

        public Produtos(IWebDriver driver)
        {
            this.driver = driver;
            byInputRef = By.Id("search_ref");
            byBotaoBuscar = By.ClassName("btn-buscar");
            byInputQuantidade = By.CssSelector("input[type='number']");
            byBotaoAdicionar = By.ClassName("btn-add");
            bySelectTamanho = By.XPath("/html/body/div[2]/div[2]/div/div/div/div[2]/div[1]/div/div[3]/div[1]/select");
            bySelectCor = By.XPath("/html/body/div[2]/div[2]/div/div/div/div[2]/div[1]/div/div[3]/div[2]/select");
            util = new Utilitarios(driver);
        }

        public void PesquisarPorRef(string referencia)
        {
            util.ClearInput(byInputRef, 10);
            util.SendKey(byInputRef, referencia, 10);
            util.OnClick(byBotaoBuscar, 5);
            util.ClearInput(byInputRef, 10);
        }

        public void SelecionarTamanho(string tamanho)
        {
            util.SelectText(bySelectTamanho, tamanho, 10);
        }

        public void SelecionarCor(string cor)
        {
            util.SelectText(bySelectCor, cor, 10);
        }

        public void AdicionarProdutos(string quantidade)
        {
            util.ClearInput(byInputQuantidade, 10);
            util.SendKey(byInputQuantidade, quantidade, 10);
            util.OnClick(byBotaoAdicionar, 10);

        }

    }
}
