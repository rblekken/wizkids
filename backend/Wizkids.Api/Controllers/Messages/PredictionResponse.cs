using System;
namespace Wizkids.Api.Controllers.Messages
{
    public class PredictionResponse
    {
        public List<string> CustomWords { get; set; } = new List<string>();
        public List<string> DictionaryWords { get; set; } = new List<string>();
    }
}

