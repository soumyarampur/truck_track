using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheelTrack.Core.Factories;

namespace WheelTrack.DAL.Factories
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly string _connectionString;
        IDbConnection _connection;
        IDbTransaction _transaction;

        public SqlUnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
            InitConnection();
        }

        private void InitConnection()
        {
            if (_connection == null)
            {
                _connection = new MySqlConnection(_connectionString);
            }

            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
        }

        IDbConnection IUnitOfWork.Connection
        {
            get { return _connection; }
        }

        IDbTransaction IUnitOfWork.Transaction
        {
            get { return _transaction; }
        }

        public void StartTransaction()
        {
            _transaction = _connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _transaction.Commit();
            Dispose();
        }

        public void RollbackTransaction()
        {
            _transaction.Rollback();
            Dispose();

        }

        public void Dispose()
        {
            if (_transaction != null)
                _transaction.Dispose();

            _transaction = null;

            if (_connection.State != ConnectionState.Closed)
                _connection.Close();
        }
    }
}
