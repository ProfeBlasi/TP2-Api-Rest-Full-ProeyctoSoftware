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
        private readonly IAlquileresQuery _queryAlquileres;
        private readonly ILibroQuery _queryLibro;
        public Validaciones()
        {

        }
        public Validaciones(IClienteQuery query1, IAlquileresQuery query2, ILibroQuery query3)
        {
            _queryCliente = query1;
            _queryAlquileres = query2;
            _queryLibro = query3;
        }

        public bool ExisteDni(string dni)
        {
            return _queryCliente.ExisteDni(dni);
        }
        public bool ExisteId(int id)
        {
            return _queryAlquileres.ExisteId(id);
        }
        public static bool SoloLetras(string array)
        {
            return Regex.IsMatch(array, @"^[a-zA-Z]+$");
        }

        public static bool SoloNumeros(string array)
        {
            return Regex.IsMatch(array, @"^[0-9]+$");
        }

        public bool ExisteISBN(string isbn)
        {
            return _queryAlquileres.ExisteISBN(isbn);
        }

        public bool ExisteReserva(int id, string isbn)
        {
            return _queryAlquileres.ExisteReserva(id, isbn);
        }
    }
}
