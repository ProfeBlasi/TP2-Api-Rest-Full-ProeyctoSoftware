using AccesData.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesData.Repositories.Base
{
    public class LibroRepository : GenericsRepository<Libros>, ILibroRepository 
    {
        public LibroRepository(Contexto contexto) : base(contexto)
        {

        }
    }
}
