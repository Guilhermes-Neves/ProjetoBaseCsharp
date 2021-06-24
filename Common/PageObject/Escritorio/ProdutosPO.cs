using OpenQA.Selenium;
using Common;
using Common.PageObject.Common;
using System;

namespace Common
{
    public class ProdutosPO : BasePage
    {
        public ProdutosPO(IWebDriver driver)
        {
            this.driver = driver;
            util = new Utilitarios(driver);
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl(URL_BASE_ESCRITORIO + "produtos");
        }

        public void PesquisarPorRef(string referencia)
        {
            util.SendKey(OFFICE_PRODUCT_PAGE.byInputRef, referencia, 10);
            util.OnClick(OFFICE_PRODUCT_PAGE.byBotaoBuscar, 10);
        }

        public void SelecionarTamanho(string tamanho)
        {
            util.SelectText(OFFICE_PRODUCT_PAGE.bySelectTamanho, tamanho, 10);
        }

        public void SelecionarCor(string cor)
        {
            util.SelectText(OFFICE_PRODUCT_PAGE.bySelectCor, cor, 10);
        }

        public void AdicionarProdutos(string quantidade, int timeOut)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(timeOut);

            while (DateTime.Now <= timeoutLimit)
            {
                string mensagemQtdPaginas = util.GetText(OFFICE_PRODUCT_PAGE.byQuantidadePaginas, 30);

                if (mensagemQtdPaginas == "Você está na página 1 de 1")
                {
                    util.OnClick(OFFICE_PRODUCT_PAGE.byBotaoAdicionar, 10);
                    util.ClearInput(OFFICE_PRODUCT_PAGE.byInputQuantidade, 10);
                    util.SendKey(OFFICE_PRODUCT_PAGE.byInputQuantidade, quantidade, 10);
                    util.OnClick(OFFICE_PRODUCT_PAGE.byBotaoAdicionarModal, 10);

                    return;
                }
            }
        }

        public void LimparFiltro()
        {
            util.OnClick(OFFICE_PRODUCT_PAGE.byBotaoLimpar, 10);
        }
    }
}
