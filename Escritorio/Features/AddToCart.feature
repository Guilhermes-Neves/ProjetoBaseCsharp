#language: pt


Funcionalidade: Adicionar produtos no carrinho
  Para que eu possa realizar vendas no portal da Styllus
  Sendo uma revendedora previamente cadastrada
  Posso adicionar produtos no carrinho

  @login
    Cenário: Adicionar varios itens
        Dado estou na página de pedido rápido
        Quando eu adiciono todos os itens
            | nome                                 | referencia      | tamanho | cor        | quantidade | desconto | preco    |
            | CONJ SINGAPURA FE                    | CJ3-0001/45-000 | unico   | sem cor    | 1          | 30%      | R$ 19,90 |
            | CONJ SINGAPURA CORACAO PEDRINHAS ZIR | CJ3-0002/45-001 | unico   | sem cor    | 1          | 30%      | R$ 49,90 | 
            | CONJ SING PEROLA E PEDRA ZIR         | CJ3-0003/45-001 | unico   | sem cor    | 1          | 30%      | R$ 39,90 |
        E acesso meu carrinho
        Então vejo todos os itens
            | nome                                 | referencia      | tamanho | cor        | quantidade | desconto | preco    |
            | CONJ SINGAPURA FE                    | CJ3-0001/45-000 | unico   | sem cor    | 1          | 30%      | R$ 19,90 |
            | CONJ SINGAPURA CORACAO PEDRINHAS ZIR | CJ3-0002/45-001 | unico   | sem cor    | 1          | 30%      | R$ 49,90 | 
            | CONJ SING PEROLA E PEDRA ZIR         | CJ3-0003/45-001 | unico   | sem cor    | 1          | 30%      | R$ 39,90 |
        E os valores totais são:
            | chave    | valor     |
            | subTotal | R$ 109,70 |  
            | desconto | R$ 32,91  |
            | total    | R$ 76,79  | 

