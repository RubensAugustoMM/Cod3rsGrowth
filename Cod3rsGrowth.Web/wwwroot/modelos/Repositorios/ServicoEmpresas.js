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
                    const chaveFiltroRazaoSocial = aChavesFiltro[posicaoArrayRazaoSocialFiltro];
                    if (oFiltro[chaveFiltroRazaoSocial] !== undefined) {
                        const sParametroFiltroRazaoSocial = `&${chaveFiltroRazaoSocial}=`;
                        parametrosQuery += sParametroFiltroRazaoSocial  + oFiltro[chaveFiltroRazaoSocial];
                    }

                    const posicaoArrayCnpjFiltro = 2;
                    const chaveFiltroCnpj = aChavesFiltro[posicaoArrayCnpjFiltro];
                    if (oFiltro[chaveFiltroCnpj] !== undefined) {
                        const sParametroFiltroCnpj = `&${chaveFiltroCnpj}=`;
                        parametrosQuery += sParametroFiltroCnpj  + oFiltro[chaveFiltroCnpj];
                    }

                    const posicaoArraySituacaoCadastralFiltro = 0;
                    const chaveFiltroSituacaoCadastral = aChavesFiltro[posicaoArraySituacaoCadastralFiltro];
                    const valoresHabilitadosIndefinido = -1;
                    if (parseInt(oFiltro[chaveFiltroSituacaoCadastral]) !== valoresHabilitadosIndefinido) {
                        const sParametroFiltroSituacaoCadastral = `&${chaveFiltroSituacaoCadastral}=`;
                        var valorSituacaoCadastralFiltro = parseInt(oFiltro[chaveFiltroSituacaoCadastral]);
                        parametrosQuery += sParametroFiltroSituacaoCadastral;
                        const valoresHabilitadosHabilitado = 1;
                        parametrosQuery += valorSituacaoCadastralFiltro == valoresHabilitadosHabilitado;
                    }

                    const posicaoArrayDataAberturaFiltro = 4;
                    const chaveFiltroDataAberturaFiltro = aChavesFiltro[posicaoArrayDataAberturaFiltro];
                    if (oFiltro[chaveFiltroDataAberturaFiltro] !== undefined &&
                        oFiltro[chaveFiltroDataAberturaFiltro] !== null) {
                        const sParametroFiltroDataAbertura = `&${chaveFiltroDataAberturaFiltro}=`;
                        parametrosQuery += sParametroFiltroDataAbertura + oFiltro[chaveFiltroDataAberturaFiltro];
                    }

                    const posicaoArrayCapitalSocialFiltro = 3;
                    const chaveFiltroCapitalSocial = aChavesFiltro[posicaoArrayCapitalSocialFiltro];
                    if (oFiltro[chaveFiltroCapitalSocial] !== undefined) {
                        const sParametroFiltroCapitalSocial = `&${chaveFiltroCapitalSocial}=`;
                        parametrosQuery += sParametroFiltroCapitalSocial + oFiltro[chaveFiltroCapitalSocial];
                    }

                    const posicaoArrayNaturezaJuridicaFiltro = 5;
                    const chaveFiltroNaturezaJuridica = aChavesFiltro[posicaoArrayNaturezaJuridicaFiltro];
                    const valoresNaturezaJuridicaIndefinido = -1; 
                    if (parseInt(oFiltro[chaveFiltroNaturezaJuridica]) !== valoresNaturezaJuridicaIndefinido) {
                        const sParametroFiltroNaturezaJuridica = `&${chaveFiltroNaturezaJuridica}=`;
                        parametrosQuery += sParametroFiltroNaturezaJuridica + oFiltro[chaveFiltroNaturezaJuridica];
                    }

                    const posicaoArrayEstadoFiltro = 6;
                    const chaveFiltroEstado = aChavesFiltro[posicaoArrayEstadoFiltro];
                    if (oFiltro[chaveFiltroEstado] !== undefined) {
                        const sParametroFiltroEstado = `&${chaveFiltroEstado}=`;
                        parametrosQuery += sParametroFiltroEstado + oFiltro[chaveFiltroEstado];
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