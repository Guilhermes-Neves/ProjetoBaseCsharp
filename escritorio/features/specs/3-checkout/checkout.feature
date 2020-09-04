#language:pt

@login
Funcionalidade: Checkout de pedidos
  Para que eu possa finalizar minha compra no portal
  Sendo uma revendedora previamente cadastrada
  Posso finalizar o meus pedidos

  Contexto: itens no carrinho
    Dado que os produtos desejados são:
      | nome                                 | referencia | tamanho | cor       | quantidade | desconto | preco    |
      | BR PEND CHAP QUADRA LISAS DET CRAQ   | PD3-0001   | unico   | sem pedra | 1          | 30%      | R$ 39,90 |
      | BR PEND CURV FIO VENEZ E PEROLA      | PD3-0002   | unico   | perola    | 1          | 30%      | R$ 39,90 | 
      | BR PEND RAB.RATO PEDRIN E CIRC VAZ   | PD3-0003   | unico   | crystal   | 1          | 30%      | R$ 24,90 |
      | BR PEND CHAPAZ OVAIS DET DIAMANTADO  | PD3-0004   | unico   | sem pedra | 1          | 30%      | R$ 19,90 |
    E estão no carrinho

  Cenario: Finalizando pedido com pagamento no cartão
   Quando gero um cartão para pagamento
   E acesso meu carrinho
   E seleciono a forma de pagamento "Cartão ou Boleto à vista"
   E seleciono o tipo de frete como " Entrega Normal - R$ 0,00 "
   E finalizo o pedido
   E clico na forma de pagamento "Cartão de Crédito"
   E finalizo o checkout
   Então vejo a confirmação do checkout com a mensagem "Pedido realizado com sucesso."
   E vejo todos os itens no pedido
   
  Cenario: Finalizando pedido com pagamento no boleto
   Quando acesso meu carrinho
   E seleciono a forma de pagamento "Cartão ou Boleto à vista"
   E seleciono o tipo de frete como " Entrega Normal - R$ 0,00 "
   E finalizo o pedido
   E clico na forma de pagamento "Boleto"
   E finalizo o checkout como boleto
   Então vejo a confirmação do checkout com a mensagem "Pedido realizado com sucesso."
   E vejo todos os itens no pedido
    @check
  Cenario: Finalizando pedido com pagamento a prazo
    Quando acesso meu carrinho
    E seleciono a forma de pagamento "À Prazo - Até 30 dias no boleto"
    E seleciono o tipo de frete como " Entrega Normal - R$ 0,00 "
    E finalizo o pedido
    E capturo o número do pedido
    Então vejo todos os itens no pedido
    E visito a página inicial
    E vejo o limite de crédito
    E libero o limite de crédito
    