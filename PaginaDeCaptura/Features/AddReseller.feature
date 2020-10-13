#language:pt

Funcionalidade: Cadastrar uma revendedora

@mytag
Cenário: Cadastrar uma nova Revendedora do Rio de Janeiro sem indicação
	Dado que acesso a página de captura
	Quando faço o cadastro da revendedora
	E seleciono o kit de entrada
	E seleciono para receber no primeiro pedido
	E efetuo pagamento com cartão
	Então vejo a mensagem <mensagem>
	| mensagem                                                                                                                             |
	| Recebemos o seu pedido                                                                                                               |
	| Após o pagamento, em até 72 horas ele será processado. Você receberá por e-mail um ID e senha para ter acesso ao escritório virtual. |
