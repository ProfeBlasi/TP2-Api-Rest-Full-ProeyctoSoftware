using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Queries
{
    public interface IAlquileresQuery
    {
        bool ExisteISBN(string isbn);
        bool ExisteStock(string isbn);
        bool ExisteId(int id);
        bool ExisteReserva(int id, string isbn);
    }
}
