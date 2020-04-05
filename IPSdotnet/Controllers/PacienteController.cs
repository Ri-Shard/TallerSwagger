using System.Collections.Generic;
using System.Linq;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using IPSdotnet.Models;

namespace IPSdotnet.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class PacienteController : ControllerBase
    {
         private readonly PacienteService _pacienteService;
        public IConfiguration Configuration { get; }
        public PacienteController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _pacienteService = new PacienteService(connectionString);
        }

        // GET: api/Persona
        [HttpGet]
        public IEnumerable<PacienteViewModel> Gets()
        {
            var pacientes = _pacienteService.ConsultarTodos().Select(p=> new PacienteViewModel(p));
            return pacientes;
        }
        // GET: api/Persona/5
     /*   [HttpGet("{identificacion}")]
        public ActionResult<PacienteViewModel> Get(string identificacion)
        {
            var paciente = _pacienteService.BuscarxIdentificacion(identificacion);
            if (paciente == null) return NotFound();
            var pacienteViewModel = new PacienteViewModel(paciente);
            return pacienteViewModel;
        }
*/
        [HttpPost]
        public ActionResult<PacienteViewModel> Post(PacienteInputModel pacienteInput)
        {
            Paciente paciente = MapearPaciente(pacienteInput);
            var response = _pacienteService.Guardar(paciente);
            if (response.Error) 
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Paciente);
        }

        // DELETE: api/Persona/5
      /*  [HttpDelete("{identificacion}")]
        public ActionResult<string> Delete(string identificacion)
        {
            string mensaje = _pacienteService.Eliminar(identificacion);
            return Ok(mensaje);
        }
*/
          private Paciente MapearPaciente(PacienteInputModel pacienteInput)
        {
            var paciente = new Paciente
            {
                Identificacion = pacienteInput.Identificacion,
                Nombre = pacienteInput.Nombre,
                ValorServ = pacienteInput.ValorServ,
                Salario = pacienteInput.Salario,
            };
            return paciente;
        }



    }

}
