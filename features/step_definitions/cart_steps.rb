Dado("que os produtos desejados são:") do |table|
  @product_list = table.hashes
end

Quando("eu adiciono todos os itens") do
  @product_list.each do |p|
    @products_page.filterProduct(p["referencia"])
    @products_page.addToCart
  end
end

Quando("acesso meu carrinho") do
  @cart_page.load
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

Então("vejo a mensagem {string}") do |message|
  expect(@cart_page.findAlert).to have_text message
end