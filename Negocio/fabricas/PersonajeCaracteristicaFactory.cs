using Persistencia.daos;
using Persistencia.interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.fabricas
{
	public class PersonajeCaracteristicaFactory
	{

		private static PersonajeCaracteristicaFactory instance;
		private static PersonajeCaracteristicaInterfaz Interfaz;

		private PersonajeCaracteristicaFactory()
		{
			Interfaz = new PersonajeCaracteristicaDAO();
		}

		public static PersonajeCaracteristicaFactory Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new PersonajeCaracteristicaFactory();
				}
				return instance;
			}
		}

		public PersonajeCaracteristicaInterfaz obtenerDAO()
		{
			return Interfaz;
		}

	}
}
