using aplicacionFarmacos.modelo;
namespace aplicacionFarmacos.controlador
{
    public interface IFarmacoResService
    {
        public Task<List<FarmacoResponse>> Obtener();
    }
}