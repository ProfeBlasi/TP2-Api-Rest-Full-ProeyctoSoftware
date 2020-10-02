using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Service
{
    public interface ILibroService : IBaseService<Libros>
    {
        List<ResponseGetLibro> GetLibros();
    }
}
