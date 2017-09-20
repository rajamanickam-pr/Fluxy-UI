using Fluxy.Core.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fluxy.Services.Common
{
    public interface IEntityService<T> : IService
      where T : BaseEntity
    {
        T Create(T entity);
        T Delete(T entity);
        IEnumerable<T> GetAll();
        T Update(T entity);
        IEnumerable<T> GetList(Expression<Func<T, bool>> where);
        T GetSingle(Expression<Func<T, bool>> where);
        void ExecuteNonQuery(string query,SqlParameter[] param);

        //Async calls
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> CreateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> where);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> where);
    }
}
