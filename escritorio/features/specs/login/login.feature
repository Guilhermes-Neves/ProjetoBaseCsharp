#language: pt

Funcionalidade: Login
    Para que eu possa fazer pedidos no site da Styllus
    Sendo uma revendedora previamente cadastrada
    Posso acessar o site com minhas credenciais

    @loginTest
    Cenário: Login com sucesso
        Dado que visito a página inicial
        Quando preencho meus dados de acesso
        Então eu vejo a mensagem "Bem vindo ;)"
