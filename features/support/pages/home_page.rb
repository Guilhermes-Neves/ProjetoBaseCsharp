class HomePage
  include Capybara::DSL

  def verifyCreditLimit
    find(:xpath, '//*[@id="app"]/div/div[2]/div/div/div[2]/div[1]/div/div/div[1]/div[1]/span').click
  end
end
