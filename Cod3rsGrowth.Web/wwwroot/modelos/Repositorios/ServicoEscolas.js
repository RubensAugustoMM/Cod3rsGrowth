sap.ui.define([
], function (
) {
    return {
        obterTodasEscolas: async function (oFiltro) {
            let parametrosQuery = "";
            try {
                
                const aChavesFiltro = Object.keys(oFiltro);
                if (Object.keys(oFiltro).length !== 0) {
                    parametrosQuery += "?";

                    const posicaoArrayStatusAtividadeFiltro = 2;
                    const chaveFiltroStatusAtividade = aChavesFiltro[posicaoArrayStatusAtividadeFiltro];
                    const valoresHabilitadosIndefinido = -1;
                    if (parseInt(oFiltro[chaveFiltroNome]) !== valoresHabilitadosIndefinido) {
                        const sParametroFiltroStatusAtividade = `&${chaveFiltroNome}=`;
                        let valorStatusAtividade = parseInt(oFiltro[chaveFiltroNome]);
                        parametrosQuery += sParametroFiltroStatusAtividade;;
                    const valoresHabilitadosHabilitado = 1;
                        parametrosQuery += valorStatusAtividade == valoresHabilitadosHabilitado; 
                    }

                    const posicaoArrayNomeFiltro = 0;
                    const chaveFiltroNome = aChavesFiltro[posicaoArrayNomeFiltro];
                    if (oFiltro[chaveFiltroNome] !== undefined) {
                        let sParametroFiltroNome = `&${chaveFiltroNome}=`;
                        parametrosQuery += sParametroFiltroNome + oFiltro[chaveFiltroNome];
                    }

                    const posicaoArrayCodigoMecFiltro = 1;
                    const chaveFiltroCodigoMec = aChavesFiltro[posicaoArrayCodigoMecFiltro];
                    if (oFiltro[chaveFiltroCodigoMec] !== undefined) {
                        let sParametroFiltroCodigoMec = `&${chaveFiltroCodigoMec}=`;
                        parametrosQuery += sParametroFiltroCodigoMec + oFiltro[chaveFiltroCodigoMec];
                    }

                    const posicaoArrayOrganizacaoAcademicaFiltro = 3;
                    const chaveFiltoOrganizacaoAcademica = aChavesFiltro[posicaoArrayOrganizacaoAcademicaFiltro];
                    const valoresOrganizacaoAcademicaIndefinido = -1;
                    if (parseInt(oFiltro[chaveFiltoOrganizacaoAcademica]) !== valoresOrganizacaoAcademicaIndefinido) {
                        let sParametroFiltroOrganizacaoAcademica = `&${chaveFiltoOrganizacaoAcademica}=`;
                        parametrosQuery += sParametroFiltroOrganizacaoAcademica + oFiltro[chaveFiltoOrganizacaoAcademica];
                    }

                    const posicaoArrayEstadoFiltro = 4;
                    const chaveFiltroEstado = aChavesFiltro[posicaoArrayEstadoFiltro];
                    if (oFiltro[chaveFiltroEstado] !== undefined) {
                        let sPArametroFiltroEstado = `&${chaveFiltroEstado}=`;
                        parametrosQuery += sPArametroFiltroEstado + oFiltro[chaveFiltroEstado];
                    }
                }

                const resposta = await this._baseURL + '/Escolas' + parametrosQuery;
                    if(!resposta.ok) throw new Error(reposta.status);
                    return await reposta.json();
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao receber dados de Escolas:\n";
                console.error(mensagemDeErro + erro);
            }
        },

        obterEscolaPorId: function (sIdEscolas) { },
        deletarEscola: function (sIdEscolas) { },
        atualizarEscola: function (sIdEscolas) { },
        criarEscola: function (oData) { }
    }
});