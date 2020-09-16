class DefaultComponents
  include Capybara::DSL

  def clickButton(name)
    click_button "#{name}"
  end

  def register
    find(".indigo").click
  end

  def verifyMessage(message)
    find(".toast-text", text: message)
  end
end
