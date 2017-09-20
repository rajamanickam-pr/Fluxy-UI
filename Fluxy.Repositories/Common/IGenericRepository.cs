using Fluxy.Core.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fluxy.Repositories.Common
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] properties);
        T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] properties);
        T Add(T entity);
        T Delete(T entity);
        T Edit(T entity);
        void ExecuteNonQuery(string query, SqlParameter[] param);
        void Save();

        //Async
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] properties);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] properties);
        Task<T> AddAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<T> EditAsync(T entity);
    }
}
