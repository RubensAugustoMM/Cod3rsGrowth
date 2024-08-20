sap.ui.define([
], function (
) {
    return {
        obterTodasEscolas: function (oFiltro) {
            return new Promise((resolve, reject) => {
                let parametrosQuery = "";
                if (Object.keys(oFiltro).length !== 0) {
                    parametrosQuery += "?";

                    if (parseInt(oFiltro["StatusAtividadeFiltro"]) !== -1) {
                        var valorStatusAtividade = parseInt(oFiltro["StatusAtividadeFiltro"]);
                        parametrosQuery += "&StatusAtividadeFiltro=";

                        if (valorStatusAtividade === 1) {
                            parametrosQuery += "true";
                        }
                        else {
                            parametrosQuery += "false";
                        }
                    }
                    if (oFiltro["NomeFiltro"] !== undefined) {
                        parametrosQuery += "&NomeFiltro=" + oFiltro["NomeFiltro"];
                    }
                    if (oFiltro["CodigoMecFiltro"] !== undefined) {
                        parametrosQuery += "&CodigoMecFiltro=" + oFiltro["CodigoMecFiltro"];
                    }
                    if (parseInt(oFiltro["OrganizacaoAcademicaFiltro"]) !== -1) {
                        parametrosQuery += "&OrganizacaoAcademicaFiltro=" + oFiltro["OrganizacaoAcademicaFiltro"];
                    }
                    if (oFiltro["EstadoFiltro"] !== undefined) {
                        parametrosQuery += "&EstadoFiltro=" + oFiltro["EstadoFiltro"];
                    }
                }
                jQuery.get({
                    url: this._baseURL + '/Escolas' + parametrosQuery,
                    success: function (aEscolas) {
                        resolve(aEscolas);
                    },
                    error: function (oError) {
                        reject(oError);
                    }
                });
            });
        },

        obterEscolaPorId: function (sIdEscolas) { },
        deletarEscola: function (sIdEscolas) { },
        atualizarEscola: function (sIdEscolas) { },
        criarEscola: function (oData) { }
    }
});