class CategoryPage
  include Capybara::DSL

  def go
    visit "https://hlg-gestor.styllus.online/#/pages/ead/categorias"
  end

  def fillNameCategory(name)
    find("input[name=nome]").set name
  end

  def finishRegisterCategory
    find(:xpath, '//*[@id="app"]/div/main/div/div[2]/div/div/form/button').click
  end

  def verifyCategory(name)
    find("table tbody", text: name)
  end

  def filterCategory(name)
    search = find("input[type=text]")
    search.click
    search.set name

    find(:xpath, '//*[@id="app"]/div[1]/main/div/div[2]/div[1]/div[2]/div/div[1]/button').click
  end

  def deleteCategory
    find(".error--text").click
    find(:xpath, '//*[@id="app"]/div[3]/div/div/div[3]/button[2]').click
  end

  def editCategory
    find(".info--text").click
  end

  def emptyCategory(message)
    find("td", text: message)
  end
end
