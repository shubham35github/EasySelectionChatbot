using System;
using System.Collections.Generic;
using Chatbot.Tests;
using ChatBotApiProcessorLib;
using DataAccessLayerContractLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace ChatBotApi.Tests
{
    [TestClass]
    public class ChatBotControllerTests
    {
        [TestMethod]
        public void Given_correct_parameters_when_process_invoked_then_nextQuestionOptionModel_expected()
        { 
            ChatBotProcessor chatbot = new ChatBotProcessor(new FakeDataAccessLayerStub());
            var QuestionOption=chatbot.Process(2, "true");
            List<string> Options = new List<string>();
            Options.Add("Telemetry");
            Options.Add("MM cum PM");
            Options.Add("EWS");
            Options.Add("Spot Check PM");
            Options.Add("Bedside");

            Assert.AreEqual("Choose from the following CATEGORY options:",QuestionOption.Qusetion);
            for(int i=0; i<QuestionOption.Options.Count;i++)
            {
                Assert.AreEqual(QuestionOption.Options[i], Options[i]);
            }

        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Given_wrong_parameters_when_process_invoked_null_expected()
        {
            ChatBotProcessor chatbot = new ChatBotProcessor(new FakeDataAccessLayerStub());
            var QuestionOption = chatbot.Process(100, "wrong");
           
        }
       
            
        }
       
    }

