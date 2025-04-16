using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheelTrack.Core.Factories;
using WheelTrack.Core.Repositories;

namespace WheelTrack.DAL.Repositories
{
    public class DriverRepository: IDriverRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public DriverRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }


    }
}
