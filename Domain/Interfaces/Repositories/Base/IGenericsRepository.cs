using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Repositories.Base
{
    public interface IGenericsRepository<E> where E : class
    {
        void Add(E entity);
        void Delete(E entity);
        void Delete(int id);
        void Edit(E entity);
        void EditRange(IEnumerable<E> entity);
        void Save();
        void AddRange(IEnumerable<E> entity);
        void DeleteRange(IEnumerable<E> entity);
        E FindById(int id);
    }
}
