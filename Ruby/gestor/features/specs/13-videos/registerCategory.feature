#language:pt

@login
Funcionalidade: Cadastrar uma nova categoria de vídeo
  Para que eu possa organizar meus vídeos cadastrados
  Sendo um gestor préviamente cadastrado
  Posso cadastrar categorias no sistema

  Cenário: Cadastrando uma categoria com sucesso
    Dado que estou na listagem de categorias
    E a categoria é nova "Testando o cadastro de categorias"
    Quando faço o cadastro da categoria
    Então vejo a mensagem "Operação realizada com sucesso"
    E vejo a categoria na listagem

 # Cenário: Verificar validação do nome da cateforia
  #  Dado que estou na listagem de categorias
   # E a categoria é nova ""
    #Quando faço o cadastro da categoria
    #Então vejo o aviso de obrigatoriedade