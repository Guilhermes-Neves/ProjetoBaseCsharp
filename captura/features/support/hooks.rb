require "base64"

Before do
  page.driver.browser.manage.window.maximize
  #page.current_window.resize_to(1440, 900)

  @resellerGenerator = GeneratorResellerPage.new
  @registerReseller = RegisterResellerPage.new

  @host = String("142.44.247.200")
  @database = String("hlg_integrador")
  @username = String("styllus_hlg")
  @password = String("HLGST2019st!@#")

  @client = Mysql2::Client.new(:host => @host, :username => @username, :database => @database, :password => @password)
end

After do
  shot_file = page.save_screenshot("log/screenshot.png")
  shot_b64 = Base64.encode64(File.open(shot_file, "rb").read)
  embed(shot_b64, "image/png", "Screenshot")
end
