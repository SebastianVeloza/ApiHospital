using System.Data.SqlClient;
using Dapper;

namespace WebAPi.conexion
{
	public class DBPrincipalDapper
	{
		// se realiza por medio del appseting la conexion de la base de datos y para hacerla generica, se realiza un constructor en el Program para pasar la cadena de conexion
		public DBPrincipalDapper(string connectionString) => ConnectionString = connectionString;
		public static string? ConnectionString { get; set; }

		public static SqlConnection DbContextSQLOperacion()
		{
			return new SqlConnection(ConnectionString);
		}
		//metodos para las consultas get con un getall y y get con parametros 
		#region Gets

		public static async Task<IEnumerable<T>> Getall<T>(string sql)
		{
			return await DbContextSQLOperacion().QueryAsync<T>(sql);
		}

		public static async Task<T> GetbyId<T>(string sql)
		{
			return await DbContextSQLOperacion().QueryFirstOrDefaultAsync<T>(sql);
		}
		#endregion
		//metodos para el insert updatee y delete 
		#region Insert/Update
		public static async Task<bool> InsertUpdateParam<T>(string sql, T model)
		{
			try
			{
				return await DbContextSQLOperacion().ExecuteAsync(sql, model) > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public static async Task<bool> InsertUpdate(string sql)
		{
			try
			{
				return await DbContextSQLOperacion().ExecuteAsync(sql) > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}
		#endregion
	}
}
