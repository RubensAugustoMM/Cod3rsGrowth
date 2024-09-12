sap.ui.define([
], function (
) {
    return {
        _urlBase: "api/Enderecos",
        obterTodosEnderecos: async function (parametroFiltro) {
            const resposta = await fetch(this._urlBase + parametroFiltro);
            if (!resposta.ok) throw new Error(resposta.status);
                return await resposta.json();
        },
        obterEnderecoPorId: async function (id) {
            const resposta = await fetch(this._urlBase + "/" + id);
            if (!resposta.ok) throw new Error(resposta.status);
            if (resposta.body != undefined)
                return await resposta.json();
        },
        editarEndereco: async function (parametros) {
            const resposta = await fetch(this._urlBase, {
                method: "PUT",
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(parametros)
            });
            if (resposta.body != undefined)
                return await resposta.json();
        },
        criarEndereco: async function (parametros) {
            const urlAcao = "/Criar";
            const resposta = await fetch(this._urlBase + urlAcao, {
                method: "POST",
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(parametros)
            });
                return await resposta.json();
        },
        deletarEndereco: async function (id) {
            const urlAcao = "/Deletar/" + id;
            const resposta = await fetch(this._urlBase + urlAcao, {
                method: 'DELETE'
            });
            if (!resposta.ok)
                return resposta.json();
        }
    }
});