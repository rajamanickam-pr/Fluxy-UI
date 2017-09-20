using Fluxy.Core.Common;
using Fluxy.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fluxy.Services.Common
{
    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        IUnitOfWork _unitOfWork;
        IGenericRepository<T> _repository;

        public EntityService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public virtual T Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var value = _repository.Add(entity);
            _unitOfWork.Commit();
            return value;
        }

        public virtual T Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            var value = _repository.Edit(entity);
            _unitOfWork.Commit();
            return value;
        }

        public virtual T Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            var value = _repository.Delete(entity);
            _unitOfWork.Commit();
            return value;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual IEnumerable<T> GetList(Expression<Func<T, bool>> where)
        {
            return _repository.GetList(where);
        }

        public virtual T GetSingle(Expression<Func<T, bool>> where)
        {
            return _repository.GetSingle(where);
        }

        public virtual void ExecuteNonQuery(string query, SqlParameter[] param)
        {
             _repository.ExecuteNonQuery(query, param);
        }

        #region Async calls

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var value = await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return value;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            var value = await _repository.DeleteAsync(entity);
            await _unitOfWork.CommitAsync();
            return value;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            var value =await _repository.EditAsync(entity);
            await _unitOfWork.CommitAsync();
            return value;
        }

        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> where)
        {
            return await _repository.GetListAsync(where);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> where)
        {
            return await _repository.GetSingleAsync(where);
        }
        #endregion
    }
}
