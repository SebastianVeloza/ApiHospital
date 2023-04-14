using Microsoft.AspNetCore.Mvc;
using WebAPi.datos;
using WebAPi.Models;

namespace WebAPi.Controllers
{
	[ApiController]
	[Route("/Paciente")]
	public class PacienteController:ControllerBase
	{
		[HttpGet]
		public async Task<ActionResult<List<Mpaciente>>> GetALL()
		{
			var funcion = new Dpacientes();
			var lista = await funcion.Mostrarpaciente();
			return lista;
		}

		[HttpPost("insertar")]
		public async Task Insertar([FromBody] Mpaciente parametros) {
			var funcion = new Dpacientes();
			await funcion.Insertarpaciente(parametros);
		}

		[HttpPut("editar/{id}")]
		public async Task Editar(int id, [FromBody] Mpaciente parametros)
		{
			var funcion=new Dpacientes();
			parametros.idPaciente = id;
			await funcion.editarpaciente(parametros);

		}

		[HttpDelete("eliminar/{id}")]
		public async Task Eliminar(int id)
		{
			var funcion= new Dpacientes();
			var parametros= new Mpaciente();
			parametros.idPaciente=id;
			await funcion.eliminarpaciente(parametros);

		}

		

	}
}
