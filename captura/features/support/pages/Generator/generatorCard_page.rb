class GenerateCardPage
  include Capybara::DSL

  def go
    visit "https://www.4devs.com.br/gerador_de_numero_cartao_credito"
  end

  def generateCard
    find('label[for="pontuacao_nao"]').click
    find("#bt_gerar_cc").click
  end

  def getCardNumber
    find("#cartao_numero").text
  end

  def getexpirationDate
    find("#data_validade").text
  end

  def getSecurityCode
    find("#codigo_seguranca").text
  end
end
