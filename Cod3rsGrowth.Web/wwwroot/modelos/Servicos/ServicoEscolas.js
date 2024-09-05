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
        criarEscola: async function (parametros, modelo) {
            const valorHabilitado = 1;
            const nomeProrpriedadeValorNumericoPadrao = "/valorNumericoPadrao";
            const nomePropriedadeValorStringPadrao = "/valorStringPadrao";
            const nomePropriedadeValorDataPadrao = "/valorDataPadrao";
            const valorNumericoPadrao = modelo.getProperty(nomeProrpriedadeValorNumericoPadrao);
            const valorStringPadrao = modelo.getProperty(nomePropriedadeValorStringPadrao);
            const valorDataPadrao = modelo.getProperty(nomePropriedadeValorDataPadrao);
            const parametrosEscola = {
                id: valorNumericoPadrao,
                statusAtividade: parseInt(parametros.statusAtividade ?? valorNumericoPadrao),
                nome: parametros.nome ?? valorStringPadrao,
                codigoMec: parametros.codigoMec ?? valorStringPadrao,
                telefone: parametros.codigoMec ?? valorStringPadrao,
                email: parametros.email ?? valorStringPadrao,
                inicioAtividade: parametros.inicioAtividade ?? valorDataPadrao,
                categoriaAdministrativa: parseInt(parametros.categoriaAdministrativa ?? valorNumericoPadrao),
                organizacaoAcademica: parseInt(parametros.organizacaoAcademica ?? valorNumericoPadrao),
                idEndereco: parametros.idEndereco ?? valorNumericoPadrao
            };
            parametrosEscola.statusAtividade =
                valorHabilitado == parseInt(parametros.situacaoCadastral);
            return await RepositorioEscolas.criarEscola(parametrosEscola);
        }
    }
});