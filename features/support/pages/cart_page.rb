class CartPage
  include Capybara::DSL

  def go
    '/#/pedido-rapido'
  end

  def filterProduct(product)
    find(:xpath, '//*[@id="app"]/div/div[2]/div/div/div[1]/div/form/div/div[1]/div/input').set product
    click_button "Buscar"
  end

  def addToCart
    find(".btn-add").click
  end

end