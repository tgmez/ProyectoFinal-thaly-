using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.modelos
{
	public class Raza
	{
		public int Id;
		public string nombre;
		public string Descripcion;
		public List<Personaje> personajes { get; set; }
		public CaracteristicaVariable caracteristicaVariable { get; set; }
		public int Bonus{ get; set; }
	}
}
