using Persistencia.daos;
using Persistencia.interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.fabricas
{
	public class RazaFactory
	{

		private static RazaFactory instance;
		private static RazaInterfaz Interfaz;

		private RazaFactory()
		{
			Interfaz = new RazaDAO();
		}

		public static RazaFactory Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new RazaFactory();
				}
				return instance;
			}
		}

		public RazaInterfaz obtenerDAO()
		{
			return Interfaz;
		}

	}
}
