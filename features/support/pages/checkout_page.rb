class CheckoutPage
  
  include Capybara::DSL
  
  def verifyLoginMessage
    find(".vn-message")
  end

end