#language: pt

Funcionalidade: Login
    Para que eu possa fazer pedidos no site da Styllus
    Sendo uma revendedora previamente cadastrada
    Posso acessar o site com minhas credenciais

    Cenário: Login com dados validos e invalidos
        Dado que visito a página inicial "https://hlg-escritorio.styllus.online/"
        Quando preencho meus dados de acesso "<CodStyllus>" e "<Password>"
        Então eu vejo a mensagem <Message>

     Exemplos: 
     | CodStyllus | Password | Message                                                                                         |
     | 1390398    | 167581   | Bem vindo ;)                                                                                    |
     | 13903231   | 1449051  | A combinação de usuário e senha não foi identificada. Por favor, verefique os dados informados. |

 