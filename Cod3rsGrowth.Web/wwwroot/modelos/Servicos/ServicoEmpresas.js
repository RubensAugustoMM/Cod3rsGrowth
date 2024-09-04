sap.ui.define([
    "ui5/cod3rsgrowth/modelos/Repositorios/RepositorioEmpresas",
], function (
    RepositorioEmpresas,
) {
    return {
        obterTodasEmpresas: async function (filtro) {
            let parametrosFiltro = "";
            if (filtro != undefined && filtro != null) {
                parametrosFiltro = '?';
                const chavesFiltro = Object.keys(filtro);
                const posicaoArrayRazaoSocialFiltro = 1;
                const chaveFiltroRazaoSocial = chavesFiltro[posicaoArrayRazaoSocialFiltro];
                if (filtro.RazaoSocialFiltro !== undefined) {
                    const parametroFiltroRazaoSocial = `&${chaveFiltroRazaoSocial}=`;
                    parametrosFiltro += parametroFiltroRazaoSocial + filtro.RazaoSocialFiltro;
                }

                const posicaoArrayCnpjFiltro = 2;
                const chaveFiltroCnpj = chavesFiltro[posicaoArrayCnpjFiltro];
                if (filtro.CnpjFiltro !== undefined) {
                    const parametroFiltroCnpj = `&${chaveFiltroCnpj}=`;
                    parametrosFiltro += parametroFiltroCnpj + filtro.CnpjFiltro;
                }

                const posicaoArraySituacaoCadastralFiltro = 0;
                const chaveFiltroSituacaoCadastral = chavesFiltro[posicaoArraySituacaoCadastralFiltro];
                if (filtro.SituacaoCadastralFiltro !== undefined) {
                    const parametroFiltroSituacaoCadastral = `&${chaveFiltroSituacaoCadastral}=`;
                    var valorSituacaoCadastralFiltro = parseInt(filtro.SituacaoCadastralFiltro);
                    parametrosFiltro += parametroFiltroSituacaoCadastral;
                    const valoresHabilitadosHabilitado = 1;
                    parametrosFiltro += valorSituacaoCadastralFiltro == valoresHabilitadosHabilitado;
                }

                const posicaoArrayDataAberturaFiltro = 4;
                const chaveFiltroDataAberturaFiltro = chavesFiltro[posicaoArrayDataAberturaFiltro];
                if (filtro.DataAberturaFiltro !== undefined &&
                    filtro.DataAberturaFiltro !== null) {
                    const parametroFiltroDataAbertura = `&${chaveFiltroDataAberturaFiltro}=`;
                    parametrosFiltro += parametroFiltroDataAbertura + filtro.DataAberturaFiltro;
                }

                const posicaoArrayCapitalSocialFiltro = 3;
                const chaveFiltroCapitalSocial = chavesFiltro[posicaoArrayCapitalSocialFiltro];
                if (filtro.CapitalSocialFiltro !== undefined) {
                    const parametroFiltroCapitalSocial = `&${chaveFiltroCapitalSocial}=`;
                    parametrosFiltro += parametroFiltroCapitalSocial + filtro.CapitalSocialFiltro;
                }

                const posicaoArrayNaturezaJuridicaFiltro = 5;
                const chaveFiltroNaturezaJuridica = chavesFiltro[posicaoArrayNaturezaJuridicaFiltro];
                if (filtro.NaturezaJuridicaFiltro !== undefined) {
                    const parametroFiltroNaturezaJuridica = `&${chaveFiltroNaturezaJuridica}=`;
                    parametrosFiltro += parametroFiltroNaturezaJuridica + filtro.NaturezaJuridicaFiltro;
                }

                const posicaoArrayEstadoFiltro = 6;
                const chaveFiltroEstado = chavesFiltro[posicaoArrayEstadoFiltro];
                if (filtro.EstadoFiltro !== undefined) {
                    const parametroFiltroEstado = `&${chaveFiltroEstado}=`;
                    parametrosFiltro += parametroFiltroEstado + filtro.EstadoFiltro;
                }
            }
            return await RepositorioEmpresas.obterTodasEmpresas(parametrosFiltro);
        },
        criarEmpresa: async function (parametros,modelo) {
            debugger;
            const nomeProrpriedadeValorNumericoPadrao = "/valorNumericoPadrao";
            const nomePropriedadeValorStringPadrao = "/valorStringPadrao";
            const nomePropriedadeValorDataPadrao = "/valorDataPadrao";
            const valorNumericoPadrao = modelo.getProperty(nomeProrpriedadeValorNumericoPadrao);
            const valorStringPadrao = modelo.getProperty(nomePropriedadeValorStringPadrao);
            const valorDataPadrao = modelo.getProperty(nomePropriedadeValorDataPadrao);
            const parametrosEmpresa = {
                id: valorNumericoPadrao,
                razaoSocial: parametros.razaoSocial != null ? parametros.razaoSocial : valorStringPadrao,
                nomeFantasia: parametros.nomeFantasia != null ? parametros.nomeFantasia : valorStringPadrao,
                cnpj: parametros.cnpj != null ? parametros.cnpj : valorStringPadrao,
                situacaoCadastral: parseInt(parametros.situacaoCadastral ?? valorNumericoPadrao),
                dataSituacaoCadastral: parametros.dataSituacaoCadastral != null ? parametros.dataSituacaoCadastral : valorStringPadrao,
                idade: parametros.dataAbertura != null ?
                    new Date().getYear() - new Date(parametros.dataAbertura).getYear() : valorNumericoPadrao,
                dataAbertura: parametros.dataAbertura != null ? parametros.dataAbertura : new Date(valorDataPadrao),
                naturezaJuridica: parseInt(parametros.naturezaJuridica ?? valorNumericoPadrao),
                porte: parseInt(parametros.porte ?? valorNumericoPadrao),
                matrizFilial: parseInt(parametros.matrizFilial ?? valorNumericoPadrao),
                capitalSocial: parseFloat(parametros.capitalSocial) ? parseInt(parametros.capitalSocial) : valorNumericoPadrao,
                idEndereco: parametros.idEndereco ?? valorNumericoPadrao
            }
            const valorHabilitado = 1;
            parametrosEmpresa.situacaoCadastral =
                valorHabilitado == parseInt(parametros.situacaoCadastral);
            return await RepositorioEmpresas.criarEmpresa(parametrosEmpresa);
        }
    }
});