Dado("que acesso o gerador de CPF") do
  @resellerGenerator.go
end

Dado("gero e copio os dados da pessoa") do
  @resellerGenerator.generateReseller
  @name = @resellerGenerator.getName
  @birthDate = @resellerGenerator.getBirthDate.delete("^0-9")
  @phoneNumber = @resellerGenerator.getPhoneNumber
  @resellerGenerator.goCpf
  @cpf = @resellerGenerator.getCpf
end

Dado("acesso o gerador de cartão") do
  @card_page.go
end

Dado("gero e copio os dados do cartão") do
  @card_page.generateCard
  @cardNumber = @card_page.getCardNumber
  @expirationDate = @card_page.getexpirationDate
  @securityCode = @card_page.getSecurityCode
end

Quando("faço o cadastro da revendedora") do
  @registerReseller.go
  @registerReseller.regReseller(@cpf,
                                @name,
                                @birthDate,
                                "teste@teste.com",
                                @phoneNumber)
end

Quando("não seleciono indicação") do
  @registerReseller.withoutRecommendation
end

Quando("seleciono como indicação o código {string}") do |recomendation|
  @registerReseller.selectRecomendation(recomendation)
end

Quando("continuo o cadastro") do
  @registerReseller.continueRegReseller("42", "casa")
end

Quando("não seleciono o frete") do
  @registerReseller.selectWithoutDelivery
end

Quando("finalizo a compra pagando com boleto") do
  @registerReseller.closeRegister
  @registerReseller.payment
  @registerReseller.payWithBillet
  @registerReseller.finishPayment
end

Quando("finalizo a compra pagando com cartão") do
  @registerReseller.closeRegister
  @registerReseller.payment
  @registerReseller.payWithCard(@cardNumber,
                                @expirationDate[3] +
                                @expirationDate[4],
                                @expirationDate[6] +
                                @expirationDate[7] +
                                @expirationDate[8] +
                                @expirationDate[9],
                                @securityCode)
  @registerReseller.finishPayment
end

Quando("seleciono o frete {string}") do |delivery|
  @registerReseller.selectDelivery(delivery)
end

Quando("verifico o kit inicial {string}") do |message|
  expect(@registerReseller.verifyFirstKit(message)).to have_text message
end

Quando("verifico o frete {string}") do |message|
  expect(@registerReseller.verifyFirstKit(message)).to have_text message
end

Então("vejo a mensagem {string}") do |message|
  expect(@registerReseller.verifyTitle).to have_text message
end

Então("o aviso {string}") do |message|
  expect(@registerReseller.verifyWarning).to have_text message
end
