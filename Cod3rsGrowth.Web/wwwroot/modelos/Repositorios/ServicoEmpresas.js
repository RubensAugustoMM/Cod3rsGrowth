sap.ui.define([
], function (
) {
    return {
        obterTodasEmpresas: async function (filtro) {
            let parametrosQuery = "";
            
            try {
                const chavesFiltro = Object.keys(filtro);
                if (chavesFiltro.length !== 0) {
                    parametrosQuery += '?';
                    
                    const posicaoArrayRazaoSocialFiltro = 1;
                    const chaveFiltroRazaoSocial = chavesFiltro[posicaoArrayRazaoSocialFiltro];
                    if (filtro[chaveFiltroRazaoSocial] !== undefined) {
                        const sParametroFiltroRazaoSocial = `&${chaveFiltroRazaoSocial}=`;
                        parametrosQuery += sParametroFiltroRazaoSocial  + filtro[chaveFiltroRazaoSocial];
                    }

                    const posicaoArrayCnpjFiltro = 2;
                    const chaveFiltroCnpj = chavesFiltro[posicaoArrayCnpjFiltro];
                    if (filtro[chaveFiltroCnpj] !== undefined) {
                        const sParametroFiltroCnpj = `&${chaveFiltroCnpj}=`;
                        parametrosQuery += sParametroFiltroCnpj  + filtro[chaveFiltroCnpj];
                    }

                    const posicaoArraySituacaoCadastralFiltro = 0;
                    const chaveFiltroSituacaoCadastral = chavesFiltro[posicaoArraySituacaoCadastralFiltro];
                    const valoresHabilitadosIndefinido = -1;
                    if (parseInt(filtro[chaveFiltroSituacaoCadastral]) !== valoresHabilitadosIndefinido) {
                        const sParametroFiltroSituacaoCadastral = `&${chaveFiltroSituacaoCadastral}=`;
                        var valorSituacaoCadastralFiltro = parseInt(filtro[chaveFiltroSituacaoCadastral]);
                        parametrosQuery += sParametroFiltroSituacaoCadastral;
                        const valoresHabilitadosHabilitado = 1;
                        parametrosQuery += valorSituacaoCadastralFiltro == valoresHabilitadosHabilitado;
                    }

                    const posicaoArrayDataAberturaFiltro = 4;
                    const chaveFiltroDataAberturaFiltro = chavesFiltro[posicaoArrayDataAberturaFiltro];
                    if (filtro[chaveFiltroDataAberturaFiltro] !== undefined &&
                        filtro[chaveFiltroDataAberturaFiltro] !== null) {
                        const sParametroFiltroDataAbertura = `&${chaveFiltroDataAberturaFiltro}=`;
                        parametrosQuery += sParametroFiltroDataAbertura + filtro[chaveFiltroDataAberturaFiltro];
                    }

                    const posicaoArrayCapitalSocialFiltro = 3;
                    const chaveFiltroCapitalSocial = chavesFiltro[posicaoArrayCapitalSocialFiltro];
                    if (filtro[chaveFiltroCapitalSocial] !== undefined) {
                        const sParametroFiltroCapitalSocial = `&${chaveFiltroCapitalSocial}=`;
                        parametrosQuery += sParametroFiltroCapitalSocial + filtro[chaveFiltroCapitalSocial];
                    }

                    const posicaoArrayNaturezaJuridicaFiltro = 5;
                    const chaveFiltroNaturezaJuridica = chavesFiltro[posicaoArrayNaturezaJuridicaFiltro];
                    const valoresNaturezaJuridicaIndefinido = -1; 
                    if (parseInt(filtro[chaveFiltroNaturezaJuridica]) !== valoresNaturezaJuridicaIndefinido) {
                        const sParametroFiltroNaturezaJuridica = `&${chaveFiltroNaturezaJuridica}=`;
                        parametrosQuery += sParametroFiltroNaturezaJuridica + filtro[chaveFiltroNaturezaJuridica];
                    }

                    const posicaoArrayEstadoFiltro = 6;
                    const chaveFiltroEstado = chavesFiltro[posicaoArrayEstadoFiltro];
                    if (filtro[chaveFiltroEstado] !== undefined) {
                        const sParametroFiltroEstado = `&${chaveFiltroEstado}=`;
                        parametrosQuery += sParametroFiltroEstado + filtro[chaveFiltroEstado];
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
        }
    }
});