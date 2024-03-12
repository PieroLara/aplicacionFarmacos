using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplicacionFarmacos.modelo
{
    public class Recordatorio
    {
        String nombre;
        FarmacoResponse farmacoActual;
        DateTime Repeticiones;

        public Recordatorio(FarmacoResponse farmacoActual, DateTime Repeticiones, String nombre) { this.farmacoActual = farmacoActual; this.Repeticiones = Repeticiones; this.nombre = nombre; }
    }
}
