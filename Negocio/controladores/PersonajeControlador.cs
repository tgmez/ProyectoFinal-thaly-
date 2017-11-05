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
	public static class PersonajeControlador
	{

		static ClaseInterfaz ClasesDAO = ClaseFactory.Instance.obtenerDAO();
		static RazaInterfaz RazaDAO = RazaFactory.Instance.obtenerDAO();
		static PersonajeInterfaz PersonajeDAO = PersonajeFactory.Instance.obtenerDAO();
		static PersonajeCaracteristicaInterfaz PersonajeCaracteristicaDAO = PersonajeCaracteristicaFactory.Instance.obtenerDAO();
		static CaracteristicaVariableInterfaz CaracteristicasVariablesDAO = CaracteristicaVariableFactory.Instance.obtenerDAO();

		public static void Crear()
		{

			if (ClasesDAO.listar().Count == 0) {
				Console.WriteLine("Debe haber al menos una clase para asignarle al personaje");
				return;
			}

			if (RazaDAO.listar().Count == 0)
			{
				Console.WriteLine("Debe haber al menos una raza para asignarle al personaje");
				return;
			}

			Console.WriteLine("Nombre:");
			String Nombre = InputUtils.leerString();

			Console.WriteLine("Nivel:");
			int Nivel = InputUtils.leerNivel();

			Console.WriteLine("Fuerza:");
			int Fuerza = InputUtils.leerValorCaracteristica();

			Console.WriteLine("Destreza:");
			int Destreza = InputUtils.leerValorCaracteristica();

			Console.WriteLine("Constitucion:");
			int Constitucion = InputUtils.leerValorCaracteristica();

			Console.WriteLine("Inteligencia:");
			int Inteligencia = InputUtils.leerValorCaracteristica();

			Console.WriteLine("Sabiduria:");
			int Sabiduria = InputUtils.leerValorCaracteristica();

			Console.WriteLine("Carisma:");
			int Carisma = InputUtils.leerValorCaracteristica();

			Personaje personaje = new Personaje
			{
				Nombre = Nombre,
				Nivel = Nivel,
				Fuerza = Fuerza,
				Destreza = Destreza,
				Constitucion = Constitucion,
				Inteligencia = Inteligencia,
				Sabiduria = Sabiduria,
				Carisma = Carisma,
				habilidadesEspeciales = new List<HabilidadEspecial>()
			};

			PersonajeDAO.crear(personaje);

			Console.WriteLine("Seleccione Id de Raza:");
			RazaControlador.Listar();
			int idRaza = InputUtils.leerId();
			Raza raza = RazaDAO.obtener(idRaza);
			while (raza == null)
			{
				Console.WriteLine("No se encontro la raza, intente nuevamente.");
				idRaza = InputUtils.leerId();
				raza = RazaDAO.obtener(idRaza);
			}
			raza.personajes.Add(personaje);

			Console.WriteLine("Seleccione Id de Clase:");
			ClasesControlador.Listar();
			int idClase = InputUtils.leerId();
			Clase clase = ClasesDAO.obtener(idClase);
			while (clase == null)
			{
				Console.WriteLine("No se encontro la clase, intente nuevamente.");
				idClase = InputUtils.leerId();
				clase = ClasesDAO.obtener(idClase);
			}
			clase.personajes.Add(personaje);

			//se le agregan las caracteristicas variables al personaje con valor 1
			foreach (CaracteristicaVariable caracteristicaVariable in CaracteristicasVariablesDAO.listar()) {
				PersonajeCaracteristicaDAO.crear(new PersonajeCaracteristica {
					caracteristicaVariable = caracteristicaVariable,
					personaje = personaje,
					Valor = 1
				});
			}
		}

		public static void Modificar()
		{
			ListarInformacionBasica();
			Console.WriteLine("Seleccione Id:");
			int id = InputUtils.leerInt(1,12);
			if (PersonajeDAO.obtener(id) == null)
			{
				Console.WriteLine("Id no existe.");
				return;
			}
			Personaje item = PersonajeDAO.obtener(id);
			Console.WriteLine("Seleccione opcion: ");
			Console.WriteLine("1 - Nombre");
			Console.WriteLine("2 - Nivel");
			Console.WriteLine("3 - Fuerza");
			Console.WriteLine("4 - Destreza");
			Console.WriteLine("5 - Constitucion");
			Console.WriteLine("6 - Inteligencia");
			Console.WriteLine("7 - Sabiduria");
			Console.WriteLine("8 - Carisma");
			Console.WriteLine("9 - Cambiar Raza");
			Console.WriteLine("10 - Cambiar Clase");
			int opcion = InputUtils.leerInt(1, 10);
			switch (opcion)
			{
				case 1:
					Console.WriteLine("Nombre:");
					item.Nombre = InputUtils.leerString();
					break;
				case 2:
					Console.WriteLine("Nivel:");
					item.Nivel = InputUtils.leerNivel();
					break;
				case 3:
					Console.WriteLine("Fuerza:");
					item.Fuerza = InputUtils.leerValorCaracteristica();
					break;
				case 4:
					Console.WriteLine("Destreza:");
					item.Destreza = InputUtils.leerValorCaracteristica();
					break;
				case 5:
					Console.WriteLine("Constitucion:");
					item.Constitucion = InputUtils.leerValorCaracteristica();
					break;
				case 6:
					Console.WriteLine("Inteligencia:");
					item.Inteligencia = InputUtils.leerValorCaracteristica();
					break;
				case 7:
					Console.WriteLine("Sabiduria:");
					item.Sabiduria = InputUtils.leerValorCaracteristica();
					break;
				case 8:
					Console.WriteLine("Carisma:");
					item.Carisma = InputUtils.leerValorCaracteristica();
					break;
				case 9:
					foreach (Raza r in RazaDAO.listar())
					{
						foreach (Personaje p in r.personajes)
						{
							if (p.Id == item.Id) r.personajes.Remove(p);
						}
					}
					Console.WriteLine("Seleccione Id de Raza:");
					RazaControlador.Listar();
					int idRaza = InputUtils.leerId();
					Raza raza = RazaDAO.obtener(idRaza);
					while (raza == null)
					{
						Console.WriteLine("No se encontro la raza, intente nuevamente.");
						idRaza = InputUtils.leerId();
						raza = RazaDAO.obtener(idRaza);
					}
					raza.personajes.Add(item);
					break;
				case 10:
					foreach (Clase c in ClasesDAO.listar())
					{
						foreach (Personaje p in c.personajes)
						{
							if (p.Id == item.Id) c.personajes.Remove(p);
						}
					}
					Console.WriteLine("Seleccione Id de Clase:");
					ClasesControlador.Listar();
					int idClase = InputUtils.leerId();
					Clase clase = ClasesDAO.obtener(idClase);
					while (clase == null)
					{
						Console.WriteLine("No se encontro la clase, intente nuevamente.");
						idClase = InputUtils.leerId();
						clase = ClasesDAO.obtener(idClase);
					}
					clase.personajes.Add(item);
					break;
				default:
					Console.WriteLine("La opcion ingresada no es correcta");
					break;
			}
		}


		public static void Listar()
		{
			foreach (Personaje item in PersonajeDAO.listar())
			{
				Console.WriteLine("Id: {0} --- Nombre: {1} --- Nivel: {2}", item.Id, item.Nombre, item.Nivel);
				Console.WriteLine("****Caracteristicas****");
				Console.WriteLine("Fuerza: {0}", item.Fuerza);
				Console.WriteLine("Destreza: {0}", item.Destreza);
				Console.WriteLine("Constitucion: {0}", item.Constitucion);
				Console.WriteLine("Inteligencia: {0}", item.Inteligencia);
				Console.WriteLine("Sabiduria: {0}", item.Sabiduria);
				Console.WriteLine("Carisma: {0}", item.Carisma);
				Console.WriteLine("Raza: {0}", RazaDAO.obtenerPorPersonaje(item.Id).nombre);
				Console.WriteLine("Clase: {0}", ClasesDAO.obtenerPorIdPersonaje(item.Id).Nombre);
				Console.WriteLine("****Caracteristicas Variables****");
				if (PersonajeCaracteristicaDAO.obtenerCaracteristicaPersonajesPorPersonaje(item.Id).Count == 0) Console.WriteLine("Vacio");
				foreach (PersonajeCaracteristica personajeCaracteristica in PersonajeCaracteristicaDAO.obtenerCaracteristicaPersonajesPorPersonaje(item.Id)) {
					if (RazaDAO.obtenerPorPersonaje(personajeCaracteristica.personaje.Id).caracteristicaVariable.Id == personajeCaracteristica.caracteristicaVariable.Id)
					{
						Console.WriteLine("Nombre: {0} --- Valor: {1} --- Bonus: {2}", personajeCaracteristica.caracteristicaVariable.nombre, personajeCaracteristica.Valor, RazaDAO.obtenerPorPersonaje(personajeCaracteristica.personaje.Id).Bonus);
					}
					else {
						Console.WriteLine("Nombre: {0} --- Valor: {1}", personajeCaracteristica.caracteristicaVariable.nombre, personajeCaracteristica.Valor);
					}
					
				}
			}
		}

		public static void ListarInformacionBasica()
		{
			foreach (Personaje item in PersonajeDAO.listar())
			{
				Console.WriteLine("Id: {0} --- Nombre: {1} --- Nivel: {2}", item.Id, item.Nombre, item.Nivel);
			}
		}

		public static void Eliminar()
		{
			ListarInformacionBasica();
			Console.WriteLine("Seleccione Id:");
			int id = InputUtils.leerId();
			if (PersonajeDAO.obtener(id) == null)
			{
				Console.WriteLine("Id no existe.");
				return;
			}
			PersonajeDAO.eliminar(PersonajeDAO.obtener(id));
		}

		public static void SubirNivel()
		{
			ListarInformacionBasica();
			Console.WriteLine("Seleccione Id:");
			int id = InputUtils.leerId();
			if (PersonajeDAO.obtener(id) == null)
			{
				Console.WriteLine("Id no existe.");
				return;
			}
			Personaje personaje = PersonajeDAO.obtener(id);

			//agregar habilidad especial
			
			List<HabilidadEspecial> habilidadesEspecialesAMostrar = new List<HabilidadEspecial>();
			//recorro habilidades especiales de la clase del personaje
			foreach (HabilidadEspecial habilidadClase in ClasesDAO.obtenerPorIdPersonaje(personaje.Id).habilidadesEspeciales) {
				//si no esta en el personaje la imprimo
				bool estaEnPersonaje = false;
				foreach (HabilidadEspecial habilidadPersonaje in personaje.habilidadesEspeciales) {
					if (habilidadClase.Id == habilidadPersonaje.Id) estaEnPersonaje = true;
				}
				if (!estaEnPersonaje) habilidadesEspecialesAMostrar.Add(habilidadClase);
			}

			if (habilidadesEspecialesAMostrar.Count > 0)
			{
				foreach (HabilidadEspecial item in habilidadesEspecialesAMostrar) {
					Console.WriteLine("Id: {0} --- Nombre: {1} --- Descripción: {2}", item.Id, item.Nombre, item.Descripccion);
				}
				Console.WriteLine("Seleccione Id de Habilidad Especial:");
				int idHabilidadEspecial = InputUtils.leerId();
				while (habilidadesEspecialesAMostrar.Find(x => x.Id == idHabilidadEspecial) == null) {
					Console.WriteLine("No se encontro la Habilidad Especial, intente nuevamente.");
					idHabilidadEspecial = InputUtils.leerId();
				}
				HabilidadEspecial habilidadEspecial = habilidadesEspecialesAMostrar.Find(x => x.Id == idHabilidadEspecial);
				personaje.habilidadesEspeciales.Add(habilidadEspecial);
			}
			else {
				Console.WriteLine("El personaje ya contiene todas las Habilidades Especiales de la Clase");
			}

			if (((personaje.Nivel+1) % 2 != 0) && ((personaje.Nivel + 1) != 1)) {
				//aumentar caracteristica
				/*Console.WriteLine("Seleccione que tipo de caracteristica desea aumentar:");
				Console.WriteLine("1- Fija");
				Console.WriteLine("2- Variable");
				int opcion = InputUtils.leerInt(1, 2);*/
				//se comenta el codigo anterior en caso de que se requiera editar caracteristica fija en un futuro.
				int opcion = 2;
				switch (opcion)
				{
					case 1:
						Console.WriteLine("Seleccione caracteristica fija:");
						Console.WriteLine("1 - Fuerza");
						Console.WriteLine("2 - Destreza");
						Console.WriteLine("3 - Constitucion");
						Console.WriteLine("4 - Inteligencia");
						Console.WriteLine("5 - Sabiduria");
						Console.WriteLine("6 - Carisma");
						bool ingresoCorrecto = false;
						while (!ingresoCorrecto) {
							int opcion2 = InputUtils.leerInt(1, 6);
							switch (opcion2)
							{
								case 1:
									if (personaje.Fuerza < 10)
									{
										personaje.Fuerza++;
										ingresoCorrecto = true;
									}
									else {
										Console.WriteLine("La habilidad ya tiene el maximo puntaje");
									}
									break;
								case 2:
									if (personaje.Destreza < 10)
									{
										personaje.Destreza++;
										ingresoCorrecto = true;
									}
									else
									{
										Console.WriteLine("La habilidad ya tiene el maximo puntaje");
									}
									break;
								case 3:
									if (personaje.Constitucion < 10)
									{
										personaje.Constitucion++;
										ingresoCorrecto = true;
									}
									else
									{
										Console.WriteLine("La habilidad ya tiene el maximo puntaje");
									}
									break;
								case 4:
									if (personaje.Inteligencia < 10)
									{
										personaje.Inteligencia++;
										ingresoCorrecto = true;
									}
									else
									{
										Console.WriteLine("La habilidad ya tiene el maximo puntaje");
									}
									break;
								case 5:
									if (personaje.Sabiduria < 10)
									{
										personaje.Sabiduria++;
										ingresoCorrecto = true;
									}
									else
									{
										Console.WriteLine("La habilidad ya tiene el maximo puntaje");
									}
									break;
								case 6:
									if (personaje.Carisma < 10)
									{
										personaje.Carisma++;
										ingresoCorrecto = true;
									}
									else
									{
										Console.WriteLine("La habilidad ya tiene el maximo puntaje");
									}
									break;
								default:
									Console.WriteLine("La opcion ingresada no es correcta");
									break;
							}
							if (personaje.Fuerza == 10 &&
								personaje.Destreza == 10 &&
								personaje.Constitucion == 10 &&
								personaje.Inteligencia == 10 &&
								personaje.Sabiduria == 10 &&
								personaje.Carisma == 10
								) ingresoCorrecto = true;
						}
						break;
					case 2:
						Console.WriteLine("Seleccione caracteristica variable:");
						List<PersonajeCaracteristica> personajeCaracteristicasDePersonaje = PersonajeCaracteristicaDAO.obtenerCaracteristicaPersonajesPorPersonaje(personaje.Id);
						foreach (PersonajeCaracteristica item in personajeCaracteristicasDePersonaje) {
							Console.WriteLine("Id: {0} --- Nombre: {1} --- Valor: {2}", item.Id, item.caracteristicaVariable.nombre, item.Valor);
						}
						bool ingresoCorrecto2 = false;
						while (!ingresoCorrecto2)
						{
							int idCaracteristicaVariable = InputUtils.leerId();
							if (personajeCaracteristicasDePersonaje.Find(x => x.Id == idCaracteristicaVariable) != null && personajeCaracteristicasDePersonaje.Find(x => x.Id == idCaracteristicaVariable).Valor<10) {
								ingresoCorrecto2 = true;
								personajeCaracteristicasDePersonaje.Find(x => x.Id == idCaracteristicaVariable).Valor++;
							}
							if (!ingresoCorrecto2) Console.WriteLine("No se encontro la caracteristica variable o su valor es mayor o igual a 10.");
						}
						break;
					default:
						Console.WriteLine("La opcion ingresada no es correcta");
						break;
				}
			}

			personaje.Nivel++;
		}

		public static void ListarPorClase() {
			ClasesControlador.Listar();
			Console.WriteLine("Seleccione Id:");
			int id = InputUtils.leerId();
			if (ClasesDAO.obtener(id) == null)
			{
				Console.WriteLine("Id no existe.");
				return;
			}
			Clase clase = ClasesDAO.obtener(id);

			foreach (Personaje item in clase.personajes)
			{
				Console.WriteLine("Id: {0} --- Nombre: {1} --- Nivel: {2}", item.Id, item.Nombre, item.Nivel);
				Console.WriteLine("****Caracteristicas****");
				Console.WriteLine("Fuerza: {0}", item.Fuerza);
				Console.WriteLine("Destreza: {0}", item.Destreza);
				Console.WriteLine("Constitucion: {0}", item.Constitucion);
				Console.WriteLine("Inteligencia: {0}", item.Inteligencia);
				Console.WriteLine("Sabiduria: {0}", item.Sabiduria);
				Console.WriteLine("Carisma: {0}", item.Carisma);
				Console.WriteLine("****Caracteristicas Variables****");
				if (PersonajeCaracteristicaDAO.obtenerCaracteristicaPersonajesPorPersonaje(item.Id).Count == 0) Console.WriteLine("Vacio");
				foreach (PersonajeCaracteristica personajeCaracteristica in PersonajeCaracteristicaDAO.obtenerCaracteristicaPersonajesPorPersonaje(item.Id))
				{
					if (RazaDAO.obtenerPorPersonaje(personajeCaracteristica.personaje.Id).caracteristicaVariable.Id == personajeCaracteristica.caracteristicaVariable.Id)
					{
						Console.WriteLine("Nombre: {0} --- Valor: {1} --- Bonus: {2}", personajeCaracteristica.caracteristicaVariable.nombre, personajeCaracteristica.Valor, RazaDAO.obtenerPorPersonaje(personajeCaracteristica.personaje.Id).Bonus);
					}
					else
					{
						Console.WriteLine("Nombre: {0} --- Valor: {1}", personajeCaracteristica.caracteristicaVariable.nombre, personajeCaracteristica.Valor);
					}

				}
			}
		}

		public static void ListarPorRaza()
		{
			RazaControlador.Listar();
			Console.WriteLine("Seleccione Id:");
			int id = InputUtils.leerId();
			if (RazaDAO.obtener(id) == null)
			{
				Console.WriteLine("Id no existe.");
				return;
			}
			Raza raza = RazaDAO.obtener(id);
			foreach (Personaje item in raza.personajes)
			{
				Console.WriteLine("Id: {0} --- Nombre: {1} --- Nivel: {2}", item.Id, item.Nombre, item.Nivel);
				Console.WriteLine("****Caracteristicas****");
				Console.WriteLine("Fuerza: {0}", item.Fuerza);
				Console.WriteLine("Destreza: {0}", item.Destreza);
				Console.WriteLine("Constitucion: {0}", item.Constitucion);
				Console.WriteLine("Inteligencia: {0}", item.Inteligencia);
				Console.WriteLine("Sabiduria: {0}", item.Sabiduria);
				Console.WriteLine("Carisma: {0}", item.Carisma);
				Console.WriteLine("****Caracteristicas Variables****");
				if (PersonajeCaracteristicaDAO.obtenerCaracteristicaPersonajesPorPersonaje(item.Id).Count == 0) Console.WriteLine("Vacio");
				foreach (PersonajeCaracteristica personajeCaracteristica in PersonajeCaracteristicaDAO.obtenerCaracteristicaPersonajesPorPersonaje(item.Id))
				{
					if (RazaDAO.obtenerPorPersonaje(personajeCaracteristica.personaje.Id).caracteristicaVariable.Id == personajeCaracteristica.caracteristicaVariable.Id)
					{
						Console.WriteLine("Nombre: {0} --- Valor: {1} --- Bonus: {2}", personajeCaracteristica.caracteristicaVariable.nombre, personajeCaracteristica.Valor, RazaDAO.obtenerPorPersonaje(personajeCaracteristica.personaje.Id).Bonus);
					}
					else
					{
						Console.WriteLine("Nombre: {0} --- Valor: {1}", personajeCaracteristica.caracteristicaVariable.nombre, personajeCaracteristica.Valor);
					}

				}
			}
		}

	}
}
