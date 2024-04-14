namespace ServerTecsu.Business.DataAccess
{
    public class Configuracion
    {
        public string ServerSqlConnection { get; set; }
        public Configuracion(string serverSqlConnection)
        {
            ServerSqlConnection = serverSqlConnection;
        }
    }
}
