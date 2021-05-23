using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Avansight.Domain
{
    public interface IDapper : IDisposable
    {
        DbConnection CreateCTSSqlConnection();
        T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        IEnumerable<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
    }
    public class DataAccessService : IDapper
    {
        private string ConnectionString;// = _config["ConnectionStrings:DbConnection"];
        private readonly string _connString;
        public DataAccessService(IConfiguration configuration)
        {
            _connString = configuration.GetConnectionString("ConnectionStrings:DbConnection");
        }

        public DbConnection CreateCTSSqlConnection()
        {
            return new SqlConnection(_connString);
        }
        public void Dispose()
        {
        }

        public int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_connString);
            return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
        }

        public IEnumerable<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_connString);
            return db.Query<T>(sp, parms, commandType: commandType).ToList();
        }

        public IEnumerable<T> Query<T>(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure, SqlConnection transactionConn = null)

        {
            if (transactionConn == null)
            {
                using (var conn = CreateCTSSqlConnection()) //Create new SQL Connection
                {
                    return conn.Query<T>(sql, param, null, true, null, commandType);
                }
            }
            else
            {
                return transactionConn.Query<T>(sql, param, null, true, null, commandType);
            }
        }               

        public T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using IDbConnection db = new SqlConnection(_connString);
            
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();

                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }            

            return result;
        }

        public T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }
    }
}
