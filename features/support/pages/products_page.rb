class ProductsPage
  include Capybara::DSL

  def load
   find("a", text: "Novo Pedido").click
   find("a", text: "Pedido Rápido").click
  end

  def filterProduct(product)
    find(:xpath, '//*[@id="app"]/div/div[2]/div/div/div[1]/div/form/div/div[1]/div/input').set product
    click_button "Buscar"
  end

  def aplyQuantity(quantity)
    find('input[type=number]').set quantity
  end

  def addToCart
    find(".btn-add").click
  end

end