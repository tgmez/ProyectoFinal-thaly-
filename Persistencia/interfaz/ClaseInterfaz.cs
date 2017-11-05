using Persistencia.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.interfaz
{
	public interface ClaseInterfaz
	{
		void crear(Clase clase);
		void modificar(Clase clase);
		List<Clase> listar();
		void eliminar(Clase clase);
		Clase obtener(int id);
		Clase obtenerPorIdPersonaje(int id);
	}
}
