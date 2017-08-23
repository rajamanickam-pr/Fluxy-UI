using Fluxy.Core.Common;
using System.Collections.Generic;

namespace Fluxy.Services.Common
{
    public interface IEntityService<T> : IService
      where T : BaseEntity
    {
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}
