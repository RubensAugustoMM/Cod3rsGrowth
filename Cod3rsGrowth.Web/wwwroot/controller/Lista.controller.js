sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "ui5/cod3rsgrowth/modelos/DataRepository",
	"sap/ui/model/Filter",
    "sap/ui/model/FilterOperator",
    "ui5/cod3rsgrowth/modelos/Formatador"
], (Controller,
    DataRepository,
    Filter,
    FilterOperator,
    Formatador) => {
    "use strict";

    return Controller.extend("ui5.cod3rsgrowth.controller.Lista", {

        formatador: Formatador,

        onInit() {
            const oRouter = this.getOwnerComponent().getRouter();

            oRouter.getRoute("Empresas").attachMatched(this._onRouteMatched, this);
            oRouter.getRoute("Escolas").attachMatched(this._onRouteMatched, this);
        },

        _onRouteMatched(oEvent) {
            var nomeRota = oEvent.getParameter("name");
            console.log("Rota ativada:", nomeRota);

            var i18n = this.getOwnerComponent().getModel("i18n").getResourceBundle();

            var titulo;

            switch (nomeRota) {
                case "Empresas":
                    titulo = i18n.getText("tituloEmpresas");
                    this.byId("lista").setTitle(titulo)
                    this._handleEmpresasRoute();
                    break;
                case "Escolas":
                    titulo = i18n.getText("tituloEscolas");
                    this.byId("lista").setTitle(titulo)
                    this._handleEscolasRoute();
                    break;
                default:
                    console.log("Rota não reconhecida.");
            }
        },

        _handleEmpresasRoute: function () {
            const DataRepository = this.getOwnerComponent().DataRepository;
            const oTable = this.byId("tabela");
            const oModel = this.getView().getModel();

            oTable.removeAllColumns();

            const aCampos = {
                nomeFantasia: "nome",
                cnpj: "CNPJ",
                situcaoCadastral: "Situação Cadastral",
                dataAbertura: "Data Abertura",
                naturezaJuridica: "Natureaza Juridica",
                capitalSocial: "Capital Social",
                estado: "Estado"
            };
            
            Object.entries(aCampos).forEach(([sCampo, sHeader]) => {
                oTable.addColumn(new sap.m.Column({
                    header: new sap.m.Label({ text: sHeader })
                }));
            });
            DataRepository.obterTodasEmpresas()
                .then(aEmpresas => {
                    oModel.setProperty("/items", aEmpresas);
                })
                .catch(oError => {
                    console.error("Erro ao obter convênios:", oError);
                });
        
            oTable.bindItems({
                path: "/items",
                template: new sap.m.ColumnListItem({
                    cells: Object.keys(aCampos).map(sCampo => new sap.m.Text({ text: "{" + sCampo + "}" }))
                })
            })
        },

        _handleEscolasRoute: function () {
            const DataRepository = this.getOwnerComponent().DataRepository;
            const oTable = this.byId("tabela");
            const oModel = this.getView().getModel();

            oTable.removeAllColumns();

            const aCampos = {
                nome: "Nome",
                codigoMec: "Código MEC",
                statusAtividade: "Status Atividade",
                organizacaoAcademica: "Organização Acadêmica",
                estado: "Estado",
            };

            Object.entries(aCampos).forEach(([sCampo, sHeader]) => {
                oTable.addColumn(new sap.m.Column({
                    header: new sap.m.Label({ text: sHeader })
                }));
            });
            DataRepository.obterTodasEscolas()
                .then(aEscolas => {
                    oModel.setProperty("/items", aEscolas);
                })
                .catch(oError => {
                    console.error("Erro ao obter convênios:", oError);
                });
        
            oTable.bindItems({
                path: "/items",
                template: new sap.m.ColumnListItem({
                    cells: Object.keys(aCampos).map(sCampo => new sap.m.Text({ text: "{" + sCampo + "}" }))
                })
            })
        },

        aoFiltrarTabela(oEvent)
        {
			const aFilter = [];
			const sQuery = oEvent.getParameter("query");
            const oRouter = this.getOwnerComponent().getRouter();

            const sRotaAtual = oRouter.getRouteInfoByHash(window.location.hash).name;
            var parametroFiltrar = "";

            if (sRotaAtual === "Empresas")
            {
                var parametroFiltrar = "nomeFantasia";
            }
            else
            {
                var parametroFiltrar = "nome";
            }

			if (sQuery) {
				aFilter.push(new Filter(parametroFiltrar, FilterOperator.Contains, sQuery));
			}

			const oList = this.byId("tabela");
			const oBinding = oList.getBinding("/items");
			oBinding.filter(aFilter);
		}
    });
});