using Escritorio.PageObjects;
using OpenQA.Selenium;



namespace escritorio.PageObjects
{
    public class PedidoRapidoPO
    {
        private const int V = 10;
        private IWebDriver driver;
        private By byInputReferencia;
        private By byInputQuantidade;
        private By byBotaoBuscar;
        private By byBotaoAdicionar;

        public Produtos Produtos { get; }

        public PedidoRapidoPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputReferencia = By.XPath("//*[@id='app']/div/div[2]/div/div/div[1]/div/form/div/div[1]/div/input");
            byInputQuantidade = By.CssSelector("input[type='number']");
            byBotaoBuscar = By.ClassName("btn-buscar");
            byBotaoAdicionar = By.ClassName("btn-add");
            Produtos = new Produtos(driver);

        }

        public void Visitar(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void FiltrarProduto(string referencia)
        {
            driver.FindElement(byInputReferencia).SendKeys(referencia);
            driver.FindElement(byBotaoBuscar).Click();
        }

        public void AdicionarProduto(string quantidade)
        {
            driver.FindElement(byInputQuantidade).SendKeys(quantidade);
            driver.FindElement(byBotaoAdicionar).Click();

        }
    }
}
