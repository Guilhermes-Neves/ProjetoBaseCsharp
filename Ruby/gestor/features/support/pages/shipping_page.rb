class ShippingPage
  include Capybara::DSL

  def go
    visit "https://hlg-gestor.styllus.online/#/pages/configurador-frete"
  end

  def fillShippingForm(state, typeShipping, weight, cost)
    stateField = find(:xpath, "/html/body/div[1]/div/main/div/div[2]/div/div/form/div[1]/div/div[1]/div[1]")
    stateField.click
    stateField.set state
    stateField.send_keys :enter

    typeField = find(:xpath, '//*[@id="app"]/div/main/div/div[2]/div/div/form/div[2]/div/div[1]')
    typeField.click
    typeField.set typeShipping
    typeField.send_keys :enter

    find("input[name=pesoMaximo]").set weight

    find("input[name=preco]").set cost
  end
end
