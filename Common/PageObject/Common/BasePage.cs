using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.PageObject.Common
{
    public class BasePage : Dictionary
    {
        public IWebDriver driver;

        public Utilitarios util;

        public BasePage()
        {
            util = new Utilitarios(driver);
        }

        public bool EncontrarBotao()
        {
            return Esperar().Until(ExpectedConditions.ElementExists(BotaoDesabilitado())).Displayed;
        }

        private WebDriverWait Esperar()
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        private By BotaoDesabilitado()
        {
            return BASE_PAGE.byBotaoAlterarDesabilitado;
        }

        public void AplicarFiltro(string value1, string value2, string field)
        {
            switch (field)
            {
                case "nome":
                    util.OnClick(BASE_PAGE.byBotaoFiltro, 30);
                    util.SendKey(BASE_PAGE.byInputNome, value1, 30);
                    //util.OnClick(BASE_PAGE.byBotaoBuscar, 30);
                    break;

                case "codStyllus":
                    util.OnClick(BASE_PAGE.byBotaoFiltro, 30);
                    util.SendKey(BASE_PAGE.byInputCodStyllus, value1, 30);
                    //util.OnClick(BASE_PAGE.byBotaoBuscar, 30);
                    break;

                case "status":
                    switch (value1)
                    {
                        case "NOVO":
                            util.OnClick(BASE_PAGE.byBotaoFiltro, 30);
                            util.OnClick(BASE_PAGE.bySelectStatus, 30);
                            util.OnClick(BASE_PAGE.byOptionNovo, 30);
                            //util.OnClick(BASE_PAGE.byBotaoBuscar, 30);
                            break;

                        case "NÃO ENTREGUE":
                            util.OnClick(BASE_PAGE.byBotaoFiltro, 30);
                            util.OnClick(BASE_PAGE.bySelectStatus, 30);
                            util.OnClick(BASE_PAGE.byOptionNaoEntregue, 30);
                            //util.OnClick(BASE_PAGE.byBotaoBuscar, 30);
                            break;

                        case "CANCELADO":
                            util.OnClick(BASE_PAGE.byBotaoFiltro, 30);
                            util.OnClick(BASE_PAGE.bySelectStatus, 30);
                            util.OnClick(BASE_PAGE.byOptionCancelado, 30);
                            //util.OnClick(BASE_PAGE.byBotaoBuscar, 30);
                            break;

                        default:
                            break;
                    }

                    break;

                case "valorMin":
                    util.OnClick(BASE_PAGE.byBotaoFiltro, 30);
                    util.SendKey(BASE_PAGE.byInputValorMin, value2, 30);
                    util.SendKey(BASE_PAGE.byInputValorMax, value1, 30);
                   // util.OnClick(BASE_PAGE.byBotaoBuscar, 30);
                    break;

                case "formaPag":
                    util.OnClick(BASE_PAGE.byBotaoFiltro, 30);
                    util.OnClick(BASE_PAGE.bySelectFormaPagamento, 30);
                    util.OnClick(BASE_PAGE.byOptionPrazo, 30);
                   // util.OnClick(BASE_PAGE.byBotaoBuscar, 30);
                    break;

                case "data":
                    util.OnClick(BASE_PAGE.byBotaoFiltro, 30);
                    util.OnClick(BASE_PAGE.byInputDataInicio, 30);
                    util.OnClick(BASE_PAGE.byDiaOnzeInicio, 30);
                    util.OnClick(BASE_PAGE.byInputDataFim, 30);
                    util.OnClick(BASE_PAGE.byDiaOnzeFim, 30);
                  //  util.OnClick(BASE_PAGE.byBotaoBuscar, 30);
                    break;

                case "statusPag":
                    switch (value1)
                    {
                        case "Estornado":
                            util.OnClick(BASE_PAGE.byBotaoFiltro, 30);
                            util.OnClick(BASE_PAGE.bySelectStatusPagamento, 30);
                            util.OnClick(BASE_PAGE.byOptionEstornado, 30);
                      //      util.OnClick(BASE_PAGE.byBotaoBuscar, 30);
                            break;

                        case "Recusado":
                            util.OnClick(BASE_PAGE.byBotaoFiltro, 30);
                            util.OnClick(BASE_PAGE.bySelectStatusPagamento, 30);
                            util.OnClick(BASE_PAGE.byOptionRecusado, 30);
                       //     util.OnClick(BASE_PAGE.byBotaoBuscar, 30);
                            break;

                        default:
                            break;
                    }

                    break;

                default:
                    break;
            }
        }

        public string EncontrarPedido(string field)
        {
            switch (field)
            {
                case "nome":
                    string nome = util.GetText(BASE_PAGE.byTdNome, 30);
                    return nome;

                case "codStyllus":
                    string cod = util.GetText(BASE_PAGE.byTdCod, 30);
                    return cod;

                case "status":
                    string status = util.GetText(BASE_PAGE.byTdStatus, 30);
                    return status;

                case "valorMin":
                    string valor = util.GetText(BASE_PAGE.byTdValor, 30);
                    return valor;

                case "formaPag":
                    string formaPag = util.GetText(BASE_PAGE.byTdFormPag, 30);
                    return formaPag;

                case "data":
                    string data = util.GetText(BASE_PAGE.byTdData, 30);
                    return data;

                case "statusPag":
                    string statusPag = util.GetText(BASE_PAGE.byTdStatusPgto, 30);
                    return statusPag;

                default:
                    return "não encontrou";
            }
        }

        public void AlterarEstadoPedido(string value)
        {
            switch (value)
            {
                case "CANCELADO":
                    util.OnClick(BASE_PAGE.byBotaoAlterarEstado, 30);
                    util.OnClick(BASE_PAGE.bySelectEstado, 30);
                    util.OnClick(BASE_PAGE.byOptionEstadoCancelado, 30);
                    util.OnClick(BASE_PAGE.byBotaoSalvar, 30);
                    break;

                default:
                    break;
            }

        }

        public void AguardarCarregamentoPagina()
        {

        }
    }
}
