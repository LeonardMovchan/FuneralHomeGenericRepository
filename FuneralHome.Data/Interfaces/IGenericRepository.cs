using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FuneralHome.Data.Interfaces
{

    public interface IGenericRepository<T, TId> where T : class
    {
        T Create(T model);
        T Update(T model);
        bool DeleteById(TId id);
        T GetById(TId id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
    }
}
