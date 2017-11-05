using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class DatosUtils
    {
        public static void inicializarDatos() {
            Datos.inicializar();
        }
    }
}
