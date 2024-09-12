sap.ui.define([
    "ui5/cod3rsgrowth/modelos/Repositorios/RepositorioEscolas"
], function (
    RepositorioEscolas
) {
    return {
        obterTodasEscolas: async function (filtro) {
            let parametrosFiltro = "";
            if (filtro != undefined && filtro != null) {
                parametrosFiltro += "?";
                const chavesFiltro = Object.keys(filtro);
                const posicaoArrayStatusAtividadeFiltro = 2;
                const chaveFiltroStatusAtividade = chavesFiltro[posicaoArrayStatusAtividadeFiltro];
                if (filtro.StatusAtividadeFiltro !== undefined) {
                    const parametroFiltroStatusAtividade = `&${chaveFiltroStatusAtividade}=`;
                    let valorStatusAtividade = parseInt(filtro.StatusAtividadeFiltro);
                    parametrosFiltro += parametroFiltroStatusAtividade;;
                    const valoresHabilitadosHabilitado = 1;
                    parametrosFiltro += valorStatusAtividade == valoresHabilitadosHabilitado;
                }

                const posicaoArrayNomeFiltro = 0;
                const chaveFiltroNome = chavesFiltro[posicaoArrayNomeFiltro];
                if (filtro.NomeFiltro !== undefined) {
                    let ParametroFiltroNome = `&${chaveFiltroNome}=`;
                    parametrosFiltro += ParametroFiltroNome + filtro.NomeFiltro;
                }

                const posicaoArrayCodigoMecFiltro = 1;
                const chaveFiltroCodigoMec = chavesFiltro[posicaoArrayCodigoMecFiltro];
                if (filtro.CodigoMec !== undefined) {
                    let ParametroFiltroCodigoMec = `&${chaveFiltroCodigoMec}=`;
                    parametrosFiltro += ParametroFiltroCodigoMec + filtro.CodigoMec;
                }

                const posicaoArrayOrganizacaoAcademicaFiltro = 3;
                const chaveFiltoOrganizacaoAcademica = chavesFiltro[posicaoArrayOrganizacaoAcademicaFiltro];
                if (filtro.OrganizacaoAcademicaFiltro !== undefined) {
                    let ParametroFiltroOrganizacaoAcademica = `&${chaveFiltoOrganizacaoAcademica}=`;
                    parametrosFiltro += ParametroFiltroOrganizacaoAcademica + filtro.OrganizacaoAcademicaFiltro;
                }

                const posicaoArrayEstadoFiltro = 4;
                const chaveFiltroEstado = chavesFiltro[posicaoArrayEstadoFiltro];
                if (filtro.EstadoFiltro !== undefined) {
                    let PArametroFiltroEstado = `&${chaveFiltroEstado}=`;
                    parametrosFiltro += PArametroFiltroEstado + filtro.EstadoFiltro;
                }
            }
            return await RepositorioEscolas.obterTodasEscolas(parametrosFiltro);
        },
        obterEscolaPorId: async function (id) {
            return await RepositorioEscolas.obterEscolaPorId(id);  
        },
        editarEscola: async function(parametros) {
            return await RepositorioEscolas.editarEscola(parametros);     
        },
        criarEscola: async function (parametros, modelo) {
            debugger;
            const valorHabilitado = 1;
            const valoresPadrao = modelo.getData();
            parametros.id = valoresPadrao.valorNumericoPadrao;
            parametros.statusAtividade =
                parseInt(parametros.statusAtividade ?? valoresPadrao.valorNumericoPadrao) == valorHabilitado;
            parametros.nome = parametros.nome ?? valoresPadrao.valorStringPadrao;
            parametros.codigoMec =
                String(parametros.codigoMec ?? valoresPadrao.valorStringPadrao);
            parametros.telefone =
                String(parametros.telefone ?? valoresPadrao.valorStringPadrao);
            parametros.email = parametros.email ?? valoresPadrao.valorStringPadrao;
            parametros.inicioAtividade = parametros.inicioAtividade ?? valoresPadrao.valorDataPadrao;
            parametros.categoriaAdministrativa =
                parseInt(parametros.categoriaAdministrativa ?? valoresPadrao.valorStringPadrao);
            parametros.organizacaoAcademica =
                parseInt(parametros.organizacaoAcademica ?? valoresPadrao);
            parametros.idEndereco = parametros.idEndereco ?? valoresPadrao.valorNumericoPadrao;

            return await RepositorioEscolas.criarEscola(parametros);
        },
        deletarEscola: async function (id) {
            return await RepositorioEscolas.deletarEscola(id);
        }
    }
});