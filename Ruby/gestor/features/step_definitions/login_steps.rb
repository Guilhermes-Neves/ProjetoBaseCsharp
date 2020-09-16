Dado("que visito a página inicial") do
  @login_page.go
end

Quando("preencho meus dados de acesso") do
  find(".v-list-item__title", text: "Revendedoras").click
  sleep 1
  @login_page.loginWith("gestor@styllus.com.br", "123456")
  sleep 1
  @default_components.clickButton("Login")
end

Então("eu vejo a mensagem {string}") do |mensagem|
  expect(page).to have_text mensagem
end
