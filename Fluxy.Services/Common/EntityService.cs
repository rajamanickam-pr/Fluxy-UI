using Fluxy.Core.Common;
using Fluxy.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;

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
    }
}
