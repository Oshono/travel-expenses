﻿using TravelExpenses.Core;
using Microsoft.EntityFrameworkCore;

namespace TravelExpenses.Data
{
    public class TravelExpensesContext: DbContext
    {
        public TravelExpensesContext(DbContextOptions<TravelExpensesContext> options)
            : base(options)
        {

        }

        public DbSet<Estado> Estados { get; set; }
        public DbSet<Empresas> CatEmpresas { get; set; }
        public DbSet<Departamentos> CatDepartamentos { get; set; }
        public DbSet<Gastos> CatGastos { get; set; }
        public DbSet<CentroCosto> CatCentroCostos { get; set; }
        public DbSet<CentroCostoEmpresa> CatCentroCosto_Empresa { get; set; }
        public DbSet<Moneda> CatMonedas { get; set; }
    }
}
