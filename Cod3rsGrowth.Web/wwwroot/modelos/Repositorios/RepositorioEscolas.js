sap.ui.define([
], function () {
    return {
        _urlBase: "api/Escolas",

        obterTodasEscolas: async function (parametroFiltro) {
            try {
                const resposta = await fetch(this._urlBase + parametroFiltro);
                if (!resposta.ok) throw new Error(resposta.status);
                return await resposta.json();
            }
            catch (erro) {
                throw (erro);
            }
        }
    }
});