#language:pt

@login
Funcionalidade: Adicionar produtos no carrinho
  Para que eu possa realizar vendas no portal da Styllus
  Sendo uma revendedora previamente cadastrada
  Posso adicionar produtos no carrinho
@smoke
  Cenario: Adicionar varios itens
    Dado que os produtos desejados são:
        | nome                                 | referencia      | tamanho | cor        | quantidade | desconto | preco    |
        | CONJ SINGAPURA FE                    | CJ3-0001/45-000 | unico   | sem cor    | 1          | 30%      | R$ 19,90 |
        | CONJ SINGAPURA CORACAO PEDRINHAS ZIR | CJ3-0002/45-001 | unico   | sem cor    | 1          | 30%      | R$ 49,90 | 
        | CONJ SING PEROLA E PEDRA ZIR         | CJ3-0003/45-001 | unico   | sem cor    | 1          | 30%      | R$ 39,90 |
    E estou na página de pedido rápido
    Quando eu adiciono todos os itens
    E acesso meu carrinho
    E seleciono o tipo de frete como " Entrega Rápida - R$ 21,20 "
    Então vejo todos os itens
    E os valores totais são:
        | subTotal | R$ 109,70 |  
        | desconto | R$ 32,91  |
        | frete    | R$ 21,20  |
        | total    | R$ 97,99  |  
  @smoke  
  Cenario: Total do pedido menor que R$ 80,00
      Dado que os produtos desejados são:
        | nome                                    | referencia      | tamanho | cor        | quantidade | desconto | preco    |
        | CONJ SINGAPURA FE                       | CJ3-0001/45-000 | unico   | sem cor    | 1          | 0%       | R$ 19,90 |
        | CONJ SINGAPURA CORACAO PEDRINHAS ZIR    | CJ3-0002/45-001 | unico   | sem cor    | 1          | 0%       | R$ 49,90 | 
      E estou na página de pedido rápido
      Quando eu adiciono todos os itens
      E acesso meu carrinho
      E seleciono o tipo de frete como " Entrega Normal - R$ 0,00 "
      Então vejo todos os itens
      E não consigo finalizar o pedido
      E vejo a mensagem "Para efetuar um pedido, selecione pelo menos R$ 80,00 em produtos"
      E os valores totais são:
        | subTotal | R$ 69,80 |  
        | desconto | R$ 0,00  |
        | total    | R$ 69,80 |  
  @tempo
  Cenario: Ultrapassando o limite de crédito
      Dado que os produtos desejados são:
        | nome                                    | referencia      | tamanho | cor        | quantidade | desconto | preco    |
        | CONJ SINGAPURA CORACAO PEDRINHAS ZIR    | CJ3-0002/45-001 | unico   | sem cor    | 1          | 50%      | R$ 49,90 |  
      E estou na página de pedido rápido
      Quando eu adiciono todos os itens
      E acesso meu carrinho
      E aumento a quantidade até ultrapassar o limite
      Então a forma de pagamento "À Prazo - Até 30 dias no boleto" não deverá está presente
      E vejo a mensagem "Limite de crédito excedido. Você pode efetuar o pagamento à vista ou então remover alguns produtos do seu carrinho."
  
