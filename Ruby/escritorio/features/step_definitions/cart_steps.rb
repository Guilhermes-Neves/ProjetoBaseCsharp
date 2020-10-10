Dado("que os produtos desejados são:") do |table|
  @product_list = table.hashes
end

Dado("estou na página de pedido rápido") do
  @products_page.loadOrderFast
end

Dado("estou na página de produtos com foto") do
  @products_page.loadProducts
end

Dado("estou na página de produtos em promoção") do
  @products_page.loadOffers
end

Quando("eu adiciono todos os itens") do
  @product_list.each do |p|
    @products_page.filterProduct(p["referencia"])
    @products_page.aplyQuantity(p["quantidade"])
    @products_page.addToCart
  end
end

Quando("eu adiciono todos os itens com cor e tamanho") do
  @product_list.each do |p|
    @products_page.filterProductWithPhoto(p["referencia"])
    @products_page.aplyQuantity(p["quantidade"])
    @products_page.addSizeColor(p["tamanho"], p["cor"])
    @products_page.addToCart
  end
end

Quando("aumento a quantidade até ultrapassar o limite") do
  @get_limit = @cart_page.getCreditLimit
  @limit = @get_limit.delete(" (?:\.|)*R$").gsub(",", ".")
  @get_total = @cart_page.getTotal
  @total = @get_total.delete(" (?:\.|)*R$").gsub(",", ".")
  quantity = 100

  while @total < @limit
    @get_total = @cart_page.getTotal
    @total = @get_total.delete(" (?:\.|)*R$").gsub(",", ".")

    @cart_page.changeQuantity(quantity)
    quantity += 1
  end
end

Quando("acesso meu carrinho") do
  @cart_page.load
  @get_limit = @cart_page.getCreditLimit
  @limit = @get_limit.delete(" (?:\.|)*R$").gsub(",", ".")
  @get_total = @cart_page.getTotal
  @total = @get_total.delete(" (?:\.|)*R$").gsub(",", ".")
end

Quando("seleciono o tipo de frete como {string}") do |delivery|
  @cart_page.selectDelivery(delivery)
end

Então("vejo todos os itens") do
  @product_list.each do |p|
    product = @cart_page.findTable(p["nome"])
    expect(product).to have_content p["nome"]
    expect(product).to have_content p["desconto"]
    expect(product).to have_content p["preco"]
  end
end

Então("vejo todos os itens no pedido") do
  @product_list.each do |p|
    product = @cart_page.findTable(p["nome"])
    expect(product).to have_content p["nome"]
    expect(product).to have_content p["preco"]
    expect(product).to have_content p["tamanho"]
    expect(product).to have_content p["cor"]
    expect(product).to have_content p["quantidade"]
  end
end

Então("os valores totais são:") do |table|
  totals = table.rows_hash
  expect(@cart_page.findTotals("SubTotal:")).to have_text totals[:subTotal]
  expect(@cart_page.findTotals("Desconto:")).to have_text totals[:desconto]
  expect(@cart_page.findTotals("Total:")).to have_text totals[:total]
end

Então("não consigo finalizar o pedido") do
  @cart_page.findButtonCloseOrderDisabled
end

Então("vejo a mensagem {string}") do |message|
  expect(@cart_page.findAlert(message)).to have_text message
end

Então("a forma de pagamento {string} não deverá está presente") do |payment|
  expect(page.has_text?(payment)).to eq false
end

#Remover itens do carrinho

Dado("estão no carrinho") do
  steps %{
    E estou na página de produtos com foto
    Quando eu adiciono todos os itens com cor e tamanho
  }
end

Quando("eu esvazio o carrinho") do
  @cart_page.emptyCart
end

Quando("removo o {int}") do |item|
  @cart_page.removeItem(item)
end

Então("o valor total deve ser de {string}") do |value|
  expect(@cart_page.verifySubtotal).to have_text value
end

# finalizando o pedido

Quando("seleciono a forma de pagamento {string}") do |payment|
  @cart_page.selectPayment(payment)
end

Quando("finalizo o pedido") do
  @cart_page.closeOrder
end

Quando("capturo o número do pedido") do
  sleep 5
  orderNumber = @checkout_page.getOrderNumber
  @orderId = orderNumber.delete("^0-9")
end

Então("visito a página inicial") do
  @login_page.load
end

Então("vejo o limite de crédito") do
  newCreditLimit = (@limit.to_f - @total.to_f).round(2, half: :up)
  newCreditLimit.round(2, half: :up)
  completeCreditLimit = "R$ #{newCreditLimit.round(2, half: :up).to_s.gsub(".", ",")}"
  expect(@home_page.verifyCreditLimit.text.gsub(".", "")).to have_text completeCreditLimit
end

Então("libero o limite de crédito") do
  @manage_page.load
  @manage_page.login
  @manage_page.loadOrders
  @manage_page.clearCreditLimit(@orderId)
end

# utilizando cashback
Dado("possuo {string} reais de cashback") do |value|
  DataBase.new.up_cashback("459", value)
end

Quando("utilizo {string} reais de cashback") do |value|
  @cart_page.applyCashback(value)
end

Então("a forma de pagamento {string} deverá está presente") do |payment|
  expect(page.has_text?(payment)).to eq true
end

Então("a mensagem {string} não é exibida") do |message|
  expect(page.has_text?(message)).to eq false
end