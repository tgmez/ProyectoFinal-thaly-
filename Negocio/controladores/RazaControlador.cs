using Persistencia.daos;
using Negocio.fabricas;
using Persistencia.interfaz;
using Persistencia.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.controladores
{
	public static class RazaControlador
	{

		static CaracteristicaVariableInterfaz CaracteristicasVariablesDAO = CaracteristicaVariableFactory.Instance.obtenerDAO();
		static RazaInterfaz RazaDAO = RazaFactory.Instance.obtenerDAO();

		public static void Crear()
		{
			if (CaracteristicasVariablesDAO.listar().Count == 0) {
				Console.WriteLine("Debe crear al menos una caracteristica variable para asignarle a la raza.");
				return;
			}

			Console.WriteLine("Nombre:");
			String Nombre = InputUtils.leerString();

			Console.WriteLine("Descripcion:");
			String Descripcion = InputUtils.leerString();

			Console.WriteLine("Seleccione Id de Caracteristica Variable:");
			CaracteristicaVariableControlador.Listar();
			int id = InputUtils.leerId();
			if (CaracteristicasVariablesDAO.obtener(id) == null)
			{
				Console.WriteLine("Id no existe.");
				return;
			}
			CaracteristicaVariable item = CaracteristicasVariablesDAO.obtener(id);

			Console.WriteLine("Bonus:");
			int Bonus = InputUtils.leerInt(1,5);

			RazaDAO.crear(new Raza
			{
				nombre = Nombre,
				Descripcion = Descripcion,
				personajes = new List<Personaje>(),
				caracteristicaVariable = item,
				Bonus = Bonus
			});
		}

		public static void Modificar()
		{
			Listar();
			Console.WriteLine("Seleccione Id:");
			int id = InputUtils.leerId();
			if (RazaDAO.obtener(id) == null)
			{
				Console.WriteLine("Id no existe.");
				return;
			}
			Raza item = RazaDAO.obtener(id);
			Console.WriteLine("Seleccione opcion: ");
			Console.WriteLine("1 - Nombre");
			Console.WriteLine("2 - Descripcion");
			int opcion = InputUtils.leerInt(1, 2);
			switch (opcion)
			{
				case 1:
					Console.WriteLine("Nombre:");
					item.nombre = InputUtils.leerString();
					break;
				case 2:
					Console.WriteLine("Descripcion:");
					item.Descripcion = InputUtils.leerString();
					break;
				default:
					Console.WriteLine("La opcion ingresada no es correcta");
					break;
			}
		}


		public static void Listar()
		{
			foreach (Raza item in RazaDAO.listar())
			{
				Console.WriteLine("Id: {0} --- Nombre: {1} --- Descripción: {2}", item.Id, item.nombre, item.Descripcion);
			}
		}

		public static void Eliminar()
		{
			Listar();
			Console.WriteLine("Seleccione Id:");
			int id = InputUtils.leerId();
			if (RazaDAO.obtener(id) == null)
			{
				Console.WriteLine("Id no existe.");
				return;
			}
			if (RazaDAO.obtener(id).personajes.Count > 0) {
				Console.WriteLine("No se puede eliminar la raza porque contiene personajes");
				return;
			} 
			RazaDAO.eliminar(RazaDAO.obtener(id));
		}

	}
}
