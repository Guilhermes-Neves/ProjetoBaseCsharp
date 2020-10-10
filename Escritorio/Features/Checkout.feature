#language:pt

@login
Funcionalidade: Checkout de pedidos
  Para que eu possa finalizar minha compra no portal
  Sendo uma revendedora previamente cadastrada
  Posso finalizar o meus pedidos

  Cenario: Finalizando pedido com pagamento no cartão
   Dado que estou na página de pedido rápido
   Quando eu adicionar todos os itens
      | nome                                 | referencia | tamanho | cor       | quantidade | desconto | preco    |
      | BR PEND CHAP QUADRA LISAS DET CRAQ   | PD3-0001   | unico   | sem pedra | 1          | 30%      | R$ 39,90 |
      | BR PEND CURV FIO VENEZ E PEROLA      | PD3-0002   | unico   | perola    | 1          | 30%      | R$ 39,90 | 
      | BR PEND RAB.RATO PEDRIN E CIRC VAZ   | PD3-0003   | unico   | crystal   | 1          | 30%      | R$ 24,90 |
      | BR PEND CHAPAZ OVAIS DET DIAMANTADO  | PD3-0004   | unico   | sem pedra | 1          | 30%      | R$ 19,90 |
   E acessar meu carrinho
   E seleciono a forma de pagamento "Cartão ou Boleto à vista"
   E seleciono o tipo de frete como "Entrega Normal"
   E finalizo o checkout pagando com cartão
   Então vejo a confirmação do checkout com a mensagem "Pedido realizado com sucesso."
   