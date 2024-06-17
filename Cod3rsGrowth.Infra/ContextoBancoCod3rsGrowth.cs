using System;
using Cod3rsGrowth.Dominio.Modelos;
using LinqToDB;
using LinqToDB.Data;

namespace Cod3rsGrowth.Infra
{
    public class ContextoBancoCod3rsGrowth : DataConnection
    {
        public ContextoBancoCod3rsGrowth() : base("DESKTOP-DAA9S87\SQLEXPRESS")
        {
       
        }

        public ITable<Convenio> TabelaConvenios => this.GetTable<Convenio>();
        public ITable<Empresa> TabelaEmpresas => this.GetTable<Empresa>();
        public ITable<Endereco> TabelaEnderecos => this.GetTable<Endereco>();
        public ITable<Escola> TabelaEscolas => this.GetTable<Escola>();
        public ITable<Estado> TabelaEstado => this.GetTable<Estado>();
    }
}
