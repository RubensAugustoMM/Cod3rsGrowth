sap.ui.define([
], function (
) {
    return {
        obterTodasEmpresas: function (oFiltro) {
            return new Promise((resolve, reject) => {
                let parametrosQuery = "";
                if (Object.keys(oFiltro).length !== 0) {
                    parametrosQuery += '?';

                    if (oFiltro["RazaoSocialFiltro"] !== undefined) {
                        parametrosQuery += "&RazaoSocialFiltro=" + oFiltro["RazaoSocialFiltro"];
                    }

                    if (oFiltro["CnpjFiltro"] !== undefined) {
                        parametrosQuery += "&CnpjFiltro=" + oFiltro["CnpjFiltro"];
                    }

                    if (parseInt(oFiltro["SituacaoCadastralFiltro"]) !== -1) {
                        parametrosQuery += "&SituacaoCadastralFiltro=";
                        var valorSituacaoCadastralFiltro = parseInt(oFiltro["SituacaoCadastralFiltro"]);

                        if (valorSituacaoCadastralFiltro === 1) {
                            parametrosQuery += "true";
                        }
                        else {
                            parametrosQuery += "false";
                        }
                    }

                    if (oFiltro["DataAberturaFiltro"] !== undefined) {
                        parametrosQuery += "&DataAberturaFiltro=" + oFiltro["DataAberturaFiltro"];
                    }

                    if (oFiltro["CapitalSocialFiltro"] !== undefined) {
                        parametrosQuery += "&CapitalSocialFiltro=" + oFiltro["CapitalSocialFiltro"];
                    }

                    if (parseInt(oFiltro["NaturezaJuridicaFiltro"]) !== -1) {
                        parametrosQuery += "&NaturezaJuridicaFiltro=" + oFiltro["NaturezaJuridicaFiltro"];
                    }

                    if (oFiltro["EstadoFiltro"] !== undefined) {
                        parametrosQuery += "&EstadoFiltro=" + oFiltro["EstadoFiltro"];
                    }
                }
                jQuery.get({
                    url: this._baseURL + '/Empresas' + parametrosQuery,
                    success: function (aEmpresas) {
                        resolve(aEmpresas);
                    },
                    error: function (oError) {
                        reject(oError);
                    }
                });
            });
        },
        obterEmpresaPorId: function (sIdEmpresas) { },
        deletarEmpresa: function (sIdEmpresas) { },
        atualizarEmpresa: function (sIdEmpresas) { },
        criarEmpresa: function (oData) { }
    }
});