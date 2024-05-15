using System;
using Cod3rsGrowth.Dominio;


class Empresa
{
    public int idEmpresa { get; private set; }
    public int idade { get; private set; }
   public string RazaoSocial { get; private set; }
    public string NomeFantasia { get; private set; }
    public string Cnpj { get; private set; }
    public bool situcaoCadastral { get; private set; }
    public DateTime dataSituacaoCadastral { get; private set; }
    public DateTime dataAbertura { get; private set; }
    public decimal capitalSocial { get; private set; }
    public naturezaJuridica naturezaJuridica { get; private set; }
    public porte porte { get; private set; } 
    public matrizFilial matrizFilial { get; private set; }

}


 