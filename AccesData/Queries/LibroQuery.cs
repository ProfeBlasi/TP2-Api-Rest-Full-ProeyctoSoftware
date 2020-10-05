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

namespace AccesData.Queries
{
    public class LibroQuery : BaseQuery<Libros>, ILibroQuery
    {
        public LibroQuery(IDbConnection connection, Compiler sqlKatacompiler) : base(connection, sqlKatacompiler)
        {

        }

        public List<ResponseGetLibros> GetLibros(bool stock, string autor, string titulo)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            var query = db.Query("Libros")
                .When(!stock, q => q.Where("Stock", "=", 0))
                .When(!string.IsNullOrWhiteSpace(autor), r => r.WhereLike("autor", $"%{autor}%"))
                .When(!string.IsNullOrWhiteSpace(titulo), s => s.WhereLike("titulo", $"%{titulo}%"));
            var result = query.Get<ResponseGetLibros>();
            return result.ToList();
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

        public bool ExisteISBN(string isbn)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            var query = db.Query("Libros")
                .Where("ISBN", "=", isbn)
                .Get<ResponseGetLibros>()
                .FirstOrDefault();
            return (query != null);
        }
    }
}
