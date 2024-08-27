sap.ui.define([
    "ui5/cod3rsgrowth/utilitarios/config"
], function (
	config) {
    "use strict";

    return {
        urlBase: config.getBaseURL(),
        async retornaModeloEstadoEnum() {
            try {
            const rotaEnum = "/EstadoEnum";
            const resposta = await fetch(this.urlBase + rotaEnum);
            if (!resposta.ok) throw new Error(resposta.status);
            return await resposta.json();
            }
            catch (erro) {
                const mensagemDeErro = "Erro ao receber modelo Estados:\n";
                console.error(mensagemDeErro + erro); 
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
                const mensagemDeErro = "Erro ao receber modelo Habilitado:\n";
                console.error(mensagemDeErro + erro); 
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
                const mensagemDeErro = "Erro ao receber modelo Natureza Juridica:\n";
                console.error(mensagemDeErro + erro); 
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
                const mensagemDeErro = "Erro ao receber modelo Organizacao Academica:\n";
                console.error(mensagemDeErro + erro); 
            }
        },
    }
});