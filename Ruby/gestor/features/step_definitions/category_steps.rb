Dado("que estou na listagem de categorias") do
  sleep 3
  @category_page.go
end

Dado("a categoria é nova {string}") do |name|
  @category = name
  DataBase.new.delete_category(@category)
end

Quando("faço o cadastro da categoria") do
  @default_components.register
  @category_page.fillNameCategory(@category)
  @category_page.finishRegisterCategory
end

Então("vejo a mensagem {string}") do |message|
  @default_components.verifyMessage(message)
end

Então("vejo a categoria na listagem") do
  expect(@category_page.verifyCategory(@category)).to have_text @category
  DataBase.new.delete_category(@category)
end

Então("vejo o aviso de obrigatoriedade") do
  pending # Write code here that turns the phrase above into concrete actions
end

#exclusão de categoria
Dado("a categoria está cadastrada {string}") do |name|
  @category = name
  slug = name.gsub(" ", "-")
  DataBase.new.insert_category(name, slug.downcase!)
end

Quando("excluo a categoria") do
  @category_page.filterCategory(@category)
  @category_page.deleteCategory
end

Então("vejo o alerta {string}") do |message|
  @category_page.emptyCategory(message)
end

#edição de categoria
Quando("edito a categoria para {string}") do |editName|
  @newName = editName
  @category_page.filterCategory(@category)
  @category_page.editCategory
  sleep 2
  @category_page.fillNameCategory(editName)
  @category_page.finishRegisterCategory
end

Então("vejo a categoria alterada") do
  @category_page.filterCategory(@category + @newName)
  expect(@category_page.verifyCategory(@newName)).to have_text @newName
  DataBase.new.delete_category(@category + @newName)
end
