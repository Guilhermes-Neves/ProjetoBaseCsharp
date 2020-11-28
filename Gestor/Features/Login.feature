#language: pt

Funcionalidade: Login
    Para que eu possa que eu possa gerir o meu escritório no Gestor
    Sendo um gestor previamente cadastrado
    Posso acessar o site com minhas credenciais

    Cenário: Login com dados validos e invalidos
        Dado que visito a página inicial
        Quando preencho meus dados de acesso "<email>" e "<Password>"
        Então eu vejo a mensagem <Message>

     Exemplos: 
     | email                             | Password       | Message                     |
     | pedro.albani@portalstyllus.com.br | Styllus2020!@# | Login efetuado com sucesso! |
     | pedro.albani@portalstyllus.com    | Styllus20      | Credenciais inválidas!      |

 