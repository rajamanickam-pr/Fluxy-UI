using System;
using System.Threading.Tasks;

namespace Fluxy.Repositories.Common
{
    public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int Commit();
        Task<int> CommitAsync();
    }
}
