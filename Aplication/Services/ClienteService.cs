using Aplication.Services.Base;
using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces.Queries;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
        public List<ResponseGetCliente> GetCliente(string dni, string nombre, string apellido)
        {
            return _query.GetCliente(dni,nombre,apellido);
        }

        public ClienteDto RegistrarCliente(ResponseCreateCliente cliente)
        {
            ClienteDto imprimir = new ClienteDto();
            if (Validaciones.SoloLetras(cliente.Apellido.ToString()) &&
                Validaciones.SoloLetras(cliente.Nombre.ToString()) &&
                Validaciones.SoloNumeros(cliente.DNI) &&
                !_query.ExisteDni(cliente.DNI))
            {
                Cliente entity = new Cliente()
                {
                    DNI = cliente.DNI,
                    Apellido = cliente.Apellido,
                    Nombre = cliente.Nombre,
                    Email = cliente.Email
                };
                Add(entity);
                imprimir.Mensaje = "El cliente fue registrado con el exito";
                return imprimir;
            }
            else
            {
                imprimir.Mensaje = "Ocurrio un error, el dni ya estba registrado, o ingreso incorrectamente los datos, vuelva a intentarlo"; 
                return imprimir;
            }
        }
    }
}
