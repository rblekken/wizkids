namespace Wizkids.Api.Client.Prediction;
public interface IPredictionClient{
    Task<List<string>> GetPrediction(string word, string language);
}