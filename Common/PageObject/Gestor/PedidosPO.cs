using OpenQA.Selenium;
using Common;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.UI;

namespace Common.PageObject
{
    public class PedidosPO
    {
        Utilitarios util;
        private IWebDriver driver;
        private By byBotaoFiltro;
        private By byInputNome;
        private By byInputCodStyllus;
        private By bySelectStatus;
        private By byInputValorMin;
        private By byInputValorMax;
        private By bySelectFormaPagamento;
        private By byInputDataInicio;
        private By byInputDataFim;
        private By bySelectStatusPagamento;
        private By byBotaoBuscar;
        private By byTdNome;
        private By byTdCod;
        private By byOptionNovo;
        private By byOptionNaoEntregue;
        private By byOptionCancelado;
        private By byTdStatus;
        private By byTdValor;
        private By byOptionPrazo;
        private By byOptionAvista;
        private By byOptionAmbos;
        private By byTdFormPag;
        private By byDiaSeisInicio;
        private By byDiaSeisFim;
        private By byDiaOnzeInicio;
        private By byDiaOnzeFim;
        private By byTdData;
        private By byOptionEstornado;
        private By byOptionRecusado;
        private By byTdStatusPgto;
        private By byBotaoAlterarEstado;
        private By bySelectEstado;
        private By byOptionEstadoCancelado;
        private By byBotaoSalvar;
        private By byBotaoAlterarDesabilitado;

        public PedidosPO(IWebDriver driver)
        {
            this.driver = driver;
            util = new Utilitarios(driver);
            byBotaoFiltro = By.XPath("/html/body/div[1]/div/main/div/div[2]/div[1]/div/div[1]/div/div[2]/button");
            byInputNome = By.XPath("/html/body/div[1]/div/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[1]/div/div/div[1]/div/input");
            byInputCodStyllus = By.XPath("/html/body/div[1]/div/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[2]/div/div/div[1]/div/input");
            bySelectStatus = By.XPath("/html/body/div/div[1]/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[3]/div/div/div[1]/div[1]/div[1]");
            byInputValorMin = By.XPath("/html/body/div[1]/div[1]/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[4]/div/div/div[1]/div/input");
            byInputValorMax = By.XPath("/html/body/div[1]/div[1]/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[5]/div/div/div[1]/div/input");
            bySelectFormaPagamento = By.XPath("/html/body/div/div/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[6]/div/div/div[1]/div[1]/div[1]");
            byInputDataInicio = By.XPath("/html/body/div[1]/div[1]/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[7]/div[1]/div[2]/div[1]/div/input");
            byInputDataFim = By.XPath("/html/body/div[1]/div[1]/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[8]/div[1]/div[2]/div[1]/div/input");
            bySelectStatusPagamento = By.XPath("/html/body/div[1]/div[1]/main/div/div[2]/div[1]/div/div[1]/div/div[2]/div/div/div/form/div/div[9]/div/div/div[1]/div[1]/div[1]");
            byBotaoBuscar = By.CssSelector("button.primary");
            byTdNome = By.XPath("/html/body/div/div/main/div/div[2]/div[1]/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]");
            byTdCod = By.XPath("/html/body/div/div/main/div/div[2]/div[1]/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]");
            byOptionNovo = By.XPath("/html/body/div/div[2]/div/div[2]/div/div");
            byOptionNaoEntregue = By.XPath("/html/body/div/div[2]/div/div[6]/div/div");
            byTdStatus = By.XPath("/html/body/div/div[1]/main/div/div[2]/div[1]/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[7]");
            byTdValor = By.XPath("/html/body/div/div[1]/main/div/div[2]/div[1]/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[5]");
            byOptionPrazo = By.XPath("/html/body/div/div[2]/div/div[1]/div/div");
            byTdFormPag = By.XPath("/html/body/div/div[1]/main/div/div[2]/div[1]/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]");
            byDiaSeisInicio = By.XPath("/html/body/div/div[2]/div/div/div/div[2]/table/tbody/tr[1]/td[7]/button/div");
            byDiaOnzeInicio = By.XPath("/html/body/div[1]/div[2]/div/div/div/div[2]/table/tbody/tr[2]/td[5]/button/div");
            byDiaSeisFim = By.XPath("/html/body/div[1]/div[3]/div/div/div/div[2]/table/tbody/tr[1]/td[7]/button/div");
            byDiaOnzeFim = By.XPath("/html/body/div[1]/div[3]/div/div/div/div[2]/table/tbody/tr[2]/td[5]/button/div");
            byTdData = By.XPath("/html/body/div/div[1]/main/div/div[2]/div[1]/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[6]");
            byOptionEstornado = By.XPath("/html/body/div[1]/div[2]/div/div[2]/div/div");
            byOptionRecusado = By.XPath("/html/body/div/div[2]/div/div[3]/div/div");
            byTdStatusPgto = By.XPath("/html/body/div[1]/div[1]/main/div/div[2]/div[1]/div/div[2]/div[1]/div[1]/table/tbody/tr/td[9]");
            byBotaoAlterarEstado = By.XPath("/html/body/div[1]/div[1]/main/div/div[2]/div[1]/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[10]/button/span");
            bySelectEstado = By.XPath("/html/body/div[1]/div[4]/div/div/div[2]/div[1]/div/div[1]/div[1]");
            byOptionEstadoCancelado = By.XPath("/html/body/div/div[5]/div/div[1]/div/div");
            byBotaoSalvar = By.CssSelector("button.blue--text");
            byBotaoAlterarDesabilitado = By.CssSelector("button[disabled='disabled']");
            byOptionCancelado = By.XPath("/html/body/div[1]/div[2]/div/div[1]/div/div");
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
            return byBotaoAlterarDesabilitado;
        }

