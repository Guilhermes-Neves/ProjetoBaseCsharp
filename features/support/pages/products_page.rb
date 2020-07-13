class ProductsPage
  include Capybara::DSL

  def loadOrderFast
    visit "/#/pedido-rapido"
  end

  def loadProducts
    visit "/#/produtos"
  end

  def loadOffers
    visit "/#/produtos/promocao"
  end

  def filterProductWithPhoto(product)
    find(:xpath, '//*[@id="app"]/div/div[2]/div/div/div[1]/div/form/div/div[2]/div/input').set product
    sleep 1
    click_button "Buscar"
    sleep 1
  end

  def filterProduct(product)
    find(:xpath, '//*[@id="app"]/div/div[2]/div/div/div[1]/div/form/div/div[1]/div/input').set product
    sleep 1
    click_button "Buscar"
    sleep 1
  end

  def aplyQuantity(quantity)
    find("input[type=number]").set quantity
  end

  def addToCart
    sleep 1
    find(".btn-add").click
  end

  def addSizeColor(size, color)
    baseXpath = '//*[@id="app"]/div/div[2]/div/div/div[2]/div[2]/div/div[3]/'

    dropSize = find(:xpath, "#{baseXpath}div[1]/select")
    dropSize.find("option", text: size.upcase!).select_option

    dropColor = find(:xpath, "#{baseXpath}div[2]/select")
    dropColor.find("option", text: color.upcase!).select_option
  end
end
