require "capybara"
require "capybara/cucumber"
require "selenium-webdriver"

@browser = ENV["BROWSER"]

case @browser
when "chrome"
  @driver = :selenium_chrome
when "firefox"
  @driver = :selenium
when "chrome_headless"
  @driver = :selenium_chrome_headless
when "firefox_headless"
  @driver = :selenium_headless
end

Capybara.configure do |config|
  config.default_driver = @driver
  config.app_host = "https://hlg-revenda.styllus.online/#/apresentacao"
  config.default_max_wait_time = 20
end

Capybara.register_driver :chrome do |app|
  client = Selenium::WebDriver::Remote::Http::Default.new
  client.read_timeout = 12000000000

  Capybara::Selenium::Driver.new(app, { browser: :chrome, http_client: client })
end

Capybara.register_driver :firefox do |app|
  client = Selenium::WebDriver::Remote::Http::Default.new
  client.read_timeout = 12000000000

  Capybara::Selenium::Driver.new(app, { browser: :firefox, http_client: client })
end
