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
        | nome                                    | referencia      | tamanho | cor        | quantidade | desconto |
        | CONJ SINGAPURA FE                       | CJ3-0001/45-000 | unico   | sem cor    | 1          | 0%       |
        | CONJ SINGAPURA CORACAO PEDRINHAS ZIR    | CJ3-0002/45-001 | unico   | sem cor    | 1          | 0%       |
       E acesso meu carrinho
       Então não consigo finalizar o pedido
       E vejo a mensagem "Atenção Para efetuar um pedido, selecione pelo menos R$ 80,00 em produtos"
       E vejo todos os itens

    Cenario: Ultrapassando o limite de crédito
      Dado estou na página de produtos com fotos
      Quando eu adiciono todos os itens
        | nome                      | referencia | tamanho | cor       | quantidade | desconto |
        | ARG DE PRATA ENC FIO LISO | AG3-0015   | unico   | sem pedra | 500        | 50%      |
      E acesso meu carrinho
      Então a forma de pagamento a prazo não deverá está presente
      E vejo o alerta "Limite de crédito excedido. Você pode efetuar o pagamento à vista ou então remover alguns produtos do seu carrinho."
      E vejo todos os itens

