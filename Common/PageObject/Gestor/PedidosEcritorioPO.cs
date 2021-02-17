using Escritorio.PageObjects;
using OpenQA.Selenium;
using Escritorio.Helpers;
using Common;

namespace Common.PageObject.Gestor
{
    public class PedidosEcritorioPO
    {
        Utilitarios util;
        private IWebDriver driver;
        public PedidosPO pedidos { get; }
        private By byLinkPedidosEscritorio;

        public PedidosEcritorioPO(IWebDriver driver)
        {
            this.driver = driver;
            util = new Utilitarios(driver);
            pedidos = new PedidosPO(driver);
            byLinkPedidosEscritorio = By.XPath("/html/body/div/div/nav/div[2]/div[2]/a[3]/div[2]");
        }

        public void Visitar()
        {
            util.OnClick(byLinkPedidosEscritorio, 30);
        }

    }
}
