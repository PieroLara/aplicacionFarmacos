
using System;
using System.IO;

using System.Xml;
namespace aplicacionFarmacos.modelo
{
    public class FarmacoResponse
    {

        public string nombre { get; set; }
        public Foto[] fotos { get; set; }

        public string nregistro { get; set; }

        public class Foto
        {
            public string url { get; set; }
          
        }
        public void guaraFichero()
        {
            string jsonFarmaco = JsonConvert.SerializeObject(farmaco, Formatting.Indented);

            // Escribir el JSON en un archivo
            string filePath = "farmaco.json";
            File.WriteAllText(filePath, jsonFarmaco);
        }
    }
    
}

