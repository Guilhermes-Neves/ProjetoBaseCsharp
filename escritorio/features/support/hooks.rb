require "base64"

Before do
  @login_page = LoginPage.new
  @products_page = ProductsPage.new
  @cart_page = CartPage.new
  @checkout_page = CheckoutPage.new
  @home_page = HomePage.new
  @manage_page = ManagerPage.new

  page.driver.browser.manage.window.maximize
  #page.current_window.resize_to(1440, 900)

  @host = String("142.44.247.200")
  @database = String("hlg_integrador")
  @username = String("styllus_hlg")
  @password = String("HLGST2019st!@#")

  @client = Mysql2::Client.new(:host => @host, :username => @username, :database => @database, :password => @password)
end

Before("@login") do
  @login_page.load
  @login_page.loginWith("1590", "113025")
end

After do
  shot_file = page.save_screenshot("log/screenshot.png")
  shot_b64 = Base64.encode64(File.open(shot_file, "rb").read)
  embed(shot_b64, "image/png", "Screenshot")
end
