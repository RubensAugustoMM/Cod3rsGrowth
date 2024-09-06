sap.ui.define([
], function () {
    return {
        _urlBase: "api/Empresas",

        obterTodasEmpresas: async function (parametroFiltro) {
            const resposta = await fetch(this._urlBase + parametroFiltro);
            if (!resposta.ok) throw new Error(resposta.message);
            return await resposta.json();
        },
        obterEmpresaPorId: async function (id) {
            const resposta = await fetch(this._urlBase + "/" + id); 
            if (!resposta.ok) throw new Error(resposta.status);
            return await resposta.json();
        },
        criarEmpresa: async function (parametros) {
            const urlAcao = "/Criar"
            const resposta = await fetch(this._urlBase + urlAcao, {
                method: "POST",
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(parametros)
            });
            return await resposta.json();
        },
        editarEmpresa: async function (parametros) {
            const urlAcao = "/Atualizar"
            const resposta = await fetch(this._urlBase + urlAcao, {
                method: "PUT",
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(parametros)
            });
            return await resposta.json();
        }
    }
});