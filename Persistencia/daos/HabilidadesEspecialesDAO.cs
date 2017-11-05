using Persistencia.modelos;
using Persistencia.interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.daos
{
	public  class HabilidadesEspecialesDAO : HabilidadesEspecialesInterfaz
	{

		private static int contadorId = 1;

		public  void crear(HabilidadEspecial habilidadEspecial)
		{
			habilidadEspecial.Id = contadorId++;
			Datos.habilidadesEspeciales.Add(habilidadEspecial);

			using (SqlConnection connection = new SqlConnection("Server=DESKTOP-0C9KP3S\\SQLEXPRESS02;Database=ProyectoFinal; Trusted_Connection=True"))
			{
				string query = "INSERT INTO CaracteristicaVariable (Nombre, Descripcion) VALUES (@Nombre @Descripcion)";
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@Nombre", habilidadEspecial.Nombre);
				command.Parameters.AddWithValue("@Descripccion", habilidadEspecial.Descripccion);
				connection.Open();
				var result = command.ExecuteNonQuery();
				connection.Close();
			}
		}
		public  void modificar(HabilidadEspecial habilidadEspecial)
		{

		}
		public  List<HabilidadEspecial> listar()
		{
			return Datos.habilidadesEspeciales;
		}
		public  void eliminar(HabilidadEspecial habilidadEspecial)
		{
			Datos.habilidadesEspeciales.Remove(habilidadEspecial);
		}
		public  HabilidadEspecial obtener(int id)
		{
			foreach (HabilidadEspecial item in Datos.habilidadesEspeciales)
			{
				if (item.Id == id) return item;
			}
			return null;
		}
	}
}
