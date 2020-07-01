Dado("que os produtos desejados são:") do |table|
  @product_list = table.hashes
end

Quando("eu adiciono todos os itens") do
  @product_list.each do |p|
    @products_page.filterProduct(p["referencia"])
    @products_page.aplyQuantity(p["quantidade"])
    @products_page.addToCart
  end
end

Quando("acesso meu carrinho") do
  @cart_page.load
end

Quando("seleciono o tipo de frete como {string}") do |delivery|
  @cart_page.selectDelivery(delivery)
end

Então("vejo todos os itens no carrinho") do
  @product_list.each do |p|
    expect(@cart_page.findTable).to have_text p["nome"]
    expect(@cart_page.findTable).to have_text p["preco"]
  end
end

Então("o valor do subtotal deve ser de {string}") do |subtotal|
 expect(@cart_page.findSubtotal).to have_text subtotal
end

Então("o valor de desconto deve ser de {string}") do |discount|
  expect(@cart_page.findDiscount).to have_text discount
end

Então("o valor total deve ser de {string}") do |total|
  expect(@cart_page.findTotal).to have_text total
end

Então("não consigo finalizar o pedido") do
  @cart_page.findButtonCloseOrderDisabled
end

Então("vejo a mensagem de alerta {string}") do |message|
  expect(@cart_page.findAlertDanger).to have_text message
end

Então("a forma de pagamento {string} não deverá está presente") do |payment|
  expect(page.has_text?(payment)).to eq false
  
end

Então("o valor do frete deve ser de {string}") do |delivery|
  expect(@cart_page.findDelivery).to have_text delivery
end

Então("vejo a mensagem informativa {string}") do |message|
  expect(@cart_page.findAlertInfo(message)).to have_text message
end