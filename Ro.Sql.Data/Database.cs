using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace Ro.Sql.Data
{
    public class Database : IDatabaseAsync
    {
        private string ConnectionString { get; set; }
        public Database(string connString)
        {
            this.ConnectionString = connString;
        }

        private DbConnection GetConnection()
        {
            return new SqlConnection(this.ConnectionString);
        }

        public Task<int> ExecuteNonQuery(DbCommand cmd)
        {
            return DatabaseTasks.ExecuteNonQueryAsync(cmd, GetConnection());
        }

        public Task<object> ExecuteScalar(DbCommand cmd)
        {
            return DatabaseTasks.ExecuteScalarAsync(cmd, GetConnection());
        }

        public Task ExecuteReader(DbCommand cmd, Action<IDataReader> action, CommandBehavior behavior = CommandBehavior.CloseConnection)
        {
            return DatabaseTasks.ExecuteReaderAsync(cmd, GetConnection(), action, behavior);
        }

        public Task<T> GetOneRow<T>(DbCommand cmd, Func<IDataReader, T> mapper)
        {
            return DatabaseTasks.GetOneRow(cmd, GetConnection(), mapper);
        }

        public Task<IEnumerable<T>> GetRows<T>(DbCommand cmd, Func<IDataReader, T> mapper)
        {
            return DatabaseTasks.GetRows(cmd, GetConnection(), mapper);
        }

        public Task<T> GetOneRowAsync<T>(DbCommand cmd, Func<IDataReader, Task<T>> mapper)
        {
            return DatabaseTasks.GetOneRowAsync(cmd, GetConnection(), mapper);
        }

        public Task<IEnumerable<T>> GetRowsAsync<T>(DbCommand cmd, Func<IDataReader, Task<T>> mapper)
        {
            return DatabaseTasks.GetRowsAsync(cmd, GetConnection(), mapper);
        }
    }
}
