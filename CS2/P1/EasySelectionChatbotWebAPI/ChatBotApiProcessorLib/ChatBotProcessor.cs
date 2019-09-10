using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerContractLib;
using QuestionOptionModelLib;

namespace ChatBotApiProcessorLib
{
    public class ChatBotProcessor
    {
        private IDataAccessLayerContract dataRef;
        public ChatBotProcessor(IDataAccessLayerContract dataRef)
        {
            this.dataRef = dataRef;
        }
        public QuestionOptionModel Process(int PreviousQuestion, string OptionSelected)
        {
            try
            {
                var FeatureDictionary = dataRef.ReadAttributes();
                int i = 0;
                string Question;
                List<string> Options = new List<string>();
                Dictionary<int, string> AnswerDictionary = new Dictionary<int, string>();
                AnswerDictionary.Add(PreviousQuestion, OptionSelected);
                for (i = PreviousQuestion + 1; i < FeatureDictionary.Count; i++)
                {
                    var optionsTemp = dataRef.ReadData(FeatureDictionary, AnswerDictionary, i);
                    if (optionsTemp.Count > 0)
                    {
                        foreach (var option in optionsTemp)
                        {
                            Options.Add(option);
                        }
                        break;
                    }
                }
                if (Options.Contains("true") || Options.Contains("false"))
                {
                     Question=string.Format("Do you want {0} ?", FeatureDictionary[i].ToUpper());
                }
                else
                {
                     Question=string.Format("Choose from the following {0} options:", FeatureDictionary[i].ToUpper());
                }
                return new QuestionOptionModel { Qusetion = Question, Options = Options };
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
