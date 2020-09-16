require "base64"

Before do
  @login_page = LoginPage.new
  @products_page = ProductsPage.new
  @cart_page = CartPage.new
  @checkout_page = CheckoutPage.new
  @home_page = HomePage.new
  @manage_page = ManagerPage.new
  @card_page = GenerateCardPage.new

  #page.driver.browser.manage.window.maximize
  #page.current_window.resize_to(1440, 900)

end

Before("@login") do
  @login_page.load
  @login_page.loginWith("1590", "Jesco1986")
end

Before("@loginProduction") do
  @login_page.loadProduction
  @login_page.loginWith("1590", "Jesco1986")
end

After do
  shot_file = page.save_screenshot("log/screenshot.png")
  shot_b64 = Base64.encode64(File.open(shot_file, "rb").read)
  embed(shot_b64, "image/png", "Screenshot")
end
