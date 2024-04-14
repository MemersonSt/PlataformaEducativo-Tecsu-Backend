using Microsoft.AspNetCore.Mvc;
using ServerTecsu.Business.RegistrarEstudiante;
using ServerTecsu.Models.RegistrarEstudiante;

namespace ServerTecsu.Controllers.RegistrarEstudiante
{
    [ApiController]
    [Route("api/registrarestudiante")]
    public class RegistrarEstudianteController : ControllerBase
    {
        private readonly OperadorRegistrarEstudiante _operador;

        public RegistrarEstudianteController(OperadorRegistrarEstudiante operador)
        {
            _operador = operador;
        }

        [HttpPost("insertar")]
        public async Task<IActionResult> Post([FromBody] EstudianteModel estudiante)
        {
            await _operador.GrabarAsync(estudiante);
            return Ok(estudiante);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> GetAll()
        {
            var listaEstudiante = await _operador.ListarAsync();
            return Ok(listaEstudiante);
        }
    }
}
