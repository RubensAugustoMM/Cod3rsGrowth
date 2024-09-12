sap.ui.define([], function () {
    return {
        _urlBase: "api/Escolas",
        obterTodasEscolas: async function (parametroFiltro) {
            const resposta = await fetch(this._urlBase + parametroFiltro);
            if (!resposta.ok) throw new Error(resposta.status);
            if (resposta.body != undefined)
                return await resposta.json();
        },
        obterEscolaPorId: async function (id) {
            const resposta = await fetch(this._urlBase + "/" + id);
            if (!resposta.ok) throw new Error(resposta.status);
            if (resposta.body != undefined)
                return await resposta.json();
        },
        criarEscola: async function (parametros) {
            const urlAcao = "/Criar"
            const resposta = await fetch(this._urlBase + urlAcao, {
                method: "POST",
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(parametros)
            });
            if (resposta.body != undefined)
                return await resposta.json();
        },
        deletarEscola: async function (id) {
            const urlAcao = "/Deletar/" + id;
            const resposta = await fetch(this._urlBase + urlAcao, {
                method: 'DELETE'
            });
            if (resposta.body != undefined)
                return await resposta.json();
        }
    }
});