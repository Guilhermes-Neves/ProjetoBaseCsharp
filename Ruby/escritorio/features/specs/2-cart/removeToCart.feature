#language:pt

@login
Funcionalidade: Remover produtos do carrinho
  Para que eu possa manter meu carrinho apenas com itens desejados
  Sendo uma revendedora previamente cadastrada que desistiu de um ou mais itens
  Posso remover produtos do carrinho

  Contexto: itens no carrinho
      Dado que os produtos desejados são:
        | nome                                 | referencia      | tamanho | cor        | quantidade | desconto | preco    |
        | CONJ SINGAPURA FE                    | CJ3-0001/45-000 | 45      | sem pedra  | 1          | 30%      | R$ 19,90 |
        | CONJ SINGAPURA CORACAO PEDRINHAS ZIR | CJ3-0002/45-001 | 45      | crystal    | 1          | 30%      | R$ 49,90 | 
        | CONJ SING PEROLA E PEDRA ZIR         | CJ3-0003/45-001 | 45      | crystal    | 1          | 30%      | R$ 39,90 |
      E estão no carrinho

  Cenario: Esvaziar o carrinho    
      Quando eu esvazio o carrinho
      Então vejo a mensagem "Seu carrinho está vazio :("
    
  Esquema do Cenario: Remover 1 item do carrinho
     Quando acesso meu carrinho
     E removo o <item>
     Então o valor total deve ser de <subtotal>

     Exemplos:
      | item | subtotal   |
      | 0    | "R$ 89,80" |
      | 1    | "R$ 59,80" |
      | 2    | "R$ 69,80" |