using Persistencia.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.interfaz
{
	public interface CaracteristicaVariableInterfaz
	{
		void crear(CaracteristicaVariable caracteristicaVariable);
		void modificar(CaracteristicaVariable caracteristicaVariable);
		List<CaracteristicaVariable> listar();
		void eliminar(CaracteristicaVariable caracteristicaVariable);
		CaracteristicaVariable obtener(int id);
	}
}
