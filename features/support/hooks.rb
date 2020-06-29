Before do
  @login_page = LoginPage.new
  
  page.driver.browser.manage.window.maximize
  #page.current_window.resize_to(1440, 900)
end

Before("@login") do
  @login_page.go
  @login_page.loginWith("89085", "058483")
end
