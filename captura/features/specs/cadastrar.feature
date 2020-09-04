#language:pt

Funcionalidade: Cadastrar nova revendedora
  Como possível revendedora da Styllus
  Sendo que possuo todos os meus dados
  Posso me cadastrar como revendedora
@temp
  #Cenario: Cadastrar uma revendedora
   # Dado que a revendedora não está cadastrada
    #E que a revendedora é:
    #  |cpf        |
    #  |16758155773|
   # Quando faço o cadastro da revendedora
   # E não seleciono indicação
   # E continuo o cadastro
   # E não seleciono o frete
   # E finalizo a compra pagando com boleto
   # Então vejo a mensagem 'Recebemos o seu pedido'
   # E o aviso 'Em até 72 horas ele será processado. Você receberá por e-mail um ID e senha para ter acesso ao escritório virtual.'

  Cenario: Cadastrar uma revendedora sem indicação pagando com boleto com sucesso sem frete
    Dado que acesso o gerador de CPF
    E gero e copio os dados da pessoa
    Quando faço o cadastro da revendedora
    E não seleciono indicação
    E continuo o cadastro
    E não seleciono o frete
    E finalizo a compra pagando com boleto
    Então vejo a mensagem 'Recebemos o seu pedido'
    E o aviso 'Em até 72 horas ele será processado. Você receberá por e-mail um ID e senha para ter acesso ao escritório virtual.'
  
  Cenario: Cadastrar uma revendedora sem indicação pagando com cartão com sucesso sem frete
    Dado que acesso o gerador de CPF
    E gero e copio os dados da pessoa
    E acesso o gerador de cartão
    E gero e copio os dados do cartão
    Quando faço o cadastro da revendedora
    E não seleciono indicação
    E continuo o cadastro
    E não seleciono o frete
    E finalizo a compra pagando com cartão
    Então vejo a mensagem 'Recebemos o seu pedido'
    E o aviso 'Em até 72 horas ele será processado. Você receberá por e-mail um ID e senha para ter acesso ao escritório virtual.'  

  Cenario: Cadastrar uma revendedora sem indicação pagando com boleto com sucesso com frete PAC
    Dado que acesso o gerador de CPF
    E gero e copio os dados da pessoa
    Quando faço o cadastro da revendedora
    E não seleciono indicação
    E continuo o cadastro
    E seleciono o frete "PAC"
    E verifico o kit inicial "Kit de Entrada: R$ 29.90"
    E verifico o frete "Valor do Frete: R$ 29.40"
    E finalizo a compra pagando com boleto
    Então vejo a mensagem 'Recebemos o seu pedido'
    E o aviso 'Em até 72 horas ele será processado. Você receberá por e-mail um ID e senha para ter acesso ao escritório virtual.'

  Cenario: Cadastrar uma revendedora sem indicação pagando com boleto com sucesso com frete Sedex
    Dado que acesso o gerador de CPF
    E gero e copio os dados da pessoa
    Quando faço o cadastro da revendedora
    E não seleciono indicação
    E continuo o cadastro
    E seleciono o frete "SEDEX"
    E verifico o kit inicial "Kit de Entrada: R$ 29.90"
    E verifico o frete "Valor do Frete: R$ 58.40"
    E finalizo a compra pagando com boleto
    Então vejo a mensagem 'Recebemos o seu pedido'
    E o aviso 'Em até 72 horas ele será processado. Você receberá por e-mail um ID e senha para ter acesso ao escritório virtual.'

  Cenario: Cadastrar uma revendedora com indicação pagando com boleto com sucesso com frete Sedex
    Dado que acesso o gerador de CPF
    E gero e copio os dados da pessoa
    Quando faço o cadastro da revendedora
    E seleciono como indicação o código '1590'
    E continuo o cadastro
    E seleciono o frete "SEDEX"
    E verifico o kit inicial "Kit de Entrada: R$ 29.90"
    E verifico o frete "Valor do Frete: R$ 58.40"
    E finalizo a compra pagando com boleto
    Então vejo a mensagem 'Recebemos o seu pedido'
    E o aviso 'Em até 72 horas ele será processado. Você receberá por e-mail um ID e senha para ter acesso ao escritório virtual.'
