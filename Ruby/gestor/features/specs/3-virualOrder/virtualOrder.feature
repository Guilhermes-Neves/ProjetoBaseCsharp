#language:pt

@login
Funcionalidade: Listagem de pedidos do escritório virtual
  Para que eu posso verificar todos os pedidos realizados no escritório virtual
  Sendo um gestor cadastrado préviamente
  Posso acessar a lista de pedidos

  Cenário: Alterar estado de um pedido
    Dado estou na página de pedidos do escritório
    Quando que filtro os pedidos com status "Novo"
    E altero para o status de "Entregue"
    E filtro novamente pelo status "Entregue"
    Então vejo o pedido na listagem