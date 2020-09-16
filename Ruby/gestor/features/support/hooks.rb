require "base64"

Before do
  @login_page = LoginPage.new
  @manage_page = ManagerPage.new
  @default_components = DefaultComponents.new
  @category_page = CategoryPage.new
  @shipping_page = ShippingPage.new

  #page.driver.browser.manage.window.maximize
  #page.current_window.resize_to(1440, 900)

end

Before("@login") do
  @login_page.go
  find(".v-list-item__title", text: "Revendedoras").click
  sleep 1
  @login_page.loginWith("gestor@styllus.com.br", "123456")
  sleep 1
  @default_components.clickButton("Login")
end

After do
  shot_file = page.save_screenshot("log/screenshot.png")
  shot_b64 = Base64.encode64(File.open(shot_file, "rb").read)
  embed(shot_b64, "image/png", "Screenshot")
end
