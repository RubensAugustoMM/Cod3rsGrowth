sap.ui.define([
    "sap/m/MessageBox",
    "ui5/cod3rsgrowth/modelos/Repositorios/RepositorioEnderecos"
], function (
    MessageBox,
    RepositorioEnderecos
) {
    return {
        obterTodosEnderecos: async function (filtro) {
            parametrosFiltro += "?";

            try {
                if (filtro != undefined && filtro != null) {
                    const chavesFiltro = Object.keys(filtro);
                    const posicaoArrayNumeroFiltro = 0;
                    const chaveFiltroNumero = chavesFiltro[posicaoArrayNumeroFiltro];
                    if (filtro[chaveFiltroNumero] !== undefined) {
                        const parametroFiltroNumero = `&${chaveFiltroNumero}=`;
                        let valorNumero = filtro[chaveFiltroNumero];
                        parametrosFiltro += parametroFiltroNumero += valorNumero;
                    }

                    const posicaoArrayCepFiltro = 1;
                    const chaveFiltroCep = chavesFiltro[posicaoArrayCepFiltro];
                    if (filtro[chaveFiltroCep] !== undefined) {
                        const parametroFiltroCep = `&${chaveFiltroCep}=`;
                        let valorCep = filtro[chaveFiltroCep];
                        parametrosFiltro += parametroFiltroCep += valorCep;
                    }

                    const posicaoArrayMunicipioFiltro = 2;
                    const chaveFiltroMunicipio = chavesFiltro[posicaoArrayMunicipioFiltro];
                    if (filtro[chaveFiltroMunicipio !== undefined]) {
                        const parametroFiltroMunicipio = `&${chaveFiltroMunicipio}=`;
                        let valorMunicipio = filtro[chaveFiltroMunicipio];
                        parametrosFiltro += parametroFiltroMunicipio += valorMunicipio;
                    }

                    const posicaoArrayBairroFiltro = 3;
                    const chaveFiltroBairro = chavesFiltro[posicaoArrayBairroFiltro];
                    if (filtro[chaveFiltroBairro] !== undefined) {
                        const parametroFiltroBairro = `&${chaveFiltroBairro}=`;
                        let valorBairro = filtro[chaveFiltroBairro];
                        parametrosFiltro += parametroFiltroBairro += valorBairro;
                    }
                    const posicaoArrayEstadoFiltro = 4;
                    const chaveFiltroEstado = chavesFiltro[posicaoArrayEstadoFiltro];
                    if (filtro[chaveFiltroEstado] !== undefined) {
                        let PArametroFiltroEstado = `&${chaveFiltroEstado}=`;
                        parametrosFiltro += PArametroFiltroEstado + filtro[chaveFiltroEstado];
                    }
                }
                return await RepositorioEnderecos.obterTodosEnderecos(parametroFiltro);
            }
            catch (erro) {
                throw erro;
            }
        },
        criarEndereco: async function (parametros) {
            debugger;
            const chavesParametro = Object.keys(parametros);
            const posicaoArrayNumero = 0;
            const posicaoArrayCep = 1;
            const posicaoArrayMunicipio = 2;
            const posicaoArrayBairro = 3;
            const posicaoArrayRua = 4;
            const posicaoArrayComplemento = 5;
            const posicaoArrayEstado = 6;
            const valorNumericoPadrao = 0
            const valorStringPadrao = "";
            try {
            const parametrosEndereco = {
                id: valorNumericoPadrao,
                numero: parametros[chavesParametro[posicaoArrayNumero]] != null ?
                    parseInt(parametros[chavesParametro[posicaoArrayNumero]]) : valorNumericoPadrao,
                cep: parametros[chavesParametro[posicaoArrayCep]] != null ?
                    parametros[chavesParametro[posicaoArrayCep]] : valorStringPadrao,
                municipio: parametros[chavesParametro[posicaoArrayMunicipio]] != null ?
                    parametros[chavesParametro[posicaoArrayMunicipio]] : valorStringPadrao,
                bairro: parametros[chavesParametro[posicaoArrayBairro]] != null ?
                    parametros[chavesParametro[posicaoArrayBairro]] : valorStringPadrao,
                rua: parametros[chavesParametro[posicaoArrayRua]] != null ?
                    parametros[chavesParametro[posicaoArrayRua]] : valorStringPadrao,
                complemento: parametros[chavesParametro[posicaoArrayComplemento]] != null ?
                    parametros[chavesParametro[posicaoArrayComplemento]] : valorStringPadrao,
                estado: parseInt(parametros[chavesParametro[posicaoArrayEstado]] ?? valorNumericoPadrao)
            }
                return await RepositorioEnderecos.criarEndereco(parametrosEndereco);
            } 
            catch (erro) {
                throw erro;
            }
        }
    }
});