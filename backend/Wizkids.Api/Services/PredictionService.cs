using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Wizkids.Api.Client.Prediction;
using Wizkids.Api.DataAccess;

namespace Wizkids.Api.Services;

public class PredictionService : IPredictionService
{
    private IPredictionClient _predictionClient;
    private DictionaryContext _dictionaryContext;
    public PredictionService(IPredictionClient predictionClient, DictionaryContext dictionaryContext)
    {
        _predictionClient = predictionClient;
        _dictionaryContext = dictionaryContext;
    }
    public async Task<Prediction> GetPredictions(string word, string language)
    {
        var result = new Prediction();
        string lastWord = word.Split(" ").Last();

        if(lastWord.Length > 0)
            result.CustomWords = _dictionaryContext.Words
                .AsNoTracking()
                .Where(x => !string.IsNullOrWhiteSpace(x.Value) && x.Value.StartsWith(lastWord))
                .OrderBy(x => x.Value)
                .Take(20)
                .Select(x => x.Value)
                .ToList() ?? new List<string>();

        result.DictionaryWords = await _predictionClient.GetPrediction(word, language);
        return result;
    }
}