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
	public  class RazaDAO : RazaInterfaz
	{
		private static int contadorId = 1;

		public  void crear(Raza raza)
		{
			raza.Id = contadorId++;
			Datos.razas.Add(raza);
			using (SqlConnection connection = new SqlConnection("Server=DESKTOP-0C9KP3S\\SQLEXPRESS02;Database=ProyectoFinal; Trusted_Connection=True"))
			{
				string query = "INSERT INTO CaracteristicaVariable (Nombre, Descripcion, Bonus) VALUES (@Nombre @Descripcion @Bonus)";
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@Nombre", raza.nombre);
				command.Parameters.AddWithValue("@Descripcion", raza.Descripcion);
				command.Parameters.AddWithValue("@Bonus", raza.Bonus);
				connection.Open();
				var result = command.ExecuteNonQuery();
				connection.Close();
			}
		}
		public  void modificar(Raza raza)
		{

		}
		public  List<Raza> listar()
		{
			return Datos.razas;
		}
		public  void eliminar(Raza raza)
		{
			Datos.razas.Remove(raza);
		}
		public  Raza obtener(int id)
		{
			foreach (Raza item in Datos.razas)
			{
				if (item.Id == id) return item;
			}
			return null;
		}
		public  Raza obtenerPorPersonaje(int idPersonaje)
		{
			foreach (Raza item in Datos.razas)
			{
				foreach (Personaje personaje in item.personajes)
				{
					if (personaje.Id == idPersonaje) return item;
				}
			}
			return null;
		}
	}
}