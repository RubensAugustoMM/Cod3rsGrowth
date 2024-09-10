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
                    parametrosFiltro += parametroFiltroNumero + valorNumero;
                }

                const posicaoArrayCepFiltro = 1;
                const chaveFiltroCep = chavesFiltro[posicaoArrayCepFiltro];
                if (filtro.CepFiltro !== undefined) {
                    const parametroFiltroCep = `&${chaveFiltroCep}=`;
                    let valorCep = filtro.CepFiltro;
                    parametrosFiltro += parametroFiltroCep + valorCep;
                }

                const posicaoArrayMunicipioFiltro = 2;
                const chaveFiltroMunicipio = chavesFiltro[posicaoArrayMunicipioFiltro];
                if (filtro.MunicipioFiltro !== undefined) {
                    const parametroFiltroMunicipio = `&${chaveFiltroMunicipio}=`;
                    let valorMunicipio = filtro.MunicipioFiltro;
                    parametrosFiltro += parametroFiltroMunicipio + valorMunicipio;
                }

                const posicaoArrayBairroFiltro = 3;
                const chaveFiltroBairro = chavesFiltro[posicaoArrayBairroFiltro];
                if (filtro.BairroFiltro !== undefined) {
                    const parametroFiltroBairro = `&${chaveFiltroBairro}=`;
                    let valorBairro = filtro.BairroFiltro;
                    parametrosFiltro += parametroFiltroBairro + valorBairro;
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
        obterEnderecoPorId: async function (id) {
            return await RepositorioEnderecos.obterEnderecoPorId(id);
        },
        editarEndereco: async function (parametros) {
            return await RepositorioEnderecos.editarEndereco(parametros);
        },
        criarEndereco: async function (parametros, modelo) {
            const valoresPadrao = modelo.getData();
            parametros.id = valoresPadrao.valorNumericoPadrao;
            parametros.numero =
                parametros.numero != null && parametros.numero !=
                    valoresPadrao.valorNumericoPadrao ? parseInt(parametros.numero) : -1;
            parametros.cep =
                String(parametros.cep ?? valoresPadrao.valorStringPadrao);
            parametros.municipio = parametros.municipio ?? valoresPadrao.valorStringPadrao;
            parametros.bairro = parametros.bairro ?? valoresPadrao.valorStringPadrao;
            parametros.rua = parametros.rua ?? valoresPadrao.valorStringPadrao;
            parametros.complemento = parametros.complemento ?? valoresPadrao.valorStringPadrao;
            parametros.estado = parseInt(parametros.estado ?? -1); 
            return await RepositorioEnderecos.criarEndereco(parametros);
        },
        deletarEndereco: async function (id) {
            RepositorioEnderecos.deletarEndereco(id);
        }
    }
});