sap.ui.define([
], function(
) {
    return {
        obterTodasEmpresas: function (oFiltro) {
            return new Promise((resolve, reject) => {
                const sQueryParams = oFiltro ? '?' + "RazaoSocialFiltro=" + oFiltro.Razaosocial + jQuery.param(oFiltro) : '';
                jQuery.get({
                    url: this._baseURL + '/empresas' + sQueryParams,
                    success: function(aEmpresas) {
                        resolve(aEmpresas);
                    },
                    error: function(oError) {
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