using Microsoft.AspNetCore.Mvc;
using Wizkids.Api.Controllers.Messages;
using Wizkids.Api.Services;

namespace Wizkids.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PredictionController : ControllerBase{
    private IPredictionService _predictionService;
    private readonly ILogger<PredictionController> _logger;

    public PredictionController(IPredictionService predictionService, ILogger<PredictionController> logger)
    {
        _predictionService = predictionService;
        _logger = logger;
    }
    [HttpGet()]
    public async Task<ActionResult<PredictionResponse>> GetPrediction(string word, string language= "en-GB")
    {
        _logger.LogInformation($"Incoming request - word: {word}, language: {language}");
        var predictions = await _predictionService.GetPredictions(word, language);
        return new PredictionResponse
        {
            CustomWords = predictions.CustomWords,
            DictionaryWords = predictions.DictionaryWords
        };
    } 
}