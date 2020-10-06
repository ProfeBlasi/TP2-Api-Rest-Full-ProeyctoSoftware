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
using System.Text.RegularExpressions;

namespace AccesData.Queries
{
    public class ClienteQuery : BaseQuery<Cliente>, IClienteQuery
    {
        public ClienteQuery(IDbConnection connection, Compiler sqlKatacompiler) : base(connection, sqlKatacompiler)
        {

        }

        public List<ResponseGetCliente> GetCliente(string dni, string nombre, string apellido)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            var query = db.Query("Cliente")
                 .When(!string.IsNullOrWhiteSpace(dni), x => x.WhereLike("DNI", $"%{dni}%"))
                 .When(!string.IsNullOrWhiteSpace(nombre), q => q.WhereLike("Nombre", $"%{nombre}%"))
                 .When(!string.IsNullOrWhiteSpace(apellido), s => s.WhereLike("Apellido", $"%{apellido}%"));
            var result = query.Get<ResponseGetCliente>();
            return result.ToList();
        }

        public bool ExisteDni(string dni)
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            var query = db.Query("Cliente")
                .Where("Dni", "=", dni)
                .Get<ResponseGetCliente>()
                .FirstOrDefault();
            return (query != null);
        }

    }
}
