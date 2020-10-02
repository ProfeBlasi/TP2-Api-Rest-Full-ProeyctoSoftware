using Aplication.Services.Base;
using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces.Queries;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        private readonly IClienteQuery _query;
        public ClienteService(IClienteRepository repository, IClienteQuery query) : base(repository)
        {
            _query = query;
        }
        public List<ResponseGetCliente> GetCliente()
        {
            return _query.GetCliente();
        }
    }
}
