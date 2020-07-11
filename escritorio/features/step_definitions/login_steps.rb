Dado("que visito a página inicial") do
  @login_page.load
end

Quando("preencho meus dados de acesso") do
  @login_page.loginWith("89085", "058483")
end

Então("eu vejo o nome do usuário {string}") do |usuario|
  loggedUser = "OLÁ, #{usuario}"
  expect(@login_page.verifyLoggedUser(loggedUser)).to have_text loggedUser
end
