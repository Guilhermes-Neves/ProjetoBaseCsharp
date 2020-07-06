class ManagerPage
  include Capybara::DSL

  def clearCreditLimit
    visit "https://hlg-gestor.styllus.online/#/login"

    find("input[name=login]").set "gestor@styllus.com.br"
    find("#password").set "123456"

    click_button "Login"

    visit "https://hlg-gestor.styllus.online/#/pedidos/portal"
  end
end
