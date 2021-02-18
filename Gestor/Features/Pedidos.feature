#language: pt

Funcionalidade: Pedidos 
	Para que eu possa localizar e realizar ações em um pedido
	Sendo um gestor previamente cadastrado
	Posso localizar e editar informações de um pedido

Cenario: Aplicar filtro Pedidos Escritorio
	Dado que estou na página de pedidos do escritório
	Quando aplico o filtro "<valor>" no "<campo>"
	Então visualizo pedidos com o "<valor>" no "<campo>"

	Exemplos:         
		| valor                  | campo      |
		| DEBORA QUEIROZ MARTINS | nome       |
		| 97225                  | codStyllus |
		| NOVO                   | status     |
		| 502.60                 | valorMin   |
		| À Prazo                | formaPag   |
		| 06/02/2021             | data       |
		| Estornado              | statusPag  |