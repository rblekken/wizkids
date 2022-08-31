namespace Wizkids.Api.Services;

public interface IPredictionService{
    public Task<Prediction> GetPredictions(string word, string language);
}