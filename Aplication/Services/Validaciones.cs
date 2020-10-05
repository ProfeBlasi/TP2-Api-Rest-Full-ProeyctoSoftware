using Domain.Interfaces.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Aplication.Services
{
    public class Validaciones
    {
        private readonly IClienteQuery _queryCliente;
        public Validaciones(IClienteQuery query)
        {
            _queryCliente = query;
        }

        public bool ExisteDni(string dni)
        {
            return _queryCliente.ExisteDni(dni);
        }
        public static bool SoloLetras(string array)
        {
            return Regex.IsMatch(array, @"^[a-zA-Z]+$");
        }

        public static bool SoloNumeros(string array)
        {
            return Regex.IsMatch(array, @"^[0-9]+$");
        }

    }
}
