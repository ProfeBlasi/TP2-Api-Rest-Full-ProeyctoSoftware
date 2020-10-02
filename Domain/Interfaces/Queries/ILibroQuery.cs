using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Queries
{
    public interface ILibroQuery
    {
        List<ResponseGetLibro> GetLibros();
    }
}
