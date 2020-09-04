class GeneratorResellerPage
  include Capybara::DSL

  def go
    visit "https://www.4devs.com.br/gerador_de_pessoas"
  end

  def goCpf
    visit "https://www.treinaweb.com.br/ferramentas-para-desenvolvedores/gerador/cpf"
  end

  def generateCpf
    find('label[for="pontuacao_nao"]').click
    find("#bt_gerar_cpf").click
    sleep 3
  end

  def generateReseller
    find("label[for=sexo_mulher]").click
    select("20", from: "idade")
    select("RJ", from: "cep_estado")
    find("label[for=pontuacao_nao]").click
    find("#bt_gerar_pessoa").click
    sleep 5
  end

  def getName
    find("#nome").text
  end

  def getCpf
    find(:xpath, "/html/body/div/div/div/div/div[1]/div/div/div[2]/div[3]/span[1]").text
  end

  def getBirthDate
    find("#data_nasc").text
  end

  def getPhoneNumber
    find("#celular").text
  end

  def getZipCode
    find("#cep").text
  end
end
