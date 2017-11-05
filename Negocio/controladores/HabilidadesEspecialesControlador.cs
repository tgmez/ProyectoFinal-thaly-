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
	public class HabilidadesEspecialesControlador
	{

		static ClaseInterfaz ClasesDAO = ClaseFactory.Instance.obtenerDAO();
		static HabilidadesEspecialesInterfaz HabilidadesEspecialesDAO = HabilidadEspecialFactory.Instance.obtenerDAO();

		public static void Crear() {

			Console.WriteLine("Nombre:");
			String nombre = InputUtils.leerString();

			Console.WriteLine("Descripcion:");
			String descripcion = InputUtils.leerString();

			HabilidadesEspecialesDAO.crear(new HabilidadEspecial {
				Nombre = nombre,
				Descripccion = descripcion
			});
		}

		public static void Modificar()
		{
			Listar();
			Console.WriteLine("Seleccione Id:");
			int id = InputUtils.leerId();
			if (HabilidadesEspecialesDAO.obtener(id) == null)
			{
				Console.WriteLine("Id no existe.");
				return;
			}
			HabilidadEspecial item = HabilidadesEspecialesDAO.obtener(id);
			Console.WriteLine("Seleccione opcion: ");
			Console.WriteLine("1 - Nombre");
			Console.WriteLine("2 - Descripcion");
			int opcion = InputUtils.leerInt(1, 2);
			switch (opcion)
			{
				case 1:
					Console.WriteLine("Nombre:");
					item.Nombre = InputUtils.leerString();
					break;
				case 2:
					Console.WriteLine("Descripcion:");
					item.Descripccion = InputUtils.leerString();
					break;
				default:
					Console.WriteLine("La opcion ingresada no es correcta");
					break;
			}
		}


		public static void Listar()
		{
			foreach (HabilidadEspecial item in HabilidadesEspecialesDAO.listar()) {
				Console.WriteLine("Id: {0} --- Nombre: {1} --- Descripción: {2}", item.Id, item.Nombre, item.Descripccion);
			}
		}

		public static void ListarPorClase()
		{
			ClasesControlador.Listar();
			Console.WriteLine("Seleccione Id:");
			int id = InputUtils.leerId();
			if (ClasesDAO.obtener(id) == null)
			{
				Console.WriteLine("Id no existe.");
				return;
			}
			Clase clase = ClasesDAO.obtener(id);
			foreach (HabilidadEspecial item in clase.habilidadesEspeciales)
			{
				Console.WriteLine("Id: {0} --- Nombre: {1} --- Descripción: {2}", item.Id, item.Nombre, item.Descripccion);
			}
		}

		public static void Eliminar()
		{
			Listar();
			Console.WriteLine("Seleccione Id:");
			int id = InputUtils.leerId();
			if (HabilidadesEspecialesDAO.obtener(id) == null) {
				Console.WriteLine("Id no existe.");
				return;
			}
			HabilidadesEspecialesDAO.eliminar(HabilidadesEspecialesDAO.obtener(id));
		}

	}
}
