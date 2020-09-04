Dado("que os fretes desejados são:") do |table|
  @shipping_list = table.hashes
end

Dado("são novos fretes") do
  @shipping_list.each do |s|
    DataBase.new.delete_shipping(s["preco"])
  end
  @shipping_page.go
end

Quando("faço o cadastro") do
  @shipping_list.each do |s|
    @default_components.register
    @shipping_page.fillShippingForm(s["estado"], s["tipo"], s["peso"], s["preco"])
  end
end

Então("vejo a frete na listagem") do
  @shipping_list.each do |s|
    expect(page).to have_text s["estado"], s["tipo"], s["peso"], s["preco"]
  end
end
