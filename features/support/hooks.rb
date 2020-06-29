Before do
  @login_page = LoginPage.new
  @products_page = ProductsPage.new
  @cart_page = CartPage.new
  
  page.driver.browser.manage.window.maximize
  #page.current_window.resize_to(1440, 900)
end

Before("@login") do
  @login_page.load
  @login_page.loginWith("89085", "058483")
end

Before("@productsPage") do
  @products_page.load
end