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
	public class CaracteristicasVariablesDAO : CaracteristicaVariableInterfaz
	{

		private static int contadorId = 1;

		public void crear(CaracteristicaVariable caracteristicaVariable) {
			caracteristicaVariable.Id = contadorId++;
			Datos.caracteristicasVariables.Add(caracteristicaVariable);
			using (SqlConnection connection = new SqlConnection("Server=DESKTOP-0C9KP3S\\SQLEXPRESS02;Database=ProyectoFinal; Trusted_Connection=True"))
			{
				string query = "INSERT INTO CaracteristicaVariable (Nombre) VALUES (@Nombre)";
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@Nombre", caracteristicaVariable.nombre);
				connection.Open();
				var result = command.ExecuteNonQuery();
				connection.Close();
			}
		}
		public void modificar(CaracteristicaVariable caracteristicaVariable) {

		}
		public List<CaracteristicaVariable> listar() {
			return Datos.caracteristicasVariables;
		}
		public void eliminar(CaracteristicaVariable caracteristicaVariable) {
			Datos.caracteristicasVariables.Remove(caracteristicaVariable);
		}
		public CaracteristicaVariable obtener(int id) {
			foreach (CaracteristicaVariable item in Datos.caracteristicasVariables) {
				if (item.Id == id) return item;
			}
			return null;
		}
	}
}
