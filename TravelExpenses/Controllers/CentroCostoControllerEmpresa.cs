﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using TravelExpenses.Core;
using TravelExpenses.Data;
using TravelExpenses.ViewModels;

namespace TravelExpenses.Controllers
{
    public class CentroCostoEmpresaController : Controller
    {
        private readonly ICentroCostoEmpresa _centroEmpresa;

        public CentroCostoEmpresaController(ICentroCostoEmpresa centroEmpresa)
        {
            _centroEmpresa = centroEmpresa;
        }

        // GET: Centro Costos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lista()
        {
            var centros = _centroEmpresa.ObtenerCentroCostosEmpresa();
            var centroModel = new CentroCostoEmpresaViewModel();
            centroModel.CentroCostosEmpresas = centros;

            return View(centroModel);
        }


        // POST: gastos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: gastos/Edit/5
        public ActionResult Edit(string ClaveCentroCosto, string RFC)
        {
            var centroModel = new CentroCostoViewModel();
            centroModel.CentroCosto = new CentroCosto();
            if (!string.IsNullOrEmpty(ClaveCentroCosto))
            {
                var centro = _centro.ObtenerCentroCostos()
                            .Where(x => x.ClaveCentroCosto == ClaveCentroCosto)
                            .FirstOrDefault();
                centroModel.CentroCosto = centro;
            }
            return View(centroModel);
        }

        // POST: Empresa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CentroCostoViewModel centroCostoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }             
            try
            {
                _centro.Guardar(centroCostoModel.CentroCosto);
            }
            catch
            {

            }

            return Redirect("/CentroCosto/Lista");
        }

    }
}