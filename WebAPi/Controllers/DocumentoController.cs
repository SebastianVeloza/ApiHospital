using Microsoft.AspNetCore.Mvc;
using WebAPi.datos;
using WebAPi.Models;

namespace WebAPi.Controllers
{
	
		[ApiController]
		[Route("/documento")]
		public class DocumentoController : ControllerBase
		{
			[HttpGet]
			public async Task<ActionResult<List<Mdocumento>>> GetALL()
			{
				var funcion = new Ddocumentos();
				var lista = await funcion.Mostrardocumento();
				return lista;
			}

			[HttpPost("insertar")]
			public async Task Insertar([FromBody] Mdocumento parametros)
			{
				var funcion = new Ddocumentos();
				await funcion.InsertarDocumento(parametros);
			}

			[HttpPut("editar/{id}")]
			public async Task editar(int id, [FromBody] Mdocumento parametros)
			{
				var funcion = new Ddocumentos();
				parametros.idTipoDoc = id;
				await funcion.editarDocumento(parametros);

			}

			[HttpDelete("eliminar/{id}")]
			public async Task Eliminar(int id)
			{
				var funcion = new Ddocumentos();
				var parametros = new Mdocumento();
				parametros.idTipoDoc = id;
				await funcion.eliminarDocumento(parametros);

			}
		}
	}

