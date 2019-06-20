﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using TravelExpenses.Core;
using TravelExpenses.Data;

namespace TravelExpenses.Pages.Catalogs
{
    public class CiudadesModel : PageModel
    {
        private readonly IUbicacion Ubicacion;
        public IEnumerable<Ciudades> Ciudades { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public CiudadesModel(IUbicacion ubicacionData)
        {
            this.Ubicacion = ubicacionData;
        }
        public void OnGet()
        {
            Ciudades = Ubicacion.ObtenerCiudades(0);
        }
    }
}