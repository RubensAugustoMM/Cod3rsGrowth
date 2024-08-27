sap.ui.define([
], function (
) {
    return {
        obterTodasEscolas: async function (filtro) {
            let parametrosQuery = "";
            try {
                
                const chavesFiltro = Object.keys(filtro);
                if (Object.keys(filtro).length !== 0) {
                    parametrosQuery += "?";

                    const posicaoArrayStatusAtividadeFiltro = 2;
                    const chaveFiltroStatusAtividade = chavesFiltro[posicaoArrayStatusAtividadeFiltro];
                    const valoresHabilitadosIndefinido = -1;
                    if (parseInt(filtro[chaveFiltroStatusAtividade]) !== valoresHabilitadosIndefinido) {
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
                    const valoresOrganizacaoAcademicaIndefinido = -1;
                    if (parseInt(filtro[chaveFiltoOrganizacaoAcademica]) !== valoresOrganizacaoAcademicaIndefinido) {
                        let ParametroFiltroOrganizacaoAcademica = `&${chaveFiltoOrganizacaoAcademica}=`;
                        parametrosQuery += ParametroFiltroOrganizacaoAcademica + filtro[chaveFiltoOrganizacaoAcademica];
                    }

                    const posicaoArrayEstadoFiltro = 4;
                    const chaveFiltroEstado = chavesFiltro[posicaoArrayEstadoFiltro];
                    if (filtro[chaveFiltroEstado] !== undefined) {
                        let PArametroFiltroEstado = `&${chaveFiltroEstado}=`;
                        parametrosQuery += PArametroFiltroEstado + filtro[chaveFiltroEstado];
                    }
                }

                const resposta = await fetch(this._baseURL + '/Escolas' + parametrosQuery);
                if(!resposta.ok) throw new Error(resposta.status);
                return await resposta.json();
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao receber dados de Escolas:\n";
                console.error(mensagemDeErro + erro);
            }
        }
    }
});