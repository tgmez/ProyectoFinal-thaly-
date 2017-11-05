using Persistencia.daos;
using Persistencia.interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.fabricas
{
	public class HabilidadEspecialFactory
	{

		private static HabilidadEspecialFactory instance;
		private static HabilidadesEspecialesInterfaz Interfaz;

		private HabilidadEspecialFactory()
		{
			Interfaz = new HabilidadesEspecialesDAO();
		}

		public static HabilidadEspecialFactory Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new HabilidadEspecialFactory();
				}
				return instance;
			}
		}

		public HabilidadesEspecialesInterfaz obtenerDAO()
		{
			return Interfaz;
		}

	}
}
