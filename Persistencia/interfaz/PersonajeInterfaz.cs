using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.modelos;

namespace Persistencia.interfaz
{
	public interface PersonajeInterfaz
	{
		void crear(Personaje personaje);
		void modificar(Personaje personaje);
		List<Personaje> listar();
		void eliminar(Personaje personaje);
		Personaje obtener(int id);
		bool personajeTieneRaza(int id);
		bool personajeTieneClase(int id);
	}
}
