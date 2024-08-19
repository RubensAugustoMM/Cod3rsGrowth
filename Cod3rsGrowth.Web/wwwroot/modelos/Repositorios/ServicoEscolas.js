sap.ui.define([
], function (
) {
    return {
        obterTodasEscolas: function () {
            return new Promise((resolve, reject) => {
                jQuery.get({
                    url: this._baseURL + '/escolas',
                    success: function (aEscolas) {
                        resolve(aEscolas); 
                    },
                    error: function (oError) {
                        reject(oError); 
                    }
                });
            });
        },

        obterConvenioPorId: function (sIdEscolas) { },
        deletarConvenio: function (sIdEscolas) { },
        atualizarConvenio: function (sIdEscolas) { },
        criarConvenio: function (oData) { }
    }
});