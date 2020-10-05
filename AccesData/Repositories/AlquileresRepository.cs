using AccesData.Context;
using AccesData.Repositories.Base;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccessData.Repositories
{
    public class AlquileresRepository : GenericsRepository<Alquileres>, IAlquileresRepository
    {
        public AlquileresRepository(Contexto contexto) : base(contexto)
        {

        }
    }
}
