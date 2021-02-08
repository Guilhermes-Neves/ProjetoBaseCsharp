#language: pt

Funcionalidade: Adicionar produtos no carrinho
  Para que eu possa realizar vendas no portal da Styllus
  Sendo uma revendedora previamente cadastrada
  Posso adicionar produtos no carrinho

    Cenário: Adicionar varios itens
        Dado estou na página de pedido rápido
        Quando eu adiciono todos os itens
         | nome                                 | referencia      | tamanho | cor        | quantidade | desconto |
         | CONJ SINGAPURA FE                    | CJ3-0001/45-000 | unico   | sem cor    | 1          | 30%      |
         | CONJ SINGAPURA CORACAO PEDRINHAS ZIR | CJ3-0002/45-001 | unico   | sem cor    | 1          | 30%      | 
         | CONJ SING PEROLA E PEDRA ZIR         | CJ3-0003/45-001 | unico   | sem cor    | 1          | 30%      |
        E acesso meu carrinho
        Então vejo todos os itens

    Cenario: Total do pedido menor que R$ 80,00
       Dado estou na página de pedido rápido
       Quando eu adiciono todos os itens
        | nome                                 | referencia      | tamanho | cor     | quantidade | desconto | alerta |
        | CONJ SINGAPURA FE                    | CJ3-0001/45-000 | unico   | sem cor | 1          | 0%       | 1      |
        | CONJ SINGAPURA CORACAO PEDRINHAS ZIR | CJ3-0002/45-001 | unico   | sem cor | 1          | 0%       | 1      |
       E acesso meu carrinho
       Então não consigo finalizar o pedido
       E vejo a alerta numero 3 com a mensagem "Atenção Para efetuar um pedido, selecione pelo menos R$ 80,00 em produtos"
       E vejo todos os itens

    Cenario: Ultrapassando o limite de crédito
      Dado estou na página de produtos com fotos
      Quando eu adiciono todos os itens
        | nome                      | referencia | tamanho | cor       | quantidade | desconto |
        | ARG DE PRATA ENC FIO LISO | AG3-0015   | unico   | sem pedra | 500        | 50%      |
      E acesso meu carrinho
      Então a forma de pagamento a prazo não deverá está presente
      E vejo a alerta numero 1 com a mensagem "Limite de crédito excedido. Você pode efetuar o pagamento à vista ou então remover alguns produtos do seu carrinho."
      E vejo todos os itens

    Cenario: Pedido até R$ 149,99 com desconto de 30%
      Dado estou na página de produtos com fotos
      Quando eu adiciono todos os itens
        | nome                   | referencia      | tamanho | cor       | quantidade | desconto |     
        | CONJ VENEZ X PEDRINHAS | CJ3-0006/45-007 | 45      | preto     | 3          | 30%      |
      E acesso meu carrinho
      Então vejo os descontos corretos

    Cenario: Pedido até R$ 299,99 com desconto de 35%
      Dado estou na página de produtos com fotos
      Quando eu adiciono todos os itens
        | nome                   | referencia      | tamanho | cor       | quantidade | desconto |     
        | CONJ VENEZ X PEDRINHAS | CJ3-0006/45-007 | 45      | preto     | 6          | 35%      |
      E acesso meu carrinho
      Então vejo os descontos corretos
    
    Cenario: Pedido até R$ 599,99 com desconto de 40%
      Dado estou na página de produtos com fotos
      Quando eu adiciono todos os itens
        | nome                   | referencia      | tamanho | cor       | quantidade | desconto |     
        | CONJ VENEZ X PEDRINHAS | CJ3-0006/45-007 | 45      | preto     | 12         | 40%      |
      E acesso meu carrinho
      Então vejo os descontos corretos

    Cenario: Pedido acima de R$ 600,00 com desconto de 50%
      Dado estou na página de produtos com fotos
      Quando eu adiciono todos os itens
        | nome                   | referencia      | tamanho | cor       | quantidade | desconto |     
        | CONJ VENEZ X PEDRINHAS | CJ3-0006/45-007 | 45      | preto     | 17         | 50%      |
      E acesso meu carrinho
      Então vejo os descontos corretos

    Cenario: Adicionando somente produtos da linha lingerie desconto adicional fixo em 30%
      Dado estou na página de produtos com fotos
      Quando eu adiciono todos os itens com cor e tamanho
        | nome            | referencia | tamanho | cor                   | quantidade | desconto | preco    |
        | TANGA SU        | LI3-0011   | P       | PRETO - Disponível    | 10         | 30%      | R$ 14,90 |   
      E acesso meu carrinho
      Então vejo os descontos corretos

    Cenario: Adicionando somente produtos com estoque zerado
      Dado estou na página de produtos com fotos
      Quando eu adiciono todos os itens com cor e tamanho
        | nome                | referencia | tamanho | cor      | quantidade | desconto | preco    |  
        | TANGA FIO RENDA     | LI3-0004   | p       | preto    | 1          | 30%      | R$ 9,90  |   
      E acesso meu carrinho
      Então vejo a alerta numero 2 com a mensagem "Alguns dos itens selecionados não possuem estoque disponível. Por favor, verifique antes de continuar:"
      E vejo todos os itens

    Cenario: Adicionando produtos com estoque e produtos com estoque zerado
      Dado estou na página de produtos com fotos
      Quando eu adiciono todos os itens com cor e tamanho
        | nome                | referencia | tamanho | cor      | quantidade | desconto | preco    |
        | CAMISOLA JAMILY     | LI3-0007   | m       | vermelho | 1          | 30%      | R$ 69,90 |   
        | TANGA FIO RENDA     | LI3-0004   | p       | preto    | 1          | 30%      | R$ 9,90  |   
      E acesso meu carrinho
      Então vejo a alerta numero 2 com a mensagem "Alguns dos itens selecionados não possuem estoque disponível. Por favor, verifique antes de continuar:"
      E vejo todos os itens

    Cenario: Ultrapassando o limite de crédito e utilizando cashback
      Dado estou na página de pedido rápido
      Quando eu adiciono todos os itens
        | nome                      | referencia | tamanho | cor       | quantidade | desconto | preco    |
        | ARG DE PRATA ENC FIO LISO | AG3-0015   | unico   | sem pedra | 35         | 50%      | R$ 99,90 |  
      E que edito uma revendedora
	  E adiciono cashback para a mesma
      E acesso meu carrinho
      E utilizo "500" reais de cashback
      Então a mensagem "Limite de crédito excedido. Você pode efetuar o pagamento à vista ou então remover alguns produtos do seu carrinho." não é exibida
      E vejo todos os itens