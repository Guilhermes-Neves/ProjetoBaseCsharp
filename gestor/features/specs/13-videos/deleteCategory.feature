#language:pt

@login
Funcionalidade: Exclusão de categoria
  Para que eu possa manter a listagem de categorias sempre atualizada
  Sendo um gestor préviamente cadastrado
  Posso excluir uma categoria

  Cenário: Excluir uma categoria
    Dado que estou na listagem de categorias
    E a categoria está cadastrada "Testando a exclusão de categorias"
    Quando excluo a categoria
    Então vejo a mensagem "Operação realizada com sucesso"
    E vejo o alerta "Não há dados disponíveis"