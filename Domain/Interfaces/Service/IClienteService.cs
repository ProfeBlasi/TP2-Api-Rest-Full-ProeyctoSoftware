using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces.Service.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Domain.Interfaces.Service
{
    public interface IClienteService : IBaseService<Cliente>
    {
        List<ResponseGetCliente> GetCliente(string dni, string nombre, string apellido);
        ClienteDto RegistrarCliente(ResponseCreateCliente cliente);
    }
}
