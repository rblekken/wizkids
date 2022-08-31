using System;
namespace Wizkids.Api.Services
{
    public class Prediction
    {
        public List<string> CustomWords { get; set; } = new List<string>();
        public List<string> DictionaryWords { get; set; } = new List<string>();
    }
}