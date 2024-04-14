using ServerTecsu.Business.DataAccess;
using ServerTecsu.Business.Seguridad;
using ServerTecsu.Models.RegistrarEstudiante;

namespace ServerTecsu.Business.RegistrarEstudiante
{
    public class RegistrarEstudiante : IRegistrarEstudiante
    {
        public SqlHelper SqlHelper { get; set; }

        public async Task Grabar(EstudianteModel estudiante)
        {
            await SqlHelper.EjecutarSpAsync("RegistrarEstudiante", new {
                estudiante.Codigo,
                estudiante.Nombre,
                estudiante.Apellido,
            });
        }

        public Task<List<EstudianteModel>> Listar()
        {
            return SqlHelper.ListarAsync<EstudianteModel>("ListarEstudiante");
        }
    }
}
