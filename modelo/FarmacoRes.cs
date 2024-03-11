using System;
namespace aplicacionFarmacos.modelo
{
    public class FarmacoResponse
    {

        public String nombre { get; set; }
        public Foto[] fotos { get; set; }
           

        public class Foto
        {
            public string url { get; set; }
          
        }

    }
}

