sap.ui.define([
    "sap/ui/test/Opa5",
    "./arrangements/Startup",
    "./JornadaApp",
    "./JornadaListaEmpresas",
    "./JornadaListaEscolas",
    "./JornadaEmpresaCriar",
    "./JornadaEscolaCriar",
    "./JornadaEscolaEditar",
    "./JornadaEmpresaEditar"
], function (Opa5,
    Startup,
    JornadaApp,
    JornadaListaEmpresas,
    JornadaListaEscolas,
    JornadaEmpresaCriar,
    JornadaEscolaCriar,
    JornadaEscolaEditar,
    JornadaEmpresaEditar
) {
    "use strict";

    Opa5.extendConfig({
        arrangements: new Startup(),
        viewNamespace: "ui5.cod3rsgrowth.view",
        autoWait: true
    });
});