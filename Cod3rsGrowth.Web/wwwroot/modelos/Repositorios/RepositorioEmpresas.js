sap.ui.define([
], function () {
    return {
        _urlBase: "api/Empresas",

        obterTodasEmpresas: async function (parametroFiltro) {
            const resposta = await fetch(this._urlBase + parametroFiltro);
            if (!resposta.ok) throw new Error(resposta.message);
            return resposta.json();
        },
        obterEmpresaPorId: async function (id) {
            const resposta = await fetch(this._urlBase + "/" + id);
            if (!resposta.ok) throw new Error(resposta.message);
            return resposta.json();
        },
        criarEmpresa: async function (parametros) {
            const resposta = await fetch(this._urlBase, {
                method: "POST",
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(parametros)
            });
            return resposta.json();
        },
        editarEmpresa: async function (parametros) {
            const resposta = await fetch(this._urlBase, {
                method: "PUT",
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(parametros)
            });
            if (!resposta.ok)
                return resposta.json();
        },
        deletarEmpresa: async function (id) {
            const resposta = await fetch(this._urlBase + "/" + id, {
                method: 'DELETE',
                headers: { 'Content-Type': 'application/json' },
            });
            if (!resposta.ok)
                return resposta.json();
        }
    }
});