using Fluxy.Core.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Fluxy.Repositories.Common
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
       where T : BaseEntity
    {
        protected DbContext _entities;
        protected readonly IDbSet<T> _dbset;

        public GenericRepository(DbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll(params Expression<Func<T, object>>[] properties)
        {
            List<T> list = new List<T>();

            IQueryable<T> dbQuery = _entities.Set<T>();

            foreach (Expression<Func<T, object>> property in properties)
                dbQuery = dbQuery.Include<T, object>(property);

            list = dbQuery.AsNoTracking()
                            .ToList<T>();

            return list;
        }

        public virtual IEnumerable<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] properties)
        {
            List<T> list = new List<T>();

            IQueryable<T> dbQuery = _entities.Set<T>();

            foreach (Expression<Func<T, object>> property in properties)
                dbQuery = dbQuery.Include<T, object>(property);

            list = dbQuery.AsNoTracking()
                            .Where(where)
                            .ToList<T>();

            return list;
        }

        public T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] properties)
        {
            T item = null;
            IQueryable<T> dbQuery = _entities.Set<T>();

            foreach (Expression<Func<T, object>> property in properties)
                dbQuery = dbQuery.Include<T, object>(property);

            item = dbQuery.AsNoTracking()
                            .FirstOrDefault(where);
            return item;
        }

        public virtual T Add(T entity)
        {
            return _dbset.Add(entity);
        }

        public virtual T Delete(T entity)
        {
            _entities.Entry(entity).State = EntityState.Deleted;
            _entities.SaveChanges();
            return entity;
        }

        public virtual T Edit(T entity)
        {
            _entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity;
        }

        public virtual void ExecuteNonQuery(string query, SqlParameter[] param)
        {
             _entities.Database.ExecuteSqlCommand(sql: query, parameters: param);
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}
