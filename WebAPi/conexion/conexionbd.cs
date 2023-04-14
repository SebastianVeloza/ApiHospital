namespace WebAPi.conexion
{
	public class conexionbd
	{
		private string connection=string.Empty;
		public conexionbd() {

			var constructor = new ConfigurationBuilder().SetBasePath(
				Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

			connection = constructor.GetSection("ConnectionStrings:conexion").Value;

		}
		public string cadenaSQL() { 
			return connection;
		}

	}
}
