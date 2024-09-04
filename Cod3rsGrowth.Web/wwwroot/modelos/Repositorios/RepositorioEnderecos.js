sap.ui.define([
    "sap/m/MessageBox"
], function (
    MessageBox
) {
    return {
        _urlBase: "api/Enderecos",
        obterTodosEnderecos: async function (parametroFiltro) {
            const resposta = await fetch(this._urlBase + parametroFiltro);
            if (!resposta.ok) throw new Error(resposta.status);
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
            return await resposta.json();
        }
    }
});