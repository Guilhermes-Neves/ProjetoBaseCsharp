#language:pt

Funcionalidade: Ajuste cashback manualmente
	Para que eu possa ajustar o cashback manualmente
	Sendo um gestor previamente cadastrado
	Posso adicionar ou excluir cashback para uma revendedora

	Cenário: Adicionar cashback para uma revendedora
		Dado que edito uma revendedora
		Quando adiciono cashback para a mesma
		Então vejo a mensagem de sucesso "Operação realizada com sucesso"

	Cenário: Deletar cashback de uma revendedora
		Dado que edito uma revendedora
		Quando deleto o cashback 
		Então vejo a mensagem de sucesso "Operação realizada com sucesso"