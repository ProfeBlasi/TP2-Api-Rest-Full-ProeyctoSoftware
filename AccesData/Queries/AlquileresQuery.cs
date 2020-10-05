using AccesData.Queries.Base;
using Domain.Entities;
using Domain.Interfaces.Queries;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AccessData.Queries
{
    public class AlquileresQuery : BaseQuery<Alquileres>, IAlquileresQuery
    {
        public AlquileresQuery(IDbConnection connection, Compiler sqlKatacompiler) : base(connection, sqlKatacompiler)
        {

        }
    }
}
