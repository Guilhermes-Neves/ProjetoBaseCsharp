class RegisterResellerPage
  include Capybara::DSL

  def go
    visit "/"
    find(:xpath, '//*[@id="app"]/div/main/div/div/header/div/div[3]/button/span').click
  end

  def regReseller(cpf, name, birthDate, email, phone, zipCode, number, complement, delivery)
    find("#cpf").set cpf
    find("#nome").set name
    find("#dataNascimento").set birthDate
    find("#telefone").set phone
    find("#email").set email
    find(".v-icon").click
    find("#cep").set zipCode
    find("#numero").set number
    find("#complemento").set complement
    find(:xpath, '//*[@id="app"]/div/main/div/div/div/div/div/div/div[2]/div[2]/div/form/div/div[8]/button').click
    find(".v-select__selections").click
    find(".v-list-item__title", text: delivery)
  end

  def closeOrder
    find(".v-btn__content", text: "COMPRAR").click
  end
end
