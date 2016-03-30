#language:pt-br
@Main
Funcionalidade: Clickme
	Como usuário gostaria de entrar na tela e clicar no botão "Click Me".

Cenário: Abro a tela e clico no botão
	Dado Que eu estou na tela de "Main"
	Quando Eu pressiono o botão "btnClickme"
	Então Devo preencher o campo "txbName" com o valor "Você me Clicou"
