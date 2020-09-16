#language: pt

Funcionalidade: Logout
	Para que eu possa sair do sistema
	Sendo um usuário préviamente cadastrado
	Posso sair do sistema

	Cenário: Logout com sucesso
		Dado que estou logado
		Quando realizo o logout
		Então vejo a página de login