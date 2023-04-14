namespace WebAPi.Models
{
		public class pacienteModelDapper
		{
			public int? idPaciente { get; set; }

			public string? Nombre { get; set; }

			public int? tipodoc { get; set; }
			public int? docu { get; set; }
			public decimal? tel { get; set; }
		}

		public class PacientesInsertModel
		{
		public int? idPaciente { get; set; }

		public string? Nombre { get; set; }

		public int? tipodoc { get; set; }
		public int? docu { get; set; }
		public decimal? tel { get; set; }
	}
		public class DocumentosModel
		{
			public int? idTipoDoc { get; set; }
			public string? TipoDoc { get; set; }

		}
	
}
