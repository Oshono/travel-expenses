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
    public class DestinoController : Controller
    {
        private readonly IUbicacion _ubicacion;

        public DestinoController(IUbicacion ubicacion)
        {
            _ubicacion = ubicacion;
        }

        // GET: Centro Costos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lista()
        {
            var ciudades = new List<Destino>();
            var paises = _ubicacion.ObtenerPaises();
            var ubicacionModel = new DestinoViewModel();
            ubicacionModel.Destinos = ciudades;
            ubicacionModel.Paises = paises;
            return View(ubicacionModel);
        }

        //[HttpPost]
        //public ActionResult CargaCiudades(string ClavePais)
        //{
        //    var ciudades = _ubicacion.ObtenerDestinos(0, ClavePais);            
        //    return Json(ciudades);
        //}

        [HttpPost]
        public ActionResult CargaCiudades(int IdEstado, string ClavePais)
        {
            var ciudades = _ubicacion.ObtenerCiudades(ClavePais, IdEstado);
            return Json(ciudades);
        }

        [HttpPost]
        public ActionResult CargaEstados(string ClavePais)
        {
            var estados = _ubicacion.ObtenerEstados(ClavePais);
            return Json(estados);
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
        public ActionResult Edit()
        {
            var destinoModel = new DestinoViewModel();
            destinoModel.Paises = _ubicacion.ObtenerPaises();
            destinoModel.Estados = _ubicacion.ObtenerEstados("");
            destinoModel.Ciudades = new List<Ciudades> ();
            return View(destinoModel);
        }

        // POST: Empresa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DestinoViewModel Destino)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var IdEstado = 0;
                if (Destino.Estado.Descripcion != "")
                {
                    var Estado = new Estado();
                    Estado.ClavePais = Destino.Pais.ClavePais;
                    Estado.Descripcion = Destino.Estado.Descripcion;
                    IdEstado = _ubicacion.GuardarEstado(Estado);
                }
                if (Destino.Ciudad.Descripcion != "")
                {
                    var Ciudad = new Ciudades();
                    Ciudad.Descripcion = Destino.Ciudad.Descripcion;
                    Ciudad.IdEstado = Destino.Estado.IdEstado;
                    _ubicacion.GuardarCiudad(Ciudad);
                }
            }
            catch
            {

            }

            return Redirect("/Destino/Lista");
        }

    }
}