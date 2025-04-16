using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelTrack.Core.Factories
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void StartTransaction();
        void CommitTransaction();
        void RollbackTransaction();

    }
}
