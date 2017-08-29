using Fluxy.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Fluxy.Repositories.Common
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] properties);
        IEnumerable<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] properties);
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] properties);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
