using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UpcountrySchoolRegistry.Business.Contracts.DataAccess.Base
{
    /// <summary>
    /// Interface acima do Context para garantir que apenas o SaveChanges será exposto.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
