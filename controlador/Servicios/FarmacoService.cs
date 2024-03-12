using aplicacionFarmacos.modelo;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace aplicacionFarmacos.controlador
{
	public class FarmacoService : IFarmacoResService
	{

		private readonly string urlAPI = "https://cima.aemps.es/cima/rest/medicamentos?practiv1=Etinilestradiol";

        public async Task<List<FarmacoResponse>> Obtener()
        {
           
                var client = new HttpClient();
                var response = await client.GetAsync(urlAPI);
                var responseBody = await response.Content.ReadAsStringAsync();
                JsonNode resultsNode = JsonNode.Parse(responseBody);
                JsonNode results = resultsNode["resultados"];


                var farmacosData = JsonSerializer.Deserialize<List<FarmacoResponse>>(results.ToString());
            
                return farmacosData;
            
        }
    }

}