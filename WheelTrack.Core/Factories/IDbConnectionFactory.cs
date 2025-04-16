using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelTrack.Core.Factories
{
    public interface IDbConnectionFactory
    {
        IUnitOfWork MariaDBInstance();
    }
}
