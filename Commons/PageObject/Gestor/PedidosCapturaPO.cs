using OpenQA.Selenium;
using Commons.PageObject.Common;
using Commons.Core;

namespace Commons
{
    public class PedidosCapturaPO : BasePage
    {
        public PedidosCapturaPO(WebDriver driver)
        {
            this.driver = driver;
        }

        public void Visitar()
        {
            driver.OnClick(MANEGER_ORDER_CATCH_PAGE.byLinkPedidosCaptura, 30);
        }

    }
}
