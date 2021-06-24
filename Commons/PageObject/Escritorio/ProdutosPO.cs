using OpenQA.Selenium;
using Common;
using Commons.PageObject.Common;
using System;
using Commons.Core;

namespace Commons
{
    public class ProdutosPO : BasePage
    {
        public ProdutosPO(WebDriver driver)
        {
            this.driver = driver;
        }

        public void Visitar()
        {
            driver.NavigateTo(URL_BASE_ESCRITORIO + "produtos");
        }

        public void PesquisarPorRef(string referencia, int timeOut)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(timeOut);

            while (DateTime.Now <= timeoutLimit) 
            {
                if (driver.IsElementEnabled(OFFICE_PRODUCT_PAGE.byBotaoBuscar))
                {
                    driver.SendKey(OFFICE_PRODUCT_PAGE.byInputRef, referencia, 20);
                    driver.WaitUntilElementDesappear(BASE_PAGE.byLoadProducts, 20);
                    driver.OnClick(OFFICE_PRODUCT_PAGE.byBotaoBuscar, 20);

                    return;
                }
            }
            
        }

        public void SelecionarTamanho(string tamanho)
        {
            driver.SelectText(OFFICE_PRODUCT_PAGE.bySelectTamanho, tamanho, 10);
        }

        public void SelecionarCor(string indexCor)
        {
            driver.SelectValue(OFFICE_PRODUCT_PAGE.bySelectCor, indexCor, 10);
        }

        public void AdicionarProdutos(string quantidade, int timeOut)
        {
            DateTime timeoutLimit = DateTime.Now.AddSeconds(timeOut);

            while (DateTime.Now <= timeoutLimit)
            {
                driver.WaitUntilElementAppear(OFFICE_PRODUCT_PAGE.byQuantidadePaginas, 30);
                string mensagemQtdPaginas = driver.GetText(OFFICE_PRODUCT_PAGE.byQuantidadePaginas, 30);
                if (mensagemQtdPaginas == "Você está na página 1 de 1")
                {
                    driver.OnClick(OFFICE_PRODUCT_PAGE.byBotaoAdicionar, 10);
                    driver.ClearInput(OFFICE_PRODUCT_PAGE.byInputQuantidade, 10);
                    driver.SendKey(OFFICE_PRODUCT_PAGE.byInputQuantidade, quantidade, 10);
                    driver.OnClick(OFFICE_PRODUCT_PAGE.byBotaoAdicionarModal, 10);
                    driver.ClearInput(OFFICE_PRODUCT_PAGE.byInputRef, 30);
                    return;
                }
            }
        }

        public void AcionarProdutoDesejadoModal()
        {
            driver.OnClick(OFFICE_PRODUCT_PAGE.byBotaoAdicionar, 10);
        }

        public void LimparFiltro()
        {
            if (driver.IsElementEnabled(OFFICE_PRODUCT_PAGE.byBotaoLimpar))
            {
                driver.OnClick(OFFICE_PRODUCT_PAGE.byBotaoLimpar, 30);
            }
        }
    }
}
