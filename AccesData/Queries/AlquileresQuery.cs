using AccesData.Queries.Base;
using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces.Queries;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AccessData.Queries
{
    public class AlquileresQuery : BaseQuery<Alquileres>, IAlquileresQuery
    {
        public AlquileresQuery(IDbConnection connection, Compiler sqlKatacompiler) : base(connection, sqlKatacompiler)
        {

        }

        public bool ExisteISBN(string isbn)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            var query = db.Query("Libros")
                .Where("ISBN", "=", isbn)
                .Get<ResponseGetLibros>()
                .FirstOrDefault();
            return (query != null);
        }

        public bool ExisteId(int id)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            var query = db.Query("Cliente")
                .Where("ClienteId", "=", id)
                .Get<ResponseGetCliente>()
                .FirstOrDefault();
            return (query != null);
        }

        public bool ExisteStock(string isbn)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            var query = db.Query("Libros")
                .Where("ISBN", "=", isbn)
                .Where("Stock", ">", 0)
                .Get<ResponseGetLibros>()
                .FirstOrDefault();
            return (query != null);
        }

        public bool ExisteReserva(int id, string isbn)
        {
            return false;
        }
    }
}
