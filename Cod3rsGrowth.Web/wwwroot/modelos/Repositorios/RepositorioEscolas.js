sap.ui.define(["sap/m/MessageBox"
], function (
	MessageBox) {
    return {
        _urlBase: "api/Escolas",

        obterTodasEscolas: async function (parametroFiltro) {
            try {
                const resposta = await fetch(this._urlBase + parametroFiltro);
                if (!resposta.ok) throw new Error(resposta.status);
                return await resposta.json();
            }
            catch (erro) {
                throw erro;
            }
        },
        criarEscola: async function (parametros) {
            try {
                const urlAcao = "/Criar"
                const resposta = await fetch(this._urlBase + urlAcao, {
                    method: "POST",
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({
                        id: parametros.id,
                        statusAtividade: parametros.statusAtividade,
                        nome: parametros.nome,
                        codigoMec: parametros.codigoMec,
                        telefone: parametros.telefone,
                        email: parametros.email,
                        inicioAtividade: parametros.inicioAtividade,
                        categoriaAdministrativa: parametros.categoriaAdministrativa,
                        organizacaoAcademica: parametros.organizacaoAcademica,
                        idEndereco: parametros.idEndereco
                    })

                });
                return await resposta.json();
            }
            catch (erro) {
                console.log(erro);
                throw erro;
            }
        }
    }
});