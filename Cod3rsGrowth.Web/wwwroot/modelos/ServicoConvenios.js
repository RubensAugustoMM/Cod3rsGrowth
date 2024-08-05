sap.ui.define([
], function(
) {
    return {
        obterTodosConvenios: function () {
            jQuery.get({
                url:this._baseURL + '/convenios',
            success : function(aConvenios)
            {
                var oModel = this.getDataModel();
                oModel.setProperty("/convenios", aConvenios);
            }.bind(this)
            })
        },
        obterPorIdConvenio: function (sIdUsuario) { },
        deletarConvenio: function (sIdUsuario) { },
        atualizarConvenio: function (sIdUsuario) { },
        criarConvenio: function (oData) { }
    }
});