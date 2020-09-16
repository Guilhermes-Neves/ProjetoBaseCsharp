#language: pt

Funcionalidade: Cadastros de vídeos EAD
  Para que eu possa disponibilizar vídeos de capacitação
  Sendo um gestor da plataforma préviamente cadastrado
  Posso realizar cadastros de vídeos

  Cenário: Cadastrando um vídeo com sucesso
    Dado que estou na listagem de vídeos
    Quando faço o cadastro de um novo vídeo
    Então vejo a mensagem
    E vejo o vídeo na listagem
  