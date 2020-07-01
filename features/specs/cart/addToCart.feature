#language:pt

@login
@productsPage
Funcionalidade: Adicionar produtos no carrinho
  Para que eu possa realizar vendas no portal da Styllus
  Sendo uma revendedora previamente cadastrada
  Posso adicionar produtos no carrinho

  
  Cenario: Adicionar varios itens
    Dado que os produtos desejados são:
        | nome                                 | referencia      | quantidade | preco    |
        | CONJ SINGAPURA FE                    | CJ3-0001/45-000 | 1          | R$ 19,90 |
        | CONJ SINGAPURA CORACAO PEDRINHAS ZIR | CJ3-0002/45-001 | 1          | R$ 49,90 | 
        | CONJ SING PEROLA E PEDRA ZIR         | CJ3-0003/45-001 | 1          | R$ 39,90 |
    Quando eu adiciono todos os itens
    E acesso meu carrinho
    E seleciono o tipo de frete como " Entrega Normal - R$ 0,00 "
    Então vejo todos os itens no carrinho     
    E o valor do subtotal deve ser de "R$ 109,70"
    E o valor de desconto deve ser de "R$ 32,91"
    E o valor total deve ser de "R$ 76,79" 
  
  @temp
  Cenario: Total do pedido menor que R$ 80,00
      Dado que os produtos desejados são:
        | nome                                    | referencia      | quantidade | preco    |
        | CONJ SINGAPURA FE                       | CJ3-0001/45-000 | 1          | R$ 19,90 |
        | CONJ SINGAPURA CORACAO PEDRINHAS ZIR    | CJ3-0002/45-001 | 1          | R$ 49,90 | 
      Quando eu adiciono todos os itens
      E acesso meu carrinho
      E seleciono o tipo de frete como " Entrega Normal - R$ 0,00 "
      Então vejo todos os itens no carrinho
      E não consigo finalizar o pedido
      E vejo a mensagem de alerta "Para efetuar um pedido, selecione pelo menos R$ 80,00 em produtos"
      E o valor do subtotal deve ser de "R$ 69,80"
      E o valor de desconto deve ser de "R$ 0,00"
      E o valor total deve ser de "R$ 69,80"

  
  Cenario: Ultrapassando o limite de crédito
      Dado que os produtos desejados são:
        | nome                                    | referencia      | quantidade | preco     |
        | CONJ SINGAPURA CORACAO PEDRINHAS ZIR    | CJ3-0002/45-001 | 8          | R$ 399,20 | 
        | CONJ SING PEROLA E PEDRA ZIR            | CJ3-0003/45-001 | 8          | R$ 319,20 |
        | CONJ FLOR PEDRINHAS E PEDRA REDONDA ZIR | CJ3-0005/45-001 | 8          | R$ 399,20 |
        | CONJ VENEZ X PEDRINHAS                  | CJ3-0006/45-007 | 8          | R$ 399,20 |
      Quando eu adiciono todos os itens
      E acesso meu carrinho
      Então vejo todos os itens no carrinho
      E a forma de pagamento "À Prazo - Até 30 dias no boleto" não deverá está presente
      E vejo a mensagem informativa "Limite de crédito excedido. Você pode efetuar o pagamento à vista ou então remover alguns produtos do seu carrinho."
      E o valor do subtotal deve ser de "R$ 1.516,80"
      E o valor de desconto deve ser de "R$ 758,40"
      E o valor total deve ser de "R$ 758,40"
      