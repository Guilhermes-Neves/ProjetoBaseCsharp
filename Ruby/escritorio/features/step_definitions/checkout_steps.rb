Quando("gero um cartão para pagamento") do
  @card_page.go
  @card_page.generateCard
  @cardNumber = @card_page.getCardNumber
  @expirationDate = @card_page.getexpirationDate
  @securityCode = @card_page.getSecurityCode
end

Quando("clico na forma de pagamento {string}") do |payment|
  @checkout_page.selectPayment(payment)
end

Quando("finalizo o checkout") do
  @checkout_page.finishCheckOutCard(@cardNumber,
                                    "1",
                                    @get_total,
                                    @expirationDate[3] +
                                    @expirationDate[4],
                                    @expirationDate[6] +
                                    @expirationDate[7] +
                                    @expirationDate[8] +
                                    @expirationDate[9],
                                    @securityCode)
  @checkout_page.checkingDate
end

Quando("finalizo o checkout como boleto") do
  @checkout_page.finishCheckOutBillet
end

Então("vejo a confirmação do checkout com a mensagem {string}") do |message|
  @checkout_page.verifyAndCloseMessage(message)
end
