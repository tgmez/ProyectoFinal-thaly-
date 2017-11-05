using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.modelos;

namespace Persistencia
{
	public static class Datos
	{
		public static List<Clase> clases { get; set; }
		public static List<Personaje> personajes { get; set; }
		public static List<CaracteristicaVariable> caracteristicasVariables { get; set; }
		public static List<Raza> razas  { get; set; }
		public static List<HabilidadEspecial> habilidadesEspeciales  { get; set; }
		public static List<PersonajeCaracteristica> personajesCaracteristicas { get; set; }

		public static void inicializar() {
			clases = new List<Clase>();
			personajes = new List<Personaje>();
			caracteristicasVariables = new List<CaracteristicaVariable>();
			razas = new List<Raza>();
			habilidadesEspeciales = new List<HabilidadEspecial>();
			personajesCaracteristicas = new List<PersonajeCaracteristica>();
		}

	}
}
