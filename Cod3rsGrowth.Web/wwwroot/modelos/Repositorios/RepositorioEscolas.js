sap.ui.define(["sap/m/MessageBox"
], function (
	MessageBox) {
    return {
        _urlBase: "api/Escolas",

        obterTodasEscolas: async function (parametroFiltro) {
            try {
                const resposta = await fetch(this._urlBase + parametroFiltro);
                if (!resposta.ok) throw new Error(resposta.status);
                return await resposta.json();
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao receber dados de Empresas:\n";
                console.error(mensagemDeErro + erro.message);
                MessageBox.show(erro.message, {
                    icon: MessageBox.Icon.ERROR,
                    title: mensagemDeErro,
                    actions: [MessageBox.Action.CLOSE]
                });
            }
        }
    }
});