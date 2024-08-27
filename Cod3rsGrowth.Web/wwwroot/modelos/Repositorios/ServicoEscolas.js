sap.ui.define([
	"ui5/cod3rsgrowth/modelos/Repositorios/RepositorioEscolas"
], function (
    RepositorioEscolas
) {
    return {
        obterTodasEscolas: async function (filtro) {
            let parametrosQuery = "";
            try {
                const chavesFiltro = Object.keys(filtro);
                parametrosQuery += "?";
                const posicaoArrayStatusAtividadeFiltro = 2;
                const chaveFiltroStatusAtividade = chavesFiltro[posicaoArrayStatusAtividadeFiltro];
                if (filtro[chaveFiltroStatusAtividade] !== undefined) {
                    const sParametroFiltroStatusAtividade = `&${chaveFiltroStatusAtividade}=`;
                    let valorStatusAtividade = parseInt(filtro[chaveFiltroStatusAtividade]);
                    parametrosQuery += sParametroFiltroStatusAtividade;;
                    const valoresHabilitadosHabilitado = 1;
                    parametrosQuery += valorStatusAtividade == valoresHabilitadosHabilitado;
                }

                const posicaoArrayNomeFiltro = 0;
                const chaveFiltroNome = chavesFiltro[posicaoArrayNomeFiltro];
                if (filtro[chaveFiltroNome] !== undefined) {
                    let ParametroFiltroNome = `&${chaveFiltroNome}=`;
                    parametrosQuery += ParametroFiltroNome + filtro[chaveFiltroNome];
                }

                const posicaoArrayCodigoMecFiltro = 1;
                const chaveFiltroCodigoMec = chavesFiltro[posicaoArrayCodigoMecFiltro];
                if (filtro[chaveFiltroCodigoMec] !== undefined) {
                    let ParametroFiltroCodigoMec = `&${chaveFiltroCodigoMec}=`;
                    parametrosQuery += ParametroFiltroCodigoMec + filtro[chaveFiltroCodigoMec];
                }

                const posicaoArrayOrganizacaoAcademicaFiltro = 3;
                const chaveFiltoOrganizacaoAcademica = chavesFiltro[posicaoArrayOrganizacaoAcademicaFiltro];
                if (filtro[chaveFiltoOrganizacaoAcademica] !== undefined) {
                    let ParametroFiltroOrganizacaoAcademica = `&${chaveFiltoOrganizacaoAcademica}=`;
                    parametrosQuery += ParametroFiltroOrganizacaoAcademica + filtro[chaveFiltoOrganizacaoAcademica];
                }

                const posicaoArrayEstadoFiltro = 4;
                const chaveFiltroEstado = chavesFiltro[posicaoArrayEstadoFiltro];
                if (filtro[chaveFiltroEstado] !== undefined) {
                    let PArametroFiltroEstado = `&${chaveFiltroEstado}=`;
                    parametrosQuery += PArametroFiltroEstado + filtro[chaveFiltroEstado];
                }

                return await RepositorioEscolas.obterTodasEscolas(parametrosQuery);
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao receber dados de Escolas:\n";
                console.error(mensagemDeErro + erro);
            }
        }
    }
});