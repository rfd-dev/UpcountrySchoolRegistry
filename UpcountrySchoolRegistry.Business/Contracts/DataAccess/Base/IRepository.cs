using System;
using System.Collections.Generic;
using System.Text;
using UpcountrySchoolRegistry.Business.Domain.Base;

namespace UpcountrySchoolRegistry.Business.Contracts.DataAccess.Base
{
    /// <summary>
    /// Interface em cima dos repositórios para garantir que o cliente do repositorio consegue persistir as operações.
    /// </summary>
    /// <typeparam name="T">
    public interface IRepository<T> where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
