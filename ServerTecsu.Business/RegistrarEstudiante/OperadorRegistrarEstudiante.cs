using ServerTecsu.Business.DataAccess;
using ServerTecsu.Business.Seguridad;
using ServerTecsu.Models.RegistrarEstudiante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTecsu.Business.RegistrarEstudiante
{
    public class OperadorRegistrarEstudiante
    {
        private readonly IRegistrarEstudiante _registrar;
        private readonly SqlHelper _sqlHelper;

        public OperadorRegistrarEstudiante(IRegistrarEstudiante registrar, SqlHelper sqlHelper)
        {
            _registrar = registrar;
            _sqlHelper = sqlHelper;
        }

        public async Task GrabarAsync(EstudianteModel estudiante)
        {
                _sqlHelper.IniciarTransaccion();
                _registrar.SqlHelper = _sqlHelper;
                await _registrar.Grabar(estudiante);
                _sqlHelper.ConfirmarTransaccion();
        }

        public async Task<List<EstudianteModel>> ListarAsync()
        {
            _registrar.SqlHelper = _sqlHelper;
            return await _registrar.Listar();
        }
    }
}
