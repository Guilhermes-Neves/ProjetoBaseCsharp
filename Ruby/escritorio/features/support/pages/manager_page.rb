class ManagerPage
  include Capybara::DSL

  def load
    visit "https://hlg-gestor.styllus.online"
    sleep 1
    find(".v-list-item__title", text: "Revendedoras").click
    sleep 1
  end

  def loadProduction
    visit "https://gestor.styllus.online/"
  end

  def login
    find("input[name=email]").set "gestor@styllus.com.br"
    find("input[name=pass]").set "123456"

    click_button "Login"
  end

  def loadOrders
    find(".v-list-item__title", text: "Pedidos (Esc. Virtual)").click
  end

  def clearCreditLimit(orderId)
    order = find("table tbody tr", text: orderId)
    order.find(:xpath, '//*[@id="app"]/div/main/div/div[2]/div[1]/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[10]/a/i').click
    find(:xpath, '//*[@id="app"]/div[3]/div/div/div[2]/div[1]/div/div[1]/div[1]/div[1]').click
    find(".v-list-item__title", text: "CANCELADO").click
    find(".v-btn__content", text: "SALVAR").click
  end
end
