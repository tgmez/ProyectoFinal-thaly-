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
	public class ClasesControlador
	{

		static ClaseInterfaz ClasesDAO = ClaseFactory.Instance.obtenerDAO();
		static HabilidadesEspecialesInterfaz HabilidadesEspecialesDAO = HabilidadEspecialFactory.Instance.obtenerDAO();

		public static void Crear()
		{

			Console.WriteLine("Nombre:");
			String nombre = InputUtils.leerString();

			Console.WriteLine("Descripcion:");
			String descripcion = InputUtils.leerString();

			ClasesDAO.crear(new Clase
			{
				Nombre = nombre,
				Descripcion = descripcion,
				habilidadesEspeciales = new List<HabilidadEspecial>(),
				personajes = new List<Personaje>()
			});
		}

		public static void Modificar()
		{
			Listar();
			Console.WriteLine("Seleccione Id:");
			int id = InputUtils.leerId();
			if (ClasesDAO.obtener(id) == null)
			{
				Console.WriteLine("Id no existe.");
				return;
			}
			Clase item = ClasesDAO.obtener(id);
			Console.WriteLine("Seleccione opcion: ");
			Console.WriteLine("1 - Nombre");
			Console.WriteLine("2 - Descripcion");
			Console.WriteLine("3 - Agregar Habilidad Especial");
			Console.WriteLine("4 - Quitar Habilidad Especial");
			int opcion = InputUtils.leerInt(1, 4);
			switch (opcion)
			{
				case 1:
					Console.WriteLine("Nombre:");
					item.Nombre = InputUtils.leerString();
					break;
				case 2:
					Console.WriteLine("Descripcion:");
					item.Descripcion = InputUtils.leerString();
					break;
				case 3:
					Console.WriteLine("Seleccione Habilidad Especial:");
					HabilidadesEspecialesControlador.Listar();
					HabilidadEspecial habilidadEspecial = HabilidadesEspecialesDAO.obtener(InputUtils.leerId());
					if (habilidadEspecial == null) {
						Console.WriteLine("No se encontro la Habilidad Especial:");
						return;
					}
					item.habilidadesEspeciales.Add(habilidadEspecial);
					break;
				case 4:
					Console.WriteLine("Seleccione Habilidad Especial:");
					HabilidadesEspecialesControlador.Listar();
					HabilidadEspecial habilidadEspecial2 = HabilidadesEspecialesDAO.obtener(InputUtils.leerId());
					if (habilidadEspecial2 == null)
					{
						Console.WriteLine("No se encontro la Habilidad Especial:");
						return;
					}
					item.habilidadesEspeciales.Remove(habilidadEspecial2);
					break;
				default:
					Console.WriteLine("La opcion ingresada no es correcta");
					break;
			}
		}


		public static void Listar()
		{
			foreach (Clase item in ClasesDAO.listar())
			{
				Console.WriteLine("Id: {0} --- Nombre: {1} --- Descripción: {2}", item.Id, item.Nombre, item.Descripcion);
			}
		}

		public static void Eliminar()
		{
			Listar();
			Console.WriteLine("Seleccione Id:");
			int id = InputUtils.leerId();
			if (ClasesDAO.obtener(id) == null)
			{
				Console.WriteLine("Id no existe.");
				return;
			}
			if (ClasesDAO.obtener(id).personajes.Count > 0)
			{
				Console.WriteLine("No se puede eliminar la clase porque contiene personajes");
				return;
			}
			ClasesDAO.eliminar(ClasesDAO.obtener(id));
		}

	}
}
