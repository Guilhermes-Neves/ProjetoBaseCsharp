#language:pt

@login
Funcionalidade: Checkout de pedidos
  Para que eu possa finalizar minha compra no portal
  Sendo uma revendedora previamente cadastrada
  Posso finalizar o meus pedidos

  Cenario: Finalizando pedido com pagamento no cartão
   Dado que estou na página de pedido rápido
   Quando eu adicionar todos os itens
      | nome                     | referencia | tamanho | cor       | quantidade | desconto | preco    |
      | CONJ SING FLOR PEDRA ZIR | CJ3-0004   | 45      | crystal   | 4          | 35%      | R$ 39,90 |
   E acessar meu carrinho
   E seleciono a forma de pagamento "Cartão ou Boleto à vista"
   E seleciono o tipo de frete como "Entrega Normal"
   E finalizo o checkout pagando com cartão
   Então vejo a confirmação do checkout com a mensagem "Pedido realizado com sucesso."
   