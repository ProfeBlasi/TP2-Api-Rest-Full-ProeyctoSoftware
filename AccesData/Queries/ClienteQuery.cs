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
    public class ClienteQuery : BaseQuery<Cliente>, IClienteQuery
    {
        public ClienteQuery(IDbConnection connection, Compiler sqlKatacompiler) : base(connection, sqlKatacompiler)
        {

        }

        public List<ResponseGetCliente> GetCliente()
        {
            var db = new QueryFactory(connection, sqlKatacompiler);
            var query = db.Query("Cliente");
                //.Select(
                //"Cliente.DNI",
                //"Cliente.Nombre",
                //"Cliente.Apellido",
                //"Cliente.Email"
                //);
            var result = query.Get<ResponseGetCliente>();
            return result.ToList();
        }

    }
}