        public void AplicarFiltro(string value1, string value2, string field)
        {
            switch (field)
            {
                case "nome":
                    util.OnClick(byBotaoFiltro, 30);
                    util.SendKey(byInputNome, value1, 30);
                    util.OnClick(byBotaoBuscar, 30);
                    break;

                case "codStyllus":
                    util.OnClick(byBotaoFiltro, 30);
                    util.SendKey(byInputCodStyllus, value1, 30);
                    util.OnClick(byBotaoBuscar, 30);
                    break;

                case "status":
                    switch (value1)
                    {
                        case "NOVO":
                            util.OnClick(byBotaoFiltro, 30);
                            util.OnClick(bySelectStatus, 30);
                            util.OnClick(byOptionNovo, 30);
                            util.OnClick(byBotaoBuscar, 30);
                            break;

                        case "NÃO ENTREGUE":
                            util.OnClick(byBotaoFiltro, 30);
                            util.OnClick(bySelectStatus, 30);
                            util.OnClick(byOptionNaoEntregue, 30);
                            util.OnClick(byBotaoBuscar, 30);
                            break;

                        case "CANCELADO":
                            util.OnClick(byBotaoFiltro, 30);
                            util.OnClick(bySelectStatus, 30);
                            util.OnClick(byOptionCancelado, 30);
                            util.OnClick(byBotaoBuscar, 30);
                            break;

                        default:
                            break;
                    }
                    
                    break;

                case "valorMin":
                    util.OnClick(byBotaoFiltro, 30);
                    util.SendKey(byInputValorMin, value2, 30);
                    util.SendKey(byInputValorMax, value1, 30);
                    util.OnClick(byBotaoBuscar, 30);
                    break;

                case "formaPag":
                    util.OnClick(byBotaoFiltro, 30);
                    util.OnClick(bySelectFormaPagamento, 30);
                    util.OnClick(byOptionPrazo, 30);
                    util.OnClick(byBotaoBuscar, 30);
                    break;

                case "data":
                    util.OnClick(byBotaoFiltro, 30);
                    util.OnClick(byInputDataInicio, 30);
                    util.OnClick(byDiaOnzeInicio, 30);
                    util.OnClick(byInputDataFim, 30);
                    util.OnClick(byDiaOnzeFim, 30);
                    util.OnClick(byBotaoBuscar, 30);
                    break;

                case "statusPag":
                    switch (value1)
                    {
                        case "Estornado":
                            util.OnClick(byBotaoFiltro, 30);
                            util.OnClick(bySelectStatusPagamento, 30);
                            util.OnClick(byOptionEstornado, 30);
                            util.OnClick(byBotaoBuscar, 30);
                            break;

                        case "Recusado":
                            util.OnClick(byBotaoFiltro, 30);
                            util.OnClick(bySelectStatusPagamento, 30);
                            util.OnClick(byOptionRecusado, 30);
                            util.OnClick(byBotaoBuscar, 30);
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
                    string nome = util.GetText(byTdNome, 30); 
                    return nome;

                case "codStyllus":
                    string cod = util.GetText(byTdCod, 30);
                    return cod;

                case "status":
                    string status = util.GetText(byTdStatus, 30);
                    return status;

                case "valorMin":
                    string valor = util.GetText(byTdValor, 30);
                    return valor;

                case "formaPag":
                    string formaPag = util.GetText(byTdFormPag, 30);
                    return formaPag;

                case "data":
                    string data = util.GetText(byTdData, 30);
                    return data;

                case "statusPag":
                    string statusPag = util.GetText(byTdStatusPgto, 30);
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
                    util.OnClick(byBotaoAlterarEstado, 30);
                    util.OnClick(bySelectEstado, 30);
                    util.OnClick(byOptionEstadoCancelado, 30);
                    util.OnClick(byBotaoSalvar, 30);
                    break;

                default:
                    break;
            }

        }
    }
}
