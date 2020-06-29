#language:pt

@login
@productsPage
Funcionalidade: Adicionar produtos no carrinho
  Para que eu possa realizar vendas no portal da Styllus
  Sendo uma revendedora previamente cadastrada
  Posso adicionar produtos no carrinho

  
  Cenario: Adicionar varios itens
    Dado que os produtos desejados são:
        | nome                                 | referencia      | preco    |
        | CONJ SINGAPURA FE                    | CJ3-0001/45-000 | R$ 19,90 |
        | CONJ SINGAPURA CORACAO PEDRINHAS ZIR | CJ3-0002/45-001 | R$ 49,90 |
        | CONJ SING PEROLA E PEDRA ZIR         | CJ3-0003/45-001 | R$ 39,90 |
    Quando eu adiciono todos os itens
    E acesso meu carrinho
    Então vejo todos os itens no carrinho     
    E o valor do subtotal deve ser de "R$ 109,70"
    E o valor de desconto deve ser de "R$ 32,91"
    E o valor total deve ser de "R$ 76,79"
  
  @addToCart  
  Cenario: Total do pedido menor que R$ 80,00
      Dado que os produtos desejados são:
        | nome                                 | referencia      | preco    |
        | CONJ SINGAPURA FE                    | CJ3-0001/45-000 | R$ 19,90 |
        | CONJ SINGAPURA CORACAO PEDRINHAS ZIR | CJ3-0002/45-001 | R$ 49,90 | 
      Quando eu adiciono todos os itens
      E acesso meu carrinho
      Então vejo todos os itens no carrinho
      E não consigo finalizar o pedido
      E vejo a mensagem "Para efetuar um pedido, selecione pelo menos R$ 80,00 em produtos"
      E o valor do subtotal deve ser de "R$ 69,80"
      E o valor de desconto deve ser de "R$ 0,00"
      E o valor total deve ser de "R$ 69,80"