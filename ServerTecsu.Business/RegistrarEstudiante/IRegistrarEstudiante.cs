using ServerTecsu.Business.DataAccess;
using ServerTecsu.Business.Seguridad;
using ServerTecsu.Models.RegistrarEstudiante;

namespace ServerTecsu.Business.RegistrarEstudiante
{
    public interface IRegistrarEstudiante
    {
        SqlHelper SqlHelper { get; set; }

        Task Grabar(EstudianteModel estudiante);
        Task<List<EstudianteModel>> Listar();
    }
}
