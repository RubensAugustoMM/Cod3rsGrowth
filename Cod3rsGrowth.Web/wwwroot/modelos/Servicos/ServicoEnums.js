sap.ui.define(["sap/m/MessageBox"
], function (
    MessageBox) {
    "use strict";

    return {
        urlBase: "/api",
        async retornaModeloEstadoEnum() {
            try {
                const rotaEnum = "/EstadoEnum";
                const resposta = await fetch(this.urlBase + rotaEnum);
                if (!resposta.ok) throw new Error(resposta.status);
                return await resposta.json();
            }
            catch (erro) {
                throw erro;
            }
        },
        async retornaModeloHabilitadoEnum() {
            try {
                const rotaEnum = "/HabilitadoEnum";
                const resposta = await fetch(this.urlBase + rotaEnum);
                if (!resposta.ok) throw new Error(resposta.status);
                return await resposta.json();
            }
            catch (erro) {
                throw erro;
            }
        },
        async retornaModeloNaturezaJuridicaEnum() {
            try {
                const rotaEnum = "/NaturezaJuridicaEnum";
                const resposta = await fetch(this.urlBase + rotaEnum);
                if (!resposta.ok) throw new Error(resposta.status);
                return await resposta.json();
            }
            catch (erro) {
                throw erro;
            }
        },
        async retornaModeloOrganizacaoAcademicaEnum() {
            try {
                const rotaEnum = "/OrganizacaoAcademicaEnum";
                const resposta = await fetch(this.urlBase + rotaEnum);
                if (!resposta.ok) throw new Error(resposta.status);
                return await resposta.json();
            }
            catch (erro) {
                throw erro;

            }
        },
        async retornaModeloPorteEnum() {
            try {
                const rotaEnum = "/PorteEnum";
                const resposta = await fetch(this.urlBase + rotaEnum);
                if (!resposta.ok) throw new Error(resposta.status);
                return await resposta.json();
            }
            catch (erro) {
                throw erro;
            }
        },
        async retornaModeloMatrizFilialEnum() {
            try {
                const rotaEnum = "/MatrizFilialEnum";
                const resposta = await fetch(this.urlBase + rotaEnum);
                if (!resposta.ok) throw new Error(resposta.status);
                return await resposta.json();
            }
            catch (erro) {
                throw erro;
            }
        }
    }
});