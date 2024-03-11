using aplicacionFarmacos.controlador.Servicios;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace aplicacionFarmacos.controlador
{
	public class FarmacoService : IFarmacoService
	{

		private string urlAPI = "https://cima.aemps.es/cima/rest/medicamentos?practiv1=Etinilestradiol";


		public async Task<List<FarmacoRes>> Obtener()
		{
			var client = new HttpClient();
			var response = await client.GetAsync(urlAPI);
			var responseBody = await response.Content.ReadAsStringAsync();
			JsonNode resultsNode = JsonNode.parse(responseBody);
			JsonNode results = resultsNode["resultados"];


			var farmacosData = JsonSerializer.Deserialize<List<aplicacionFarmacos.modelo.FarmacoRes>>(results.ToString());
			return farmacosData;
		}
	}

}