class GeneratorResellerPage
  include Capybara::DSL

  def go
    visit "https://www.4devs.com.br/gerador_de_pessoas"
  end

  def generateReseller
    find("label[for=sexo_mulher]").click
    select("20", from: "idade")
    select("RJ", from: "cep_estado")
    select("Nova Friburgo", from: "cep_cidade")
    find("label[for=pontuacao_nao]").click
    find("#bt_gerar_pessoa").click
    sleep 5
  end

  def getName
    find("#nome").text
  end

  def getCpf
    find("#cpf").text
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