@smoke
    Cenario: Pedido até R$ 149,99 com desconto de 30%
      Dado que os produtos desejados são:
        | nome                                | referencia      | tamanho | cor       | quantidade | desconto | preco    |      
        | BR PEND CHAP QUADRA LISAS DET CRAQ  | PD3-0001/UN-000 | unico   | sem pedra | 1          | 30%      | R$ 39,90 | 
        | BR PEND CURV FIO VENEZ E PEROLA     | PD3-0002/UN-093 | unico   | perola    | 1          | 30%      | R$ 39,90 |
        | BR PEND RAB.RATO PEDRIN E CIRC VAZ  | PD3-0003/UN-001 | unico   | crystal   | 1          | 30%      | R$ 24,90 |
        | BR PEND CHAPAZ OVAIS DET DIAMANTADO | PD3-0004/UN-000 | unico   | sem pedra | 1          | 30%      | R$ 19,90 |
        | BR PEQ PATINHA PET                  | PQ3-0027/UN-000 | unico   | sem pedra | 1          | 30%      | R$ 9,90  |
        | BR PEQ ANCORA LISA                  | PQ3-0028/UN-000 | unico   | sem pedra | 1          | 30%      | R$ 14,90 |
      E estou na página de produtos com foto
      Quando eu adiciono todos os itens com cor e tamanho
      E acesso meu carrinho
      Então vejo todos os itens
      E os valores totais são:
        | subTotal | R$ 149,40 |  
        | desconto | R$ 44,82  |
        | total    | R$ 104,58 |

    Cenario: Pedido a partir de R$ 150,00 com desconto de 35%
      Dado que os produtos desejados são:
        | nome                                | referencia      | tamanho | cor       | quantidade | desconto | preco    |
        | BR PEND CHAP QUADRA LISAS DET CRAQ  | PD3-0001/UN-000 | unico   | sem pedra | 1          | 35%      | R$ 39,90 | 
        | BR PEND CURV FIO VENEZ E PEROLA     | PD3-0002/UN-093 | unico   | perola    | 1          | 35%      | R$ 39,90 |
        | BR PEND RAB.RATO PEDRIN E CIRC VAZ  | PD3-0003/UN-001 | unico   | crystal   | 1          | 35%      | R$ 24,90 |
        | BR PEND CHAPAZ OVAIS DET DIAMANTADO | PD3-0004/UN-000 | unico   | sem pedra | 1          | 35%      | R$ 19,90 |
        | BR PEQ PATINHA PET                  | PQ3-0027/UN-000 | unico   | sem pedra | 1          | 35%      | R$ 9,90  |
        | BR PEQ ANCORA LISA                  | PQ3-0028/UN-000 | unico   | sem pedra | 1          | 35%      | R$ 14,90 |
        | BR PEND LOSANGOS VAZADOS DET DIAMNT | PD3-0005/UN-000 | unico   | sem pedra | 1          | 35%      | R$ 19,90 |
        | BR PEND CHAP QUADR DET DIAMANTADO   | PD3-0007/UN-000 | unico   | sem pedra | 1          | 35%      | R$ 29,90 |
        | BR PEND CHAP QUADR VAZ E PEROLA     | PD3-0008/UN-093 | unico   | perola    | 1          | 35%      | R$ 29,90 |
        | BR PEND HASTE CHAPINHA FOLHA CURV   | PD3-0009/UN-000 | unico   | sem pedra | 1          | 35%      | R$ 29,90 |
        | BR PEQ COROA PEDRAS ZIR             | PQ3-0003/UN-001 | unico   | crystal   | 1          | 35%      | R$ 39,90 |
      E estou na página de produtos com foto
      Quando eu adiciono todos os itens com cor e tamanho
      E acesso meu carrinho
      Então vejo todos os itens
      E os valores totais são:
        | subTotal | R$ 298,90 |  
        | desconto | R$ 104,62 |
        | total    | R$ 194,29 |

    Cenario: Pedido a partir de R$ 300,00 com desconto de 40%
      Dado que os produtos desejados são:
        | nome                      | referencia | tamanho | cor       | quantidade | desconto | preco     |
        | ARG DE PRATA ENC FIO LISO | AG3-0015   | unico   | sem pedra | 6          | 40%      | R$ 599,40 | 
      E estou na página de produtos com foto
      Quando eu adiciono todos os itens com cor e tamanho
      E acesso meu carrinho
      Então vejo todos os itens
      E os valores totais são:
        | subTotal | R$ 599,40 |  
        | desconto | R$ 239,76 |
        | total    | R$ 359,64 |
    
    Cenario: Pedido a partir de R$ 600,00 com desconto de 50%
      Dado que os produtos desejados são:
        | nome                      | referencia | tamanho | cor       | quantidade | desconto | preco     |
        | ARG DE PRATA ENC FIO LISO | AG3-0015   | unico   | sem pedra | 10         | 50%      | R$ 999,00 | 
      E estou na página de produtos com foto
      Quando eu adiciono todos os itens com cor e tamanho
      E acesso meu carrinho
      Então vejo todos os itens
      E os valores totais são:
        | subTotal | R$ 999,00 |  
        | desconto | R$ 499,50 |
        | total    | R$ 499,50 |

    Cenario: Adicionando somente produtos em promoção
      Dado que os produtos desejados são:
        | nome                                     | referencia | tamanho | cor               | quantidade | desconto | preco    |
        | PROMOCAO CORD+PULSEIRA+ARGOLA OLHO GREGO | PRM-0024   | unico   | resina multicores | 1          | 0%       | R$ 99,90 | 
        | PRM INF PULSEIRA+COLAR PEDRA E LIBELULA  | PRM-0025   | unico   | sem pedra         | 1          | 0%       | R$ 59,90 | 
        | PRM INF CO3-0018 + PL3-0022 + TR3-0010   | PRM-0026   | unico   | sem pedra         | 1          | 0%       | R$ 69,90 | 
        | PRM INF CO3-0019 + PL3-0021 + TR3-0001   | PRM-0027   | unico   | sem pedra         | 1          | 0%       | R$ 59,90 | 
      E estou na página de produtos em promoção
      Quando eu adiciono todos os itens com cor e tamanho
      E acesso meu carrinho
      Então vejo todos os itens
      E os valores totais são:
        | subTotal | R$ 289,60 |  
        | desconto | R$ 0,00   |
        | total    | R$ 289,60 |

    Cenario: Adicionando produtos em promoção e produtos sem promoção
      Dado que os produtos desejados são:
        | nome                                     | referencia      | tamanho | cor               | quantidade | desconto | preco    |
        | PROMOCAO CORD+PULSEIRA+ARGOLA OLHO GREGO | PRM-0024        | unico   | resina multicores | 1          | 0%       | R$ 99,90 | 
        | PRM INF PULSEIRA+COLAR PEDRA E LIBELULA  | PRM-0025        | unico   | sem pedra         | 1          | 0%       | R$ 59,90 | 
      E estou na página de produtos em promoção
      Quando eu adiciono todos os itens com cor e tamanho
      Dado que os produtos desejados são:
        | nome                                     | referencia      | tamanho | cor               | quantidade | desconto | preco    |
        | BR PEND CHAP QUADRA LISAS DET CRAQ       | PD3-0001/UN-000 | unico   | sem pedra         | 1          | 35%      | R$ 39,90 | 
        | BR PEND CURV FIO VENEZ E PEROLA          | PD3-0002/UN-093 | unico   | perola            | 1          | 35%      | R$ 39,90 |
      E estou na página de produtos com foto
      Quando eu adiciono todos os itens com cor e tamanho
      E acesso meu carrinho
      Então vejo todos os itens
      E os valores totais são:
        | subTotal | R$ 239,60 |  
        | desconto | R$ 27,93  |
        | total    | R$ 211,67 |
    
    Cenario: Adicionando somente produtos da linha lingerie desconto adicional fixo em 30%
      Dado que os produtos desejados são:
        | nome            | referencia | tamanho | cor      | quantidade | desconto | preco    |
        | TANGA SU        | LI3-0011   | p       | preto    | 1          | 30%      | R$ 14,90 | 
        | CAMISOLA JAMILY | LI3-0007   | m       | branco   | 1          | 30%      | R$ 69,90 |   
        | CAMISOLA VIVI   | LI3-0008   | m       | vermelho | 1          | 30%      | R$ 69,90 |   
        | TANGA CINTA     | LI3-0013   | gg      | marron   | 1          | 30%      | R$ 24,90 |   
      E estou na página de produtos com foto
      Quando eu adiciono todos os itens com cor e tamanho
      E acesso meu carrinho
      Então vejo todos os itens
      E os valores totais são:
        | subTotal | R$ 179,60 |  
        | desconto | R$ 53,88  |
        | total    | R$ 125,72 |

    Cenario: Adicionando produtos variados
      Dado que os produtos desejados são:
        | nome                                | referencia      | tamanho | cor       | quantidade | desconto | preco    |
        | TANGA SU                            | LI3-0011        | p       | preto     | 1          | 30%      | R$ 14,90 | 
        | CAMISOLA JAMILY                     | LI3-0007        | m       | branco    | 1          | 30%      | R$ 69,90 |   
        | CAMISOLA VIVI                       | LI3-0008        | m       | vermelho  | 1          | 30%      | R$ 69,90 |   
        | TANGA CINTA                         | LI3-0013        | gg      | marron    | 1          | 30%      | R$ 24,90 |   
        | BR PEND CHAP QUADR DET DIAMANTADO   | PD3-0007/UN-000 | unico   | sem pedra | 1          | 40%      | R$ 29,90 |
        | BR PEND CHAP QUADR VAZ E PEROLA     | PD3-0008/UN-093 | unico   | perola    | 1          | 40%      | R$ 29,90 |
        | BR PEND HASTE CHAPINHA FOLHA CURV   | PD3-0009/UN-000 | unico   | sem pedra | 1          | 40%      | R$ 29,90 |
        | BR PEQ COROA PEDRAS ZIR             | PQ3-0003/UN-001 | unico   | crystal   | 1          | 40%      | R$ 39,90 |
      E estou na página de produtos com foto
      Quando eu adiciono todos os itens com cor e tamanho
      Dado que os produtos desejados são:
        | nome                                     | referencia      | tamanho | cor               | quantidade | desconto | preco    |
        | PROMOCAO CORD+PULSEIRA+ARGOLA OLHO GREGO | PRM-0024        | unico   | resina multicores | 1          | 0%       | R$ 99,90 | 
        | PRM INF PULSEIRA+COLAR PEDRA E LIBELULA  | PRM-0025        | unico   | sem pedra         | 1          | 0%       | R$ 59,90 | 
      E estou na página de produtos em promoção
      Quando eu adiciono todos os itens com cor e tamanho
      E acesso meu carrinho
      Então vejo todos os itens
      E os valores totais são:
        | subTotal | R$ 469,00 |  
        | desconto | R$ 105,72 |
        | total    | R$ 363,28 |

  Cenario: Adicionando somente produtos com estoque zerado
      Dado que os produtos desejados são:
        | nome                | referencia | tamanho | cor      | quantidade | desconto | preco    |  
        | BOXER ROMANTIC LISA | LI3-0001   | m       | azul 2   | 1          | 30%      | R$ 19,90 |   
        | TANGA FIO RENDA     | LI3-0004   | p       | preto    | 1          | 30%      | R$ 9,90  |   
      E estou na página de produtos com foto
      Quando eu adiciono todos os itens com cor e tamanho
      E acesso meu carrinho
      Então vejo todos os itens
      E vejo a mensagem "Alguns dos itens selecionados não possuem estoque disponível. Por favor, verifique antes de continuar:"

  Cenario: Adicionando produtos com estoque e produtos com estoque zerado
      Dado que os produtos desejados são:
        | nome                | referencia | tamanho | cor      | quantidade | desconto | preco    |
        | TANGA SU            | LI3-0011   | p       | preto    | 1          | 30%      | R$ 14,90 | 
        | CAMISOLA JAMILY     | LI3-0007   | m       | branco   | 1          | 30%      | R$ 69,90 |   
        | CAMISOLA VIVI       | LI3-0008   | m       | vermelho | 1          | 30%      | R$ 69,90 |   
        | TANGA CINTA         | LI3-0013   | gg      | marron   | 1          | 30%      | R$ 24,90 |   
        | BOXER ROMANTIC LISA | LI3-0001   | m       | azul 2   | 1          | 30%      | R$ 19,90 |   
        | TANGA FIO RENDA     | LI3-0004   | p       | preto    | 1          | 30%      | R$ 9,90  |   
      E estou na página de produtos com foto
      Quando eu adiciono todos os itens com cor e tamanho
      E acesso meu carrinho
      Então vejo todos os itens
      E vejo a mensagem "Alguns dos itens selecionados não possuem estoque disponível. Por favor, verifique antes de continuar:"