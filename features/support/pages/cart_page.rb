class CartPage
  include Capybara::DSL

  def load
    find(".fa-shopping-cart").click
    find(".btn-success", text:"Ver carrinho completo").click
  end

  def findTable
    find(".table")
  end

  def findSubtotal
    find(:xpath, "//*[@id='app']/div/div[2]/div/div/div[2]/div/div/div[2]/div[3]/div/div/ul/li[1]")
  end

  def findDiscount
    find(:xpath, "//*[@id='app']/div/div[2]/div/div/div[2]/div/div/div[2]/div[3]/div/div/ul/li[2]")
  end

  def findTotal
    find(:xpath, "//*[@id='app']/div/div[2]/div/div/div[2]/div/div/div[2]/div[3]/div/div/ul/li[3]")
  end

  def findButtonCloseOrderDisabled
    find('button[disabled=disabled]')
  end

  def findAlert
    find('.alert-danger')
  end
end