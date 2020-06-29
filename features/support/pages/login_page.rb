class LoginPage

  include Capybara::DSL

  def load 
    visit '/'
  end

  def loginWith(styllusCode, password)
    find("#input-email").set styllusCode
    find("#input-password").set password
    click_button 'Entrar'
  end

  def verifyLoginMessage
    find(".vn-message")
  end
end