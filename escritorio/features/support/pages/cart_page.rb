class CartPage
  include Capybara::DSL

  def load
    visit "/#/pedidos/carrinho"
  end

  def findTable(product)
    find("table tbody tr", text: product)
  end

  def findTotals(data)
    all(".item-resumo", text: data)[-1]
  end

  def findButtonCloseOrderDisabled
    find("button[disabled=disabled]")
  end

  def findAlert(message)
    find(".alert", text: message)
  end

  def selectDelivery(delivery)
    drop = find("select[name=frete]")
    drop.find("option", text: delivery).select_option
  end

  def selectPayment(payment)
    drop = find("select[name=forma_pagamento]")
    drop.find("option", text: payment).select_option
  end

  def emptyCart
    find(".fa-shopping-cart").click
    click_button "Esvaziar carrinho"
    find(".fa-shopping-cart").click
  end

  def removeItem(item)
    all("table tbody tr")[item].find(".action-item").click
  end

  def verifySubtotal
    all(".item-resumo", text: "SubTotal")[-1]
  end

  def closeOrder
    find(:xpath, '//*[@id="app"]/div/div[2]/div/div/div[2]/div/div/div[2]/div[3]/div/div/ul/li[5]/button').click
  end
end
