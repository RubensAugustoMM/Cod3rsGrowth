sap.ui.define([
    "ui5/cod3rsgrowth/modelos/Repositorios/RepositorioEnderecos"
], function (
    RepositorioEnderecos
) {
    return {
        obterTodosEnderecos: async function (filtro) {
            if (filtro != undefined && filtro != null) {
                const chavesFiltro = Object.keys(filtro);
                const posicaoArrayNumeroFiltro = 0;
                const chaveFiltroNumero = chavesFiltro[posicaoArrayNumeroFiltro];
                if (filtro.NumeroFiltro !== undefined) {
                    const parametroFiltroNumero = `&${chaveFiltroNumero}=`;
                    let valorNumero = filtro.NumeroFiltro;
                    parametrosFiltro += parametroFiltroNumero += valorNumero;
                }

                const posicaoArrayCepFiltro = 1;
                const chaveFiltroCep = chavesFiltro[posicaoArrayCepFiltro];
                if (filtro.CepFiltro !== undefined) {
                    const parametroFiltroCep = `&${chaveFiltroCep}=`;
                    let valorCep = filtro.CepFiltro;
                    parametrosFiltro += parametroFiltroCep += valorCep;
                }

                const posicaoArrayMunicipioFiltro = 2;
                const chaveFiltroMunicipio = chavesFiltro[posicaoArrayMunicipioFiltro];
                if (filtro.MunicipioFiltro !== undefined) {
                    const parametroFiltroMunicipio = `&${chaveFiltroMunicipio}=`;
                    let valorMunicipio = filtro.MunicipioFiltro;
                    parametrosFiltro += parametroFiltroMunicipio += valorMunicipio;
                }

                const posicaoArrayBairroFiltro = 3;
                const chaveFiltroBairro = chavesFiltro[posicaoArrayBairroFiltro];
                if (filtro.BairroFiltro !== undefined) {
                    const parametroFiltroBairro = `&${chaveFiltroBairro}=`;
                    let valorBairro = filtro.BairroFiltro;
                    parametrosFiltro += parametroFiltroBairro += valorBairro;
                }
                const posicaoArrayEstadoFiltro = 4;
                const chaveFiltroEstado = chavesFiltro[posicaoArrayEstadoFiltro];
                if (filtro.EstadoFiltro !== undefined) {
                    let PArametroFiltroEstado = `&${chaveFiltroEstado}=`;
                    parametrosFiltro += PArametroFiltroEstado + filtro.EstadoFiltro;
                }
            }
            return await RepositorioEnderecos.obterTodosEnderecos(parametroFiltro);
        },
        criarEndereco: async function (parametros, modelo) {
            const nomeProrpriedadeValorNumericoPadrao = "/valorNumericoPadrao";
            const nomePropriedadeValorStringPadrao = "/valorStringPadrao";
            const valorNumericoPadrao = modelo.getProperty(nomeProrpriedadeValorNumericoPadrao);
            const valorStringPadrao = modelo.getProperty(nomePropriedadeValorStringPadrao);
            const parametrosEndereco = {
                id: valorNumericoPadrao,
                numero: parametros.numero != null && parametros.numero != valorNumericoPadrao ?
                    parseInt(parametros.numero) : -1,
                cep: parametros.cep != null ? parametros.cep : valorStringPadrao,
                municipio: parametros.municipio != null ? parametros.municipio : valorStringPadrao,
                bairro: parametros.bairro != null ? parametros.bairro : valorStringPadrao,
                rua: parametros.rua != null ? parametros.rua : valorStringPadrao,
                complemento: parametros.complemento != null ? parametros.complemento : valorStringPadrao,
                estado: parseInt(parametros.estado ?? valorNumericoPadrao)
            }
            return await RepositorioEnderecos.criarEndereco(parametrosEndereco);
        },
        deletarEndereco: async function (id) {
            RepositorioEnderecos.deletarEndereco(id);
        }
    }
});