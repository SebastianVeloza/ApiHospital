using System.Data;
using System.Data.SqlClient;
using WebAPi.conexion;
using WebAPi.Models;

namespace WebAPi.datos
{
	public class Ddocumentos
	{
		conexionbd cn = new conexionbd();
		public async Task<List<Mdocumento>> Mostrardocumento()
		{
			var lista = new List<Mdocumento>();
			using (var sql = new SqlConnection(cn.cadenaSQL()))
			{
				using (var cmd = new SqlCommand("mostrardocumento", sql))
				{

					await sql.OpenAsync();
					cmd.CommandType = CommandType.StoredProcedure;
					using (var item = await cmd.ExecuteReaderAsync())
					{
						while (await item.ReadAsync())
						{
							var mdocumento = new Mdocumento();
							mdocumento.idTipoDoc = (int)item["IdTipoDoc"];
							mdocumento.TipoDoc = (string)item["TipoDoc"];

							lista.Add(mdocumento);

						}
					}
				}
			}
			return lista;
		}




		public async Task InsertarDocumento(Mdocumento parametros)
		{
			using (var sql = new SqlConnection(cn.cadenaSQL()))
			{
				using (var cmd = new SqlCommand("insertarDocumento", sql))
				{
					await sql.OpenAsync();
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@TipoDoc", parametros.TipoDoc);

					await cmd.ExecuteNonQueryAsync();
				}
			}
		}

		public async Task editarDocumento(Mdocumento parametros)
		{
			using (var sql = new SqlConnection(cn.cadenaSQL()))
			{
				using (var cmd = new SqlCommand("editardocumento", sql))
				{
					await sql.OpenAsync();
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id", parametros.idTipoDoc);
					cmd.Parameters.AddWithValue("@TipoDoc", parametros.TipoDoc);

					await cmd.ExecuteNonQueryAsync();
				}
			}
		}
		public async Task eliminarDocumento(Mdocumento parametros)
		{
			using (var sql = new SqlConnection(cn.cadenaSQL()))
			{
				using (var cmd = new SqlCommand("deletedocumento", sql))
				{
					await sql.OpenAsync();
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id", parametros.idTipoDoc);

					await cmd.ExecuteNonQueryAsync();
				}
			}
		}
	}
}
