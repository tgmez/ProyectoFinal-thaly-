using Persistencia.daos;
using Persistencia.interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.fabricas
{
	public class CaracteristicaVariableFactory
	{

		private static CaracteristicaVariableFactory instance;
		private static CaracteristicaVariableInterfaz Interfaz;

		private CaracteristicaVariableFactory() {
			Interfaz = new CaracteristicasVariablesDAO();
		}

		public static CaracteristicaVariableFactory Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new CaracteristicaVariableFactory();
				}
				return instance;
			}
		}

		public CaracteristicaVariableInterfaz obtenerDAO()
		{
			return Interfaz;
		}

	}
}
