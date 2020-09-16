using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace escritorio.PageObjects
{
    public class CarrinhoPO
    {
        private IWebDriver driver;
        private By byTable;
        private By byAlertaTotalPedido;

        public string AlertaTotalPedido => driver.FindElement(byAlertaTotalPedido).Text;

        public string TabelaDeProdutos => driver.FindElement(byTable).Text;

        public CarrinhoPO(IWebDriver driver)
        {
            this.driver = driver;
            byTable = By.CssSelector("table tbody tr");
            byAlertaTotalPedido = By.CssSelector(".alert-danger .alert-content");
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("https://hlg-escritorio.styllus.online/#/pedidos/carrinho");
            Console.WriteLine(AlertaTotalPedido);
        }

        public void EsvaziarCarrinho()
        {

        }

    }
}
