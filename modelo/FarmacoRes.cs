
using Newtonsoft.Json;
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
    }
}
    


