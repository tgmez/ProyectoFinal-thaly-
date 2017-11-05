using Persistencia.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.interfaz
{
	public interface HabilidadesEspecialesInterfaz
	{
		void crear(HabilidadEspecial habilidadEspecial);
		void modificar(HabilidadEspecial habilidadEspecial);
		List<HabilidadEspecial> listar();
		void eliminar(HabilidadEspecial habilidadEspecial);
		HabilidadEspecial obtener(int id);
	}
}
