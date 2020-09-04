class LoginPage
  include Capybara::DSL

  def go
    visit "/"
  end

  def loginWith(email, password)
    find("input[name=email]").set email
    find("input[name=pass]").set password
  end
end
