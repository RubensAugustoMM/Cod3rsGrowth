﻿using Cod3rsGrowth.Dominio.Modelos;
using LinqToDB;
using LinqToDB.Data;

namespace Cod3rsGrowth.Infra
{
    public class ContextoAplicacao : DataConnection
    {
        public ContextoAplicacao(DataOptions<ContextoAplicacao> opcoes) : base(opcoes.Options) { }

        public ITable<Convenio> TabelaConvenios => this.GetTable<Convenio>();
        public ITable<Empresa> TabelaEmpresas => this.GetTable<Empresa>();
        public ITable<Endereco> TabelaEnderecos => this.GetTable<Endereco>();
        public ITable<Escola> TabelaEscolas => this.GetTable<Escola>();
    }
}