using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.Tests
{
    public class FakeDataAccessLayerStub : DataAccessLayerContractLib.IDataAccessLayerContract
    {
        public Dictionary<int, string> ReadAttributes()
        {
            var FeatureDictionary = new Dictionary<int, string>();
            FeatureDictionary.Add(2, "touchscreen");
            FeatureDictionary.Add(3, "category");
            return FeatureDictionary;
        }

        public List<string> ReadData(Dictionary<int, string> FeaturesDictionary, Dictionary<int, string> AnswerDictionary, int QuestionNumber)
        {
            List<string> Options = new List<string>();
            Options.Add("Telemetry");
            Options.Add("MM cum PM");
            Options.Add("EWS");
            Options.Add("Spot Check PM");
            Options.Add("Bedside");
            return Options;
        }
    }
}

