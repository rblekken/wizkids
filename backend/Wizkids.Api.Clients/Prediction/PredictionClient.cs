using System.Text.Json;
using Microsoft.Extensions.Options;

namespace Wizkids.Api.Client.Prediction;
public class PredictionClient : IPredictionClient
{
    private HttpClient _predictionClient;
    private PredictionClientOptions _clientOptions;
    
    //Shortcuts 
    //- Inject HttpClient instead of creating it in constructor
    //- Class for handling the authentication - AuthenticatedPredictionClient or something simular that has the required authentication headers and such
    public PredictionClient(IOptions<PredictionClientOptions> clientOptions)
    {
        _clientOptions = clientOptions.Value;
        _predictionClient = CreateHttpClient();

    }

    private HttpClient CreateHttpClient()
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri(_clientOptions.BaseAddress);
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GetBearerToken());
        return client;
    }


    private string GetBearerToken(){
        return "MjAyMi0wOC0yOQ==.cnVuYXIuYmxla2tlbkBnbWFpbC5jb20=.MTU5ZjFjNzEyZDk5YTMyNDkyMTVlNTNiYzU2OGRiYjY=";
    }
    
    public async Task<List<string>> GetPrediction(string word, string language)
    {
        var response =  await _predictionClient.GetAsync($"/misc/getPredictions?locale={language}&text={word}");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<string>>(result) ?? new List<string>();
    }
}