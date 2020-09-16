#language:pt

@login
Funcionalidade: Edição de categoria
  Para que eu possa manter as categorias sempre atualizadas
  Sendo um gestor préviamente cadastrado
  Posso editar uma categoria
  
  Cenário: Editar uma categoria
    Dado que estou na listagem de categorias
    E a categoria está cadastrada "Testando a edição de categorias"
    Quando edito a categoria para " editada"
    Então vejo a mensagem "Operação realizada com sucesso"
    E vejo a categoria alterada