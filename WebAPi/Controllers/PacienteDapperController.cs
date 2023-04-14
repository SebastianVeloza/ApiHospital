using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using WebAPi.conexion;
using WebAPi.Models;

namespace WebAPi.Controllers
{
	[ApiController]
	[Route("/Dapper")]
	public class PacienteDapperController: ControllerBase
	//****** ahora con DAPPER
	//Principalmente debemos instalar el nugget de DAPPER y System.Data.SqlClient*/
	{
		#region Paciente
		//metodo get all para traer todos los pacientes del sistema, se realiza el query del sql y responde en una lista del modelo
		[HttpGet]
		public async Task<ActionResult<List<pacienteModelDapper>>> Get()
		{
			try
			{
				var sql = $@"select * from Paciente;";
				var datos = await DBPrincipalDapper.Getall<PacientesInsertModel>(sql);
				return Ok(datos);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}



		//metodo insert 
		[HttpPost]
		public async Task<ActionResult<List<PacientesInsertModel>>> Post(PacientesInsertModel datosModel)
		{
			try
			{
				var sql = $@"insert into Paciente ([Nombre]
           ,[tipodoc]
           ,[docu]
           ,[tel]) values(@Nombre,@tipodoc,@docu,@tel);";
				var datos = await DBPrincipalDapper.InsertUpdateParam(sql, datosModel);
				return Ok(datos);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		//metodo Update 

		[HttpPost("Update")]
		public async Task<ActionResult<List<PacientesInsertModel>>> Update(PacientesInsertModel datosModel)
		{
			try
			{
				var sql = $@"update PACIENTES SET Nombre = @Nombre,tel = @tel,tipodoc = @tipodoc,docu = @docu WHERE idPaciente = @idPaciente;";
				var datos = await DBPrincipalDapper.InsertUpdateParam(sql, datosModel);
				return Ok(datos);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}
		//metodo Delete con el parametro del id del usuario 
		[HttpPost("Delete/{ID}")]
		public async Task<ActionResult<List<PacientesInsertModel>>> Delete(decimal ID)
		{
			try
			{
				var sql = $@"DELETE paciente WHERE idPaciente = {ID};";
				var datos = await DBPrincipalDapper.InsertUpdate(sql);
				return Ok(datos);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}





		#endregion


		#region Documento
		[HttpGet("GetDocument")]
		public async Task<ActionResult<List<DocumentosModel>>> GetDocumento()
		{
			try
			{
				var sql = $@"select * from TipoDoc;";
				var datos = await DBPrincipalDapper.Getall<DocumentosModel>(sql);
				return Ok(datos);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		//metodo insert Documentos
		[HttpPost("document")]
		public async Task<ActionResult<List<DocumentosModel>>> PostDocument(DocumentosModel datosModel)
		{
			try
			{
				var sql = $@"insert into TipoDoc (TipoDoc) values(@TipoDoc);";
				var datos = await DBPrincipalDapper.InsertUpdateParam(sql, datosModel);
				return Ok(datos);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}


		//metodo Update 

		[HttpPost("UpdateDocument/{id}")]
		public async Task<ActionResult<List<DocumentosModel>>> UpdateDocument(DocumentosModel datosModel,int id)
		{
			try
			{
				var sql = $@"Update TipoDoc set TipoDoc=@TipoDoc where IdTipoDoc={id};";
				var datos = await DBPrincipalDapper.InsertUpdateParam(sql, datosModel);
				return Ok(datos);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}
		//metodo Delete con el parametro del id del usuario 
		[HttpPost("DeleteDocument/{ID}")]
		public async Task<ActionResult<List<DocumentosModel>>> Deletedocument(int ID)
		{
			try
			{
				var sql = $@"delete from TipoDoc where IdTipoDoc= {ID};";
				var datos = await DBPrincipalDapper.InsertUpdate(sql);
				return Ok(datos);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		#endregion
	}
}
