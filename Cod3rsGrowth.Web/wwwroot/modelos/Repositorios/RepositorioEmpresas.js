sap.ui.define([
], function () {
    return {
        _urlBase: "api/Empresas",

        obterTodasEmpresas: async function (parametroFiltro) {
            try {
                const resposta = await fetch(this._urlBase + parametroFiltro);
                if (!resposta.ok) throw new Error(resposta.message);
                return await resposta.json();
            }
            catch (erro) {
                console.log(erro);
                throw erro;
            }
        },
        criarEmpresa: async function (parametros) {
            try {
                const urlAcao = "/Criar"
                const resposta = await fetch(this._urlBase + urlAcao, {
                    method: "POST",
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({
                        id: parametros.id,
                        razaoSocial: parametros.razaoSocial,
                        nomeFantasia: parametros.nomeFantasia,
                        cnpj: parametros.cnpj,
                        situacaoCadastral: parametros.situacaoCadastral,
                        dataSituacaoCadastral: parametros.dataSituacaoCadastral,
                        idade: parametros.idade,
                        dataAbertura: parametros.dataAbertura,
                        naturezaJuridica: parametros.naturezaJuridica,
                        porte: parametros.porte,
                        matrizFilial: parametros.matrizFilial,
                        capitalSocial: parametros.capitalSocial,
                        idEndereco: parametros.idEndereco
                    })
                });
                return await resposta.json();
            }
            catch (erro) {
                console.log(erro);
                throw erro;
            }
        }
    }
});