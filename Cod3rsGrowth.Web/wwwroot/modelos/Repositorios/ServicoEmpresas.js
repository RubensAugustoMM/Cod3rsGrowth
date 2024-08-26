sap.ui.define([
], function (
) {
    return {
        obterTodasEmpresas: async function (oFiltro) {
            let parametrosQuery = "";
            
            try {
                const aChavesFiltro = Object.keys(oFiltro);
                if (aChavesFiltro.length !== 0) {
                    parametrosQuery += '?';
                    
                    const posicaoArrayRazaoSocialFiltro = 1;
                    if (oFiltro[aChavesFiltro[posicaoArrayRazaoSocialFiltro]] !== undefined) {
                        const sParametroFiltroRazaoSocial = `&${aChavesFiltro[posicaoArrayRazaoSocialFiltro]}=`;
                        parametrosQuery += sParametroFiltroRazaoSocial  + oFiltro[aChavesFiltro[posicaoArrayRazaoSocialFiltro]];
                    }

                    const posicaoArrayCnpjFiltro = 2;
                    if (oFiltro[aChavesFiltro[posicaoArrayCnpjFiltro]] !== undefined) {
                        const sParametroFiltroCnpj = `&${aChavesFiltro[posicaoArrayCnpjFiltro]}=`;
                        parametrosQuery += sParametroFiltroCnpj  + oFiltro["CnpjFiltro"];
                    }

                    const posicaoArraySituacaoCadastralFiltro = 0;
                    const valoresHabilitadosIndefinido = -1;
                    const valoresHabilitadosHabilitado = 1;
                    if (parseInt(oFiltro[aChavesFiltro[posicaoArraySituacaoCadastralFiltro]]) !== valoresHabilitadosIndefinido) {
                        const sParametroFiltroSituacaoCadastral = `&${aChavesFiltro[posicaoArraySituacaoCadastralFiltro]}=`;
                        var valorSituacaoCadastralFiltro = parseInt(oFiltro[aChavesFiltro[posicaoArraySituacaoCadastralFiltro]]);
                        parametrosQuery += sParametroFiltroSituacaoCadastral;
                        parametrosQuery += valorSituacaoCadastralFiltro == valoresHabilitadosHabilitado;
                    }

                    const posicaoArrayDataAberturaFiltro = 4;
                    if (oFiltro[aChavesFiltro[posicaoArrayDataAberturaFiltro]] !== undefined &&
                        oFiltro[aChavesFiltro[posicaoArrayDataAberturaFiltro]] !== null) {
                        const sParametroFiltroDataAbertura = `&${aChavesFiltro[posicaoArrayDataAberturaFiltro]}=`;
                        parametrosQuery += sParametroFiltroDataAbertura + oFiltro[aChavesFiltro[posicaoArrayDataAberturaFiltro]];
                    }

                    const posicaoArrayCapitalSocialFiltro = 3;
                    if (oFiltro[aChavesFiltro[posicaoArrayCapitalSocialFiltro]] !== undefined) {
                        const sParametroFiltroCapitalSocial = `&${aChavesFiltro[posicaoArrayCapitalSocialFiltro]}=`;
                        parametrosQuery += sParametroFiltroCapitalSocial + oFiltro[aChavesFiltro[posicaoArrayCapitalSocialFiltro]];
                    }

                    const posicaoArrayNaturezaJuridicaFiltro = 5;
                    const valoresNaturezaJuridicaIndefinido = -1; 
                    if (parseInt(oFiltro[aChavesFiltro[posicaoArrayNaturezaJuridicaFiltro]]) !== valoresNaturezaJuridicaIndefinido) {
                        const sParametroFiltroNaturezaJuridica = `&${aChavesFiltro[posicaoArrayNaturezaJuridicaFiltro]}=`;
                        parametrosQuery += sParametroFiltroNaturezaJuridica + oFiltro[aChavesFiltro[posicaoArrayNaturezaJuridicaFiltro]];
                    }

                    const posicaoArrayEstadoFiltro = 6;
                    if (oFiltro[aChavesFiltro[posicaoArrayEstadoFiltro]] !== undefined) {
                        const sParametroFiltroEstado = `&${aChavesFiltro[posicaoArrayEstadoFiltro]}=`;
                        parametrosQuery += sParametroFiltroEstado + oFiltro[aChavesFiltro[posicaoArrayEstadoFiltro]];
                    }
                }

                const resposta = await fetch(this._baseURL + '/Empresas' + parametrosQuery);

                if (!resposta.ok) throw new Error(resposta.status);

                return await resposta.json();
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao receber dados de Empresas:\n";
                console.error(mensagemDeErro + erro);
            }
        },
        obterEmpresaPorId: function (sIdEmpresas) { },
        deletarEmpresa: function (sIdEmpresas) { },
        atualizarEmpresa: function (sIdEmpresas) { },
        criarEmpresa: function (oData) { }
    }
});