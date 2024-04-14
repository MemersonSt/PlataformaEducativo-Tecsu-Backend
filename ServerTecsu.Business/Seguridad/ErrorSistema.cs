
namespace ServerTecsu.Business.Seguridad
{
    public class ErrorSistema : IErrorSistema
    {
        public Exception MostrarError(string error)
        {
            throw new NegocioException(error);
        }
    }
}
