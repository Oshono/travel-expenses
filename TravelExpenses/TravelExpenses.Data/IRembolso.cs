﻿using System.Collections.Generic;
using TravelExpenses.Core;

namespace TravelExpenses.Data
{
    public interface IRembolso
    {
        int Guardar(Comprobante comprobante);
        IEnumerable<Archivo> ObtenerArchivos();
        bool Exists(string NombreArchivo, string Extension);
    }
}