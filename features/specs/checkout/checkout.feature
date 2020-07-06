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
@temp
  Cenario: Finalizando pedido com pagamento a prazo
    Quando acesso meu carrinho
    E seleciono a forma de pagamento "À Prazo - Até 30 dias no boleto"
    E seleciono o tipo de frete como " Entrega Rápida - R$ 21,20 "
    E finalizo o pedido
    Então vejo todos os itens no pedido
    E visito a página inicial
    E vejo o limite de crédito "R$ 491,58"
    E libero o limite de crédito
