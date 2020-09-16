#language:pt

@login
Funcionalidade: Configuração de frete
  Para que eu possa controlar os valores de frete para as regiões
  Sendo um gestor préviamente cadastrado
  Posso configurar o frete
@temp
  Cenario: Cadastrando um frete
    Dado que os fretes desejados são:
      | estado | tipo           | peso   | preco  |
      | Acre   | Entrega Normal | 100000 | 100000 |
    E são novos fretes
    Quando faço o cadastro 
    Então vejo a mensagem "Operação realizada com sucesso"
    E vejo a frete na listagem