Dado("que acesso o gerador de CPF") do
  @resellerGenerator.go
end

Dado("gero e copio os dados") do
  @resellerGenerator.generateReseller
  @name = @resellerGenerator.getName
  @cpf = @resellerGenerator.getCpf
  @birthDate = @resellerGenerator.getBirthDate.delete("^0-9")
  @phoneNumber = @resellerGenerator.getPhoneNumber
  @zipCode = @resellerGenerator.getZipCode
end

Quando("faço o cadastro da revendedora") do
  @registerReseller.go
  @registerReseller.regReseller(@cpf,
                                @name,
                                @birthDate,
                                "teste@teste.com",
                                @phoneNumber,
                                @zipCode,
                                "42",
                                "casa",
                                "sedex")
end

Quando("verifico o kit de entrada {string}") do |message|
  expect(page).to have_text message
end

Quando("finalizo a compra") do
  @registerReseller.closeOrder
end

Então("confirmo meus dados cadastrados") do
end
