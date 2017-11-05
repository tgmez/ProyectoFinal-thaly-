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
	public  class PersonajeCaracteristicaDAO : PersonajeCaracteristicaInterfaz
	{
		private static int contadorId = 1;

		public  void crear(PersonajeCaracteristica personajeCaracteristica)
		{
			personajeCaracteristica.Id = contadorId++;
			Datos.personajesCaracteristicas.Add(personajeCaracteristica);
			using (SqlConnection connection = new SqlConnection("Server=DESKTOP-0C9KP3S\\SQLEXPRESS02;Database=ProyectoFinal; Trusted_Connection=True"))
			{
				string query = "INSERT INTO CaracteristicaVariable (Valor) VALUES (@Valor)";
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@Valor", personajeCaracteristica.Valor);
				connection.Open();
				var result = command.ExecuteNonQuery();
				connection.Close();
			}

		}
		public  void modificar(PersonajeCaracteristica personajeCaracteristica)
		{

		}
		public  List<PersonajeCaracteristica> listar()
		{
			return Datos.personajesCaracteristicas;
		}
		public  void eliminar(PersonajeCaracteristica personajeCaracteristica)
		{
			Datos.personajesCaracteristicas.Remove(personajeCaracteristica);

		}
		public  PersonajeCaracteristica obtener(int id)
		{
			foreach (PersonajeCaracteristica item in Datos.personajesCaracteristicas)
			{
				if (item.Id == id) return item;
			}
			return null;
		}
		public  List<PersonajeCaracteristica> obtenerCaracteristicaPersonajesPorPersonaje(int id)
		{
			List<PersonajeCaracteristica> result = new List<PersonajeCaracteristica>();
			foreach (PersonajeCaracteristica item in Datos.personajesCaracteristicas)
			{
				if (item.Id == id) result.Add(item);
			}
			return result;
		}
	}
}