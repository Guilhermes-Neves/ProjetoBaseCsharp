class RegisterResellerPage
  include Capybara::DSL

  def go
    visit "/"
    find(:xpath, '//*[@id="app"]/div/main/div/div/header/div/div[3]/button/span').click
  end

  def regReseller(cpf, name, birthDate, email, phone)
    find("#cpf").set cpf
    find("#nome").set name
    find("#dataNascimento").set birthDate
    find("#telefone").set phone
    find("#email").set email
    find(:xpath, "//*[@id='app']/div/main/div/div/div/div/div/div/div[2]/div[1]/div/form/div/div[8]/div/div/div[1]/div/div").click
  end

  def withoutRecommendation
    click_button "Continuar"
  end

  def selectRecomendation(codStyllus)
    find("#codigoStyllus").set codStyllus
    click_button "Continuar"
    click_button "Sim"
  end

  def continueRegReseller(number, complement)
    sleep 1
    find("#cep").set "83606122"
    find("#cep").send_keys :tab
    sleep 3
    find("#numero").set number
    find("#complemento").set complement
    find(:xpath, '//*[@id="app"]/div/main/div/div/div/div/div/div/div[2]/div[2]/div/form/div/div[8]/button').click
  end

  def selectWithoutDelivery
    find(:xpath, '//*[@id="app"]/div/main/div/div/div/div/div/div/div[2]/div[3]/div/div/div[3]/div/div/div[2]/div/div/div[1]/div/div').click
  end

  def selectDelivery(delivery)
    find(".v-select__selections").click
    find(".v-list-item__title", text: delivery).click
  end

  def verifyFirstKit(finalValue)
    find("p", text: finalValue)
  end

  def closeRegister
    click_button "Comprar"
  end

  def payment
    click_button "Pagar"
  end

  def payWithCard(cardNumber, month, year, securityCode)
    click_button "Cartão de Crédito"
    sleep 2
    find("#cardNumber").set cardNumber
    find("#cardName").set "Testando Cartão"
    select("#{month}", from: "cardMonth")
    select("#{year}", from: "cardYear")
    find("#cardCvv").set securityCode
    click_button "Continuar"
  end

  def payWithBillet
    click_button "Boleto"
  end

  def finishPayment
    click_button "Confirmar"
  end

  def verifyTitle
    find("#swal2-title")
  end

  def verifyWarning
    find("#swal2-content")
  end
end
