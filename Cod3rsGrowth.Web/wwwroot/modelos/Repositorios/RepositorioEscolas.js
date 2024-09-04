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
                throw erro;
            }
        },
        criarEscola: async function (parametros) {
            const urlAcao = "/Criar"
            const resposta = await fetch(this._urlBase + urlAcao, {
                method: "POST",
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(parametros)
            });
            return await resposta.json();
        }
    }
});