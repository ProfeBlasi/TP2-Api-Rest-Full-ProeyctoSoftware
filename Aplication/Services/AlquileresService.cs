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
    public class AlquileresService : BaseService<Alquileres>, IAlquileresService
    {
        private readonly IAlquileresQuery _query;
        public AlquileresService(IAlquileresRepository repository,IAlquileresQuery query) : base (repository)
        {
            query = _query;
        }

        public ClienteDto RegistrarProceso(ResponseCreateAlquileres alquileres)
        {
            ClienteDto imprimir = new ClienteDto();
            Validaciones val = new Validaciones();
            {
                if (val.ExisteReserva(alquileres.Cliente, alquileres.ISBN))
                {
                    Alquileres entity = new Alquileres()
                    {
                        Cliente = alquileres.Cliente,
                        ISBN = alquileres.ISBN,
                        Estado = alquileres.Estado
                    };
                    switch (alquileres.Estado)
                    {
                        case 1:
                            entity.FechaAlquiler = DateTime.Today;
                            entity.FechaReserva = null;
                            entity.FechaDevolucion = DateTime.Today.AddDays(7);
                            break;
                        case 2:
                            entity.FechaAlquiler = null;
                            entity.FechaReserva = DateTime.Today;
                            entity.FechaDevolucion = null;
                            break;
                        case 3:
                            entity.FechaAlquiler = null;
                            entity.FechaReserva = null;
                            entity.FechaDevolucion = null;
                            break;
                        default:
                            break;
                    }
                    Add(entity);
                    return imprimir;
                }
                else
                {
                    imprimir.Mensaje = "Ocurrio un error";
                    return imprimir;
                }
            }
        }
    }
}
