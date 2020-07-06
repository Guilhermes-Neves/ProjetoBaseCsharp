class CheckoutPage
  include Capybara::DSL

  def getOrderNumber
    find(:xpath, '//*[@id="app"]/div/div[2]/div/div/div[1]/div/div[1]/div/h5').text
  end
end
