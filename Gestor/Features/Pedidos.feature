﻿#language: pt

Funcionalidade: Pedidos 
	Para que eu possa localizar e realizar ações em um pedido
	Sendo um gestor previamente cadastrado
	Posso localizar e editar informações de um pedido

Cenario: Aplicar filtro Pedidos Escritorio
	Dado que eu estou na página de pedidos do escritório
	Quando eu aplico o filtro "<valor>" e "<valor2>" no "<campo>"
	Então eu visualizo pedidos com o "<valor>" no "<campo>"

	Exemplos:         
		| valor                       | valor2 | campo      |
		| VITOR GIOVANNI DA CONCEIÇÃO |        | nome       |
		| 1396039                     |        | codStyllus |
		| NOVO                        |        | status     |
		| 502.60                      | 500    | valorMin   |
		| À Prazo                     |        | formaPag   |
		| 11/02/2021                  |        | data       |
		| Estornado                   |        | statusPag  |

Cenario: Aplicar filtro Pedidos Captura
	Dado que estou na página de pedidos da página de captura
	Quando eu aplico o filtro "<valor>" e "<valor2>" no "<campo>"
	Então eu visualizo pedidos com o "<valor>" no "<campo>"

	Exemplos:         
		| valor                       | valor2 | campo      |
		| VITOR GIOVANNI DA CONCEIÇÃO |        | nome       |
		| 1396039                     |        | codStyllus |
		| NÃO ENTREGUE                |        | status     |
		| 139.02                      | 139.01 | valorMin   |
		| À Prazo                     |        | formaPag   |
		| 11/02/2021                  |        | data       |
		| Recusado                    |        | statusPag  |

Cenario: Alterar estado de um pedido do escritorio
	Dado que eu estou na página de pedidos do escritório
	Quando encontro um pedido e altero o status dele para "CANCELADO"
	Então eu vejo a mensage de sucesso "Estado do pedido alterado com sucesso :D"

Cenario: Pedidos cancelados com botão Alterar estado desabilitado
	Dado que eu estou na página de pedidos do escritório
	Quando eu aplico o filtro "<valor>" e "<valor2>" no "<campo>"
	Então eu visualizo o botão de alterar estado desabilitado

	Exemplos:         
		| valor     | valor2 | campo      |
		| NOVO |        | status     |
		