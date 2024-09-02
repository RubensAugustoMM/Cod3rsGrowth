sap.ui.define([
    "sap/m/MessageBox"
], function (
    MessageBox
) {
    return {
        _urlBase: "api/Enderecos",
        obterTodosEnderecos: async function (parametroFiltro) {
            try {
                const resposta = await fetch(this._urlBase + parametroFiltro);
                if (!resposta.ok) throw new Error(resposta.status);
                return await resposta.json();
            }
            catch (erro) {
                throw erro;
            }
        },
        criarEndereco: async function (parametros) {
            const posicaoArrayId = 0
            const posicaoArrayNumero = 1;
            const posicaoArrayCep = 2;
            const posicaoArrayMunicipio = 3;
            const posicaoArrayBairro = 4;
            const posicaoArrayRua = 5;
            const posicaoArrayComplemento = 6;
            const posicaoArrayEstado = 7;
            try {
                const chavesParametro = Object.keys(parametros);
                const urlAcao = "/Criar";
                const resposta = await fetch(this._urlBase + urlAcao, {
                    method: "POST",
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({
                        id: parametros[chavesParametro[posicaoArrayId]],
                        numero: parametros[chavesParametro[posicaoArrayNumero]],
                        cep: parametros[chavesParametro[posicaoArrayCep]],
                        municipio: parametros[chavesParametro[posicaoArrayMunicipio]],
                        bairro: parametros[chavesParametro[posicaoArrayBairro]],
                        rua: parametros[chavesParametro[posicaoArrayRua]],
                        complemento: parametros[posicaoArrayComplemento],
                        estado: parametros[chavesParametro[posicaoArrayEstado]]
                    })
                });
                return await resposta.json();
            } catch (erro) {
                throw erro;
            }
        }
    }
});