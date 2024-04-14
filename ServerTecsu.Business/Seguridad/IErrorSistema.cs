using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTecsu.Business.Seguridad
{
    public interface IErrorSistema
    {
        Exception MostrarError(string error);
    }
}
