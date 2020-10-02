using AccesData.Context;
using AccesData.Repositories.Base;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesData.Repositories
{
    public class ClienteRepository : GenericsRepository<Cliente>,IClienteRepository
    {
        public ClienteRepository(Contexto contexto) : base(contexto)
        {

        }
    }
}
