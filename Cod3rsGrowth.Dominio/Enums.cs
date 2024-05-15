using System;
using System.ComponentModel;

namespace Cod3rsGrowth.Dominio
{
    enum NaturezaJuridica 
    {
        [Description("Microempreendedor Individual")]
        MicroempreendedorIndividual,
        [Description("Empresario Individual")]
         EmpresarioIndividual,
        [Description("Sociedade Empresaria Limitada")]
          SociedadeEmpresariaLimitada,
        [Description("Sociedade Empresaria Unipessoal Limitada")]
        SociedadeEmpresariaUnipessoalLimitada,
        [Description("Sociedade Simples Pura")]
         SociedadeSimplesPura,
        [Description("Sociedade Simples Limitada")]
          SociedadeSimplesLimitada,
        [Description("Sociedade Anonima Aberta")]
        SociedadeAnonimaAberta,
        [Description("Sociedade")]
         SociedadeAnonimaFechada
    }

    public enum porte 
    {
        [Description("Microempreendedor Individual")]
         MicroeempreendedorIndividual,
        [Description("Micro Empresa")] 
         Microempresa, 
        [Description("Empresa de Pequeno Porte")]
         EmpresaPequenoPorte,
        [Description("Media Empresa")] 
         MediaEmpresa, 
        [Description("Grande Empresa")]
         GrandeEmpresa 
         }

        public enum categoriaAdministrativa 
        { 
        [Description("Adiministração Municipal")]
            Municipal, 
        [Description("Adiministração Federal")] 
            Federal, 
        [Description("Adiministração Estadual")] 
            Estadual
        } 
   
        public enum organizacaoAcademica 
        { 
        [Description("Faculdade")] 
            Faculdade, 
        [Description("Centro Universitario")]  
            CentroUniversitario, 
        [Description("Instituto Federal")]  
            InstitutoFederal,  
        [Description("Universidade")] 
            Universidade,
        [Description("Escola do Governo")]
        EscolaGoverno
    }

    public enum matrizFilial
    {
        [Description("Matriz")]
        Matriz,
        [Description("Filial")]
        Filial

    }


}