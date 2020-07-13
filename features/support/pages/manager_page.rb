class ManagerPage
  include Capybara::DSL

  def load
    visit "https://hlg-gestor.styllus.online/#/login"
  end

  def login
    find("input[name=login]").set "gestor@styllus.com.br"
    find("#password").set "123456"

    click_button "Login"
  end

  def loadOrders
    find(:xpath, '//*[@id="inspire"]/div[1]/header/div/button[1]/span/i').click
    find(".v-list-item__title", text: "Pedidos (Esc. Virtual)").click
  end

  def clearCreditLimit(orderId)
    sleep 5
    order = find("table tbody tr a", text: orderId)
    order.find(:xpath, '//*[@id="inspire"]/div[1]/main/div/div/div[2]/div/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[10]/a/i').click
    find(:xpath, '//*[@id="inspire"]/div[3]/div/div/div[2]/div[1]/div/div[1]/div[1]/div[1]').click
    find(".v-list-item__title", text: "CANCELADO").click
    find(".v-btn__content", text: "SALVAR").click
  end
end
