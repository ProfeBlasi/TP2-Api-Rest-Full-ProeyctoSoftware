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

        public List<ResponseGetLibro> GetLibros()
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            var query = db.Query("Libros");
                //.Select("Libros.Titulo",
                //"Libros.Autor",
                //"Libros.Editorial",
                //"Libros.Edicion",
                //"Libros.Stock",
                //"Libros.Imagen");
            var result = query.Get<ResponseGetLibro>();
            return result.ToList();
        }
    }
}
