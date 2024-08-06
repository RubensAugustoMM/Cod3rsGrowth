sap.ui.define([
], function(
) {
    return {
        obterTodasEmpresas: function () {
            return new Promise((resolve, reject) => {
                jQuery.get({
                    url: this._baseURL + '/empresas',
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