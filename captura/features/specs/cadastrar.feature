#language:pt

Funcionalidade: Cadastrar nova revendedora
  Como possível revendedora da Styllus
  Sendo que possuo todos os meus dados
  Posso me cadastrar como revendedora

  Contexto: Gerar revendedora
    Dado que acesso o gerador de CPF
    E gero e copio os dados
@temp
  Cenario: Cadastrar uma revendedora sem indicação com sucesso
    Quando faço o cadastro da revendedora
    E verifico o kit de entrada 'Kit de Entrada: R$ 29.90'
    E finalizo a compra
    Então confirmo meus dados cadastrados