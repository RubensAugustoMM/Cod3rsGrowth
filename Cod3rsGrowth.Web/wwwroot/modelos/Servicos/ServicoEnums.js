sap.ui.define(["sap/m/MessageBox"
], function (
    MessageBox) {
    "use strict";

    return {
        _urlBase: "/api",
        async retornaModeloEstadoEnum() {
            const rotaEnum = "/EstadoEnum";
            const resposta = await fetch(this._urlBase + rotaEnum);
            if (!resposta.ok) throw new Error(resposta.status);
            return await resposta.json();
        },
        async retornaModeloHabilitadoEnum() {
            const rotaEnum = "/HabilitadoEnum";
            const resposta = await fetch(this._urlBase + rotaEnum);
            if (!resposta.ok) throw new Error(resposta.status);
            return await resposta.json();
        },
        async retornaModeloNaturezaJuridicaEnum() {
            const rotaEnum = "/NaturezaJuridicaEnum";
            const resposta = await fetch(this._urlBase + rotaEnum);
            if (!resposta.ok) throw new Error(resposta.status);
            return await resposta.json();
        },
        async retornaModeloOrganizacaoAcademicaEnum() {
            const rotaEnum = "/OrganizacaoAcademicaEnum";
            const resposta = await fetch(this._urlBase + rotaEnum);
            if (!resposta.ok) throw new Error(resposta.status);
            return await resposta.json();
        },
        async retornaModeloPorteEnum() {
            const rotaEnum = "/PorteEnum";
            const resposta = await fetch(this._urlBase + rotaEnum);
            if (!resposta.ok) throw new Error(resposta.status);
            return await resposta.json();
        },
        async retornaModeloMatrizFilialEnum() {
            const rotaEnum = "/MatrizFilialEnum";
            const resposta = await fetch(this._urlBase + rotaEnum);
            if (!resposta.ok) throw new Error(resposta.status);
            return await resposta.json();
        },
        async retornaModeloCategoriaAdministrativaEnum() {
            const rotaEnum = "/CategoriaAdministrativaEnum";
            const resposta = await fetch(this._urlBase + rotaEnum);
            if (!resposta.ok) throw new Error(resposta.status);
            return await resposta.json();
        }
    }
});