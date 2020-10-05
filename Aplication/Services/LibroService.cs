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
    public class LibroService : BaseService<Libros>, ILibroService
    {
        private readonly ILibroQuery _query;
        public LibroService(ILibroRepository repository,ILibroQuery query) : base(repository)
        {
            _query = query;
        }

        public List<ResponseGetLibros> GetLibros(bool stock, string autor, string titulo)
        {
            return _query.GetLibros(stock, autor, titulo);
        }
    }
}
