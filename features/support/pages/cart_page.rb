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

  def findDelivery
    find(:xpath, "//*[@id='app']/div/div[2]/div/div/div[2]/div/div/div[2]/div[3]/div/div/ul/li[3]")
  end

  def findButtonCloseOrderDisabled
    find('button[disabled=disabled]')
  end

  def findAlertDanger
    find('.alert-danger')
  end

  def findAlertInfo(message)
    find('.alert-info', text: message)
  end

  def selectDelivery(delivery)
    drop = find('select[name=frete]')
    drop.find('option', text: delivery).select_option
  end

  def selectPayment(payment)
    drop = find('select[name=forma_pagamento]')
    drop.find('option', text: payment)
  end
end