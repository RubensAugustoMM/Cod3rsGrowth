sap.ui.define(["sap/m/MessageBox"
], function (
    MessageBox) {
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
            debugger;
            const posicaoArrayId = 0;
            const posicaoArrayRazaoSocial = 1;
            const posicaoArrayNomeFantasia = 2;
            const posicaoArrayCnpj = 3;
            const posicaoArraySituacaoCadastral = 4;
            const posicaoArrayDataSituacaoCadastral = 5;
            const posicaoArrayIdade = 6;
            const posicaoArrayDataAbertura = 7;
            const posicaoArrayNaturezaJuridica = 8;
            const posicaoArrayPorte = 9;
            const posicaoArrayMatrizFilial = 10;
            const posicaoArrayCapitalSocial = 11;
            const posicaoArrayIdEndereco = 12;
            try {
                const urlAcao = "/Criar"
                const chavesParametro = Object.keys(parametros);
                const resposta = await fetch(this._urlBase + urlAcao, {
                    method: "POST",
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({
                        id: parametros[chavesParametro[posicaoArrayId]],
                        razaoSocial: parametros[chavesParametro[posicaoArrayRazaoSocial]],
                        nomeFantasia: parametros[chavesParametro[posicaoArrayNomeFantasia]],
                        cnpj: parametros[chavesParametro[posicaoArrayCnpj]],
                        situacaoCadastral: parametros[chavesParametro[posicaoArraySituacaoCadastral]],
                        dataSituacaoCadastral: parametros[chavesParametro[posicaoArrayDataSituacaoCadastral]],
                        idade: parametros[chavesParametro[posicaoArrayIdade]],
                        dataAbertura: parametros[chavesParametro[posicaoArrayDataAbertura]],
                        posicaoArrayNaturezaJuridica: parametros[chavesParametro[posicaoArrayNaturezaJuridica]],
                        porte: parametros[chavesParametro[posicaoArrayPorte]],
                        matrizFilial: parametros[chavesParametro[posicaoArrayMatrizFilial]],
                        capitalSocial: parametros[chavesParametro[posicaoArrayCapitalSocial]],
                        idEndereco: parametros[chavesParametro[posicaoArrayIdEndereco]]
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