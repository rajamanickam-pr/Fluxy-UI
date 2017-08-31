using Fluxy.Core.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace Fluxy.Repositories.Common
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] properties);
        IEnumerable<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] properties);
        T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] properties);
        T Add(T entity);
        T Delete(T entity);
        T Edit(T entity);
        void ExecuteNonQuery(string query, SqlParameter[] param);
        void Save();
    }
}
