using System.Data;
using System.Data.SqlClient;
using WebAPi.conexion;
using WebAPi.Models;
namespace WebAPi.datos
{
	public class Dpacientes
	{
		conexionbd cn = new conexionbd();
		public async Task<List<Mpaciente>> Mostrarpaciente()
		{
			var lista = new List<Mpaciente>();
			using (var sql=new SqlConnection(cn.cadenaSQL()))
			{
				using (var cmd=new SqlCommand("mostrarpaciente",sql)) { 
					
					await sql.OpenAsync();
					cmd.CommandType=CommandType.StoredProcedure;
					using(var item=await cmd.ExecuteReaderAsync())
					{
                        while (await item.ReadAsync())
                        {
							var mpaciente= new Mpaciente();
							mpaciente.idPaciente = (int)item["idPaciente"];
							mpaciente.Nombre = (string)item["Nombre"];
							mpaciente.tipodoc = (int)item["tipodoc"];
							mpaciente.docu = (int)item["docu"];
							mpaciente.tel = (decimal)item["tel"];
							lista.Add(mpaciente);
                            
                        }
                    }
				}
			}
			return lista;
		}

		public async Task Insertarpaciente(Mpaciente parametros)
		{
			using (var sql = new SqlConnection(cn.cadenaSQL()))
			{
				using (var cmd = new SqlCommand("insertarPaciente", sql)) {
					await sql.OpenAsync();
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@Nombre", parametros.Nombre);
					cmd.Parameters.AddWithValue("@tipodoc", parametros.tipodoc);
					cmd.Parameters.AddWithValue("@docu", parametros.docu);
					cmd.Parameters.AddWithValue("@tel", parametros.tel);

					await cmd.ExecuteNonQueryAsync();
				}
			}
		}

		public async Task editarpaciente(Mpaciente parametros)
		{
			using (var sql = new SqlConnection(cn.cadenaSQL()))
			{
				using (var cmd = new SqlCommand("editarPaciente", sql))
				{
					await sql.OpenAsync();
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id", parametros.idPaciente);
					cmd.Parameters.AddWithValue("@Nombre", parametros.Nombre);
					cmd.Parameters.AddWithValue("@tipodoc", parametros.tipodoc);
					cmd.Parameters.AddWithValue("@docu", parametros.docu);
					cmd.Parameters.AddWithValue("@tel", parametros.tel);

					await cmd.ExecuteNonQueryAsync();
				}
			}
		}
		public async Task eliminarpaciente(Mpaciente parametros)
		{
			using (var sql = new SqlConnection(cn.cadenaSQL()))
			{
				using (var cmd = new SqlCommand("editarPaciente", sql))
				{
					await sql.OpenAsync();
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id", parametros.idPaciente);

					await cmd.ExecuteNonQueryAsync();
				}
			}
		}

		



		
	}
}
