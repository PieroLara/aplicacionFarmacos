
using aplicacionFarmacos.modelo;
using System.Xml.Serialization;

namespace aplicacionFarmacos.controlador.Ficheros
{
    public class GestionaRecordatorios
    {
        public GestionaRecordatorios() { }
        private string fichero = "recordatorio.xml";
        public void SerializarRecordatorio(Recordatorio recordatorio)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Recordatorio));
                using (FileStream stream = new FileStream(fichero, FileMode.Create))
                {
                    serializer.Serialize(stream, recordatorio);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al serializar el objeto: " + ex.Message);
            }
        }
        public Recordatorio? DeserializarRecordatorio()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Recordatorio));
                using (FileStream stream = new FileStream(fichero, FileMode.Open))
                {
                    return (Recordatorio)serializer.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
