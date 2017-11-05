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
	public  class PersonajeDAO : PersonajeInterfaz
	{
		private static int contadorId = 1;

		public  void crear(Personaje personaje)
		{
			personaje.Id = contadorId++;
			Datos.personajes.Add(personaje);
			using (SqlConnection connection = new SqlConnection("Server=DESKTOP-0C9KP3S\\SQLEXPRESS02;Database=ProyectoFinal; Trusted_Connection=True"))
			{
				string query = "INSERT INTO CaracteristicaVariable (Nombre,Nivel, Fuerza, Destreza, Constitucion, Inteligencia, Sabiduria, Carisma) VALUES (@Nombre @Nivel @Fuerza @Destreza @Constitucion @Inteligenci @Sabiduria @Carisma)";
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@Nombre", personaje.Nombre);
				command.Parameters.AddWithValue("@Nivel", personaje.Nivel);
				command.Parameters.AddWithValue("@Fuerza", personaje.Fuerza);
				command.Parameters.AddWithValue("@Destresa", personaje.Destreza);
				command.Parameters.AddWithValue("@Constitucion", personaje.Constitucion);
				command.Parameters.AddWithValue("@Inteligencia", personaje.Inteligencia);
				command.Parameters.AddWithValue("@Sabiduria", personaje.Sabiduria);
				command.Parameters.AddWithValue("@Carisma", personaje.Carisma);
				
				connection.Open();
				var result = command.ExecuteNonQuery();
				connection.Close();
			}

		}
		public  void modificar(Personaje personaje)
		{

		}
		public  List<Personaje> listar()
		{
			return Datos.personajes;
		}
		public  void eliminar(Personaje personaje)
		{
			foreach (Raza raza in new RazaDAO().listar()) {
				foreach (Personaje p in raza.personajes) {
					if (p.Id == personaje.Id) raza.personajes.Remove(p);
				}
			}
			foreach (Clase clase in new ClasesDAO().listar())
			{
				foreach (Personaje p in clase.personajes)
				{
					if (p.Id == personaje.Id) clase.personajes.Remove(p);
				}
			}
			Datos.personajes.Remove(personaje);
		}
		public  Personaje obtener(int id)
		{
			foreach (Personaje item in Datos.personajes)
			{
				if (item.Id == id) return item;
			}
			return null;
		}
		public  bool personajeTieneRaza(int id)
		{
			foreach (Raza raza in new RazaDAO().listar()) {
				foreach (Personaje personaje in raza.personajes) {
					if (personaje.Id == id) return true;
				}
			}
			return false;
		}
		public  bool personajeTieneClase(int id)
		{
			foreach (Clase clase in new ClasesDAO().listar())
			{
				foreach (Personaje personaje in clase.personajes)
				{
					if (personaje.Id == id) return true;
				}
			}
			return false;
		}
	}
}