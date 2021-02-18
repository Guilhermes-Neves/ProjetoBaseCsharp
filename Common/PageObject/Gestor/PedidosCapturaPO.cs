using Escritorio.PageObjects;
using OpenQA.Selenium;
using Escritorio.Helpers;
using Common;

namespace Common.PageObject.Gestor
{
    public class PedidosCapturaPO
    {
        Utilitarios util;
        private IWebDriver driver;
        public PedidosPO pedidos { get; }
        private By byLinkPedidosCaptura;

        public PedidosCapturaPO(IWebDriver driver)
        {
            this.driver = driver;
            util = new Utilitarios(driver);
            pedidos = new PedidosPO(driver);
            byLinkPedidosCaptura = By.XPath("/html/body/div/div/nav/div[2]/div[2]/a[3]/div[2]");
        }

        public void Visitar()
        {
            util.OnClick(byLinkPedidosCaptura, 30);
        }

    }
}
