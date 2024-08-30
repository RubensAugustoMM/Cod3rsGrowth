sap.ui.define([
    "ui5/cod3rsgrowth/modelos/Repositorios/RepositorioEmpresas",
], function (
    RepositorioEmpresas,
) {
    return {
        obterTodasEmpresas: async function (filtro) {
            let parametrosFiltro = "";
            try {
                if (filtro != undefined && filtro != null) {
                    parametrosFiltro = '?';
                    const chavesFiltro = Object.keys(filtro);
                    const posicaoArrayRazaoSocialFiltro = 1;
                    const chaveFiltroRazaoSocial = chavesFiltro[posicaoArrayRazaoSocialFiltro];
                    if (filtro[chaveFiltroRazaoSocial] !== undefined) {
                        const parametroFiltroRazaoSocial = `&${chaveFiltroRazaoSocial}=`;
                        parametrosFiltro += parametroFiltroRazaoSocial + filtro[chaveFiltroRazaoSocial];
                    }

                    const posicaoArrayCnpjFiltro = 2;
                    const chaveFiltroCnpj = chavesFiltro[posicaoArrayCnpjFiltro];
                    if (filtro[chaveFiltroCnpj] !== undefined) {
                        const parametroFiltroCnpj = `&${chaveFiltroCnpj}=`;
                        parametrosFiltro += parametroFiltroCnpj + filtro[chaveFiltroCnpj];
                    }

                    const posicaoArraySituacaoCadastralFiltro = 0;
                    const chaveFiltroSituacaoCadastral = chavesFiltro[posicaoArraySituacaoCadastralFiltro];
                    if (filtro[chaveFiltroSituacaoCadastral] !== undefined) {
                        const parametroFiltroSituacaoCadastral = `&${chaveFiltroSituacaoCadastral}=`;
                        var valorSituacaoCadastralFiltro = parseInt(filtro[chaveFiltroSituacaoCadastral]);
                        parametrosFiltro += parametroFiltroSituacaoCadastral;
                        const valoresHabilitadosHabilitado = 1;
                        parametrosFiltro += valorSituacaoCadastralFiltro == valoresHabilitadosHabilitado;
                    }

                    const posicaoArrayDataAberturaFiltro = 4;
                    const chaveFiltroDataAberturaFiltro = chavesFiltro[posicaoArrayDataAberturaFiltro];
                    if (filtro[chaveFiltroDataAberturaFiltro] !== undefined &&
                        filtro[chaveFiltroDataAberturaFiltro] !== null) {
                        const parametroFiltroDataAbertura = `&${chaveFiltroDataAberturaFiltro}=`;
                        parametrosFiltro += parametroFiltroDataAbertura + filtro[chaveFiltroDataAberturaFiltro];
                    }

                    const posicaoArrayCapitalSocialFiltro = 3;
                    const chaveFiltroCapitalSocial = chavesFiltro[posicaoArrayCapitalSocialFiltro];
                    if (filtro[chaveFiltroCapitalSocial] !== undefined) {
                        const parametroFiltroCapitalSocial = `&${chaveFiltroCapitalSocial}=`;
                        parametrosFiltro += parametroFiltroCapitalSocial + filtro[chaveFiltroCapitalSocial];
                    }

                    const posicaoArrayNaturezaJuridicaFiltro = 5;
                    const chaveFiltroNaturezaJuridica = chavesFiltro[posicaoArrayNaturezaJuridicaFiltro];
                    if (filtro[chaveFiltroNaturezaJuridica] !== undefined) {
                        const parametroFiltroNaturezaJuridica = `&${chaveFiltroNaturezaJuridica}=`;
                        parametrosFiltro += parametroFiltroNaturezaJuridica + filtro[chaveFiltroNaturezaJuridica];
                    }

                    const posicaoArrayEstadoFiltro = 6;
                    const chaveFiltroEstado = chavesFiltro[posicaoArrayEstadoFiltro];
                    if (filtro[chaveFiltroEstado] !== undefined) {
                        const parametroFiltroEstado = `&${chaveFiltroEstado}=`;
                        parametrosFiltro += parametroFiltroEstado + filtro[chaveFiltroEstado];
                    }
                }
                return await RepositorioEmpresas.obterTodasEmpresas(parametrosFiltro);
            }
            catch (erro) {
                throw erro;
            }
        },

        criarEmpresa: async function (parametros) {
            debugger;
            const chavesParametro = Object.keys(parametros);
            const posicaoArrayRazaoSocial = 0;
            const posicaoArrayNomeFantasia = 1;
            const posicaoArrayCnpj = 2;
            const posicaoArraySituacaoCadastral = 3;
            const posicaoArrayDataSituacaoCadastral = 4;
            const posicaoArrayDataAbertura = 5;
            const posicaoArrayNaturezaJuridica = 6;
            const posicaoArrayPorte = 7;
            const posicaoArrayMatrizFilial = 8;
            const posicaoArrayCapitalSocial = 9;
            const posicaoArrayIdEndereco = 10;
            const valorNumericoPadrao = 0;
            const valorStringPadrao = "";
            const valorDataPadrao = "0001-01-01T01:01:01";
            try {
                const parametrosEmpresa = {
                    id: valorNumericoPadrao,
                    razaoSocial: parametros[chavesParametro[posicaoArrayRazaoSocial]] != null ?
                        parametros[chavesParametro[posicaoArrayRazaoSocial]] : valorStringPadrao,
                    nomeFantasia: parametros[chavesParametro[posicaoArrayNomeFantasia]] != null ?
                        parametros[chavesParametro[posicaoArrayNomeFantasia]] : valorStringPadrao,
                    cnpj: parametros[chavesParametro[posicaoArrayCnpj]] != null ?
                        parametros[chavesParametro[posicaoArrayCnpj]] : valorStringPadrao,
                    situacaoCadastral: parseInt(parametros[chavesParametro[posicaoArraySituacaoCadastral]] ?? valorNumericoPadrao),
                    dataSituacaoCadastral: parametros[chavesParametro[posicaoArrayDataSituacaoCadastral]] != null ?
                        parametros[chavesParametro[posicaoArrayDataSituacaoCadastral]] : valorStringPadrao,
                    idade: parametros[chavesParametro[posicaoArrayDataAbertura]] != null ?
                        new Date().getYear() - new Date(parametros[chavesParametro[posicaoArrayDataAbertura]]).getYear() : valorNumericoPadrao,
                    dataAbertura: parametros[chavesParametro[posicaoArrayDataAbertura]] != null ?
                        parametros[chavesParametro[posicaoArrayDataAbertura]] : new Date(valorDataPadrao),
                    naturezaJuridica: parseInt(parametros[chavesParametro[posicaoArrayNaturezaJuridica]] ?? valorNumericoPadrao),
                    porte: parseInt(parametros[chavesParametro[posicaoArrayPorte]] ?? valorNumericoPadrao),
                    matrizFilial: parseInt(parametros[chavesParametro[posicaoArrayMatrizFilial]] ?? valorNumericoPadrao),
                    capitalSocial: parseInt(parametros[chavesParametro[posicaoArrayCapitalSocial]]) ?
                        parseInt(parametros[chavesParametro[posicaoArrayCapitalSocial]]) : valorNumericoPadrao,
                    idEndereco: parametros[chavesParametro[posicaoArrayIdEndereco]] ?? valorNumericoPadrao
                }
                const valorHabilitado = 1;
                parametrosEmpresa[chavesParametro[posicaoArraySituacaoCadastral]] =
                    valorHabilitado == parseInt(parametros[chavesParametro[posicaoArraySituacaoCadastral]]);
                return await RepositorioEmpresas.criarEmpresa(parametrosEmpresa);
            }
            catch (erro) {
                throw erro;
            }
        }
    }
});