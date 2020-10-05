using Domain.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Queries
{
    public interface IClienteQuery
    {
        List<ResponseGetCliente> GetCliente(string dni, string nombre, string apellido);
        bool ExisteDni(string dni);
    }
}
