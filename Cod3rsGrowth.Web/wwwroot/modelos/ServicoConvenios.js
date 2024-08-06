sap.ui.define([
], function(
) {
    return {
        obterTodosConvenios: function () {
            return new Promise((resolve, reject) => {
                jQuery.get({
                    url: this._baseURL + '/convenios',
                    success: function(aConvenios) {
                        resolve(aConvenios);
                    },
                    error: function(oError) {
                        reject(oError);
                    }
                });
            });
        },
        obterConvenioPorId: function (sIdConvenios) { },
        deletarConvenio: function (sIdConvenios) { },
        atualizarConvenio: function (sIdConvenios) { },
        criarConvenio: function (oData) { }
    }
});