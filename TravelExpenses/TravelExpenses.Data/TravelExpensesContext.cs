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
        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<Destinos> Destinos { get; set; }
    }
}
