Dado("que visito a página inicial") do
  @login_page.load
end

Quando("preencho meus dados de acesso") do
  @login_page.loginWith('89085','058483')
end

Então("eu vejo a mensagem {string}") do |message|
  expect(@login_page.verifyLoginMessage).to have_text message
end