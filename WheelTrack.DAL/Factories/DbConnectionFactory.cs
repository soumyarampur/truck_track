using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheelTrack.Core.Factories;

namespace WheelTrack.DAL.Factories
{
    public class DbConnectionFactory: IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IUnitOfWork MariaDBInstance()
        {
            var connectionString = _configuration.GetConnectionString("MariaDB");

            return new SqlUnitOfWork(connectionString);
        }
    }
}
