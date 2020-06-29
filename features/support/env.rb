require "capybara"
require "capybara/cucumber"
require "selenium-webdriver"

Capybara.configure do |config|
  config.default_driver = :selenium
  config.app_host = "https://hlg-escritorio.styllus.online"
  config.default_max_wait_time = 10000000
end

Capybara.register_driver :chrome do |app|
  client = Selenium::WebDriver::Remote::Http::Default.new
  client.read_timeout = 120

  Capybara::Selenium::Driver.new(app, {browser: :chrome, http_client: client})
end

Capybara.register_driver :firefox do |app|
  client = Selenium::WebDriver::Remote::Http::Default.new
  client.read_timeout = 12000000

  Capybara::Selenium::Driver.new(app, {browser: :firefox, http_client: client})
end