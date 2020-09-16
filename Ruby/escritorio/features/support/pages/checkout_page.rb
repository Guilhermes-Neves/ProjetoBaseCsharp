class CheckoutPage
  include Capybara::DSL

  def getOrderNumber
    find(:xpath, '//*[@id="app"]/div/div[2]/div/div/div[1]/div/div[1]/div/h5').text
  end

  def selectPayment(payment)
    click_button payment
  end

  def finishCheckOutCard(cardNumber, plots, value, month, year, securityCode)
    sleep 3
    find("#cardNumber").set cardNumber
    sleep 2
    find("#cardName").set "Testando Cartao"
    #select("#{plots} X #{value}", from: "cardInstallments")
    select("#{month}", from: "cardMonth")
    select("#{year}", from: "cardYear")
    find("#cardCvv").set securityCode
  end

  def finishCheckOutBillet
    click_button "Continuar"
    click_button "Confirmar"
  end

  def checkingDate
    2.times {
      sleep 1
      click_button "Continuar"
    }
    click_button "Confirmar"
  end

  def verifyAndCloseMessage(message)
    find("#swal2-content", text: message)
    click_button "OK"
  end
end
