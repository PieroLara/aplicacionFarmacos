using System.Xml.Serialization;

namespace aplicacionFarmacos.modelo
{
    public class Recordatorio
    {
        public String nombre;
        public FarmacoResponse farmacoActual;
        public DateTime Repeticiones;
        public Recordatorio(FarmacoResponse farmacoActual, DateTime Repeticiones, String nombre)
        { 
            this.farmacoActual = farmacoActual;
            this.Repeticiones = Repeticiones;
            this.nombre = nombre;
        }
        public Recordatorio(){

            farmacoActual= null;
            nombre = "Invitado";
        }
    }
}
