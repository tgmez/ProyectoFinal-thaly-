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
	public class ClasesDAO : ClaseInterfaz
	{

		private static int contadorId = 1;


		public  void crear(Clase clase)
		{
			clase.Id = contadorId++;
			Datos.clases.Add(clase);
			using (SqlConnection connection = new SqlConnection("Server=DESKTOP-0C9KP3S\\SQLEXPRESS02;Database=ProyectoFinal; Trusted_Connection=True"))
			{
				string query = "INSERT INTO CaracteristicaVariable (Nombre, Descripccion) VALUES (@Nombre @Descripccion)";
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@Nombre", clase.Nombre);
				command.Parameters.AddWithValue("@Descripccion", clase.Descripcion);
				connection.Open();
				var result = command.ExecuteNonQuery();
				connection.Close();
			}

		}
		public  void modificar(Clase clase)
		{

		}
		public  List<Clase> listar()
		{
			return Datos.clases;
		}
		public  void eliminar(Clase clase)
		{
			Datos.clases.Remove(clase);
		}
		public  Clase obtener(int id)
		{
			foreach (Clase item in Datos.clases)
			{
				if (item.Id == id) return item;
			}
			return null;
		}
		public  Clase obtenerPorIdPersonaje(int id)
		{
			foreach (Clase item in Datos.clases)
			{
				foreach (Personaje p in item.personajes) {
					if (p.Id == id) return item;
				}
			}
			return null;
		}
	}
}
