require "base64"

Before do
  @login_page = LoginPage.new
  @products_page = ProductsPage.new
  @cart_page = CartPage.new
  @checkout_page = CheckoutPage.new
  
  page.driver.browser.manage.window.maximize
  #page.current_window.resize_to(1440, 900)
end

Before("@login") do
  @login_page.load
  @login_page.loginWith("89085", "058483")
  @login_page.loadHome
end

Before("@productsPage") do
  @products_page.load
end

After do
  shot_file = page.save_screenshot("log/screenshot.png")
  shot_b64 = Base64.encode64(File.open(shot_file, "rb").read)
  embed(shot_b64, "image/png", "Screenshot")
end