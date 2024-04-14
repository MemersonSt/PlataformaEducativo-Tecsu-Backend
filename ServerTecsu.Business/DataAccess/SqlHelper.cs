using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using static Dapper.SqlMapper;

namespace ServerTecsu.Business.DataAccess
{
    public class SqlHelper
    {
        private readonly string _serverConnectionString;
        private SqlConnection? Connection {  get; set; }
        private SqlTransaction? Transaction {  get; set; }
        private const int TimeOut = 2000;

        public SqlHelper(Configuracion serverConnectionString)
        {
            _serverConnectionString = serverConnectionString.ServerSqlConnection;
        }

        public void IniciarTransaccion()
        {
            Connection = new SqlConnection(_serverConnectionString);
            Connection.Open();
            Transaction = Connection.BeginTransaction();
        }

        public void ConfirmarTransaccion()
        {
            Transaction?.Commit();
            Transaction = null;
            Connection?.Close();
        }

        public void AbortarTransaccion()
        {
            Transaction?.Rollback();
            Transaction = null;
            Connection?.Close();
        }

        public async Task<T> ConsultarAsync<T>(string spName, object? parametros = null)
        {
            using var connection = new SqlConnection(_serverConnectionString);
            var consulta = await connection.QueryFirstOrDefaultAsync<T>(spName, parametros,
                commandType: CommandType.StoredProcedure);
            return consulta;
        }

        public async Task<List<T>> ListarAsync<T>(string spName, object? parametros = null)
        {
            using var connection = new SqlConnection(_serverConnectionString);
            var results = await connection.QueryAsync<T>(spName, parametros, commandType: CommandType.StoredProcedure);
            return results.ToList();
        }

        public async Task EjecutarSpAsync(string spName, object parametros)
        {
            await Connection.ExecuteAsync(spName, parametros, Transaction, TimeOut, commandType: CommandType.StoredProcedure);
        }

        public async Task<object> EjecutarSpEscalarAsync(string spName, object parametros)
        {
            return await Connection.ExecuteScalarAsync(spName, parametros, Transaction, TimeOut, commandType: CommandType.StoredProcedure);
        }
    }
}
