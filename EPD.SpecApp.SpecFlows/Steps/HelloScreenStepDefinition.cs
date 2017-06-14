using EPD.SpecApp.Client.ViewModels;
using EPD.SpecApp.Services;
using EPD.SpecApp.SpecFlows.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using System;

namespace EPD.SpecApp.SpecFlows.Steps
{
    [Binding]
    public sealed class HelloScreenStepsDefinition
    {
        private readonly ScenarioContext _scenarioContext;

        public HelloScreenStepsDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
        }

        [Given("I have displayed the hello screen")]
        public void GivenIHaveDisplayedTheHelloScreen()
        {
            _scenarioContext["vm"] = new HelloViewModel(new ServiceInvokerFactory<IHelloWorldService>(new HelloWorldService()));
        }

        [When(@"I have entered (.*) as the name")]
        public void IHaveEnteredName(string name)
        {
            (_scenarioContext["vm"] as HelloViewModel).Name = name;
        }

        [Then("the message (.*) is displayed")]
        public void ThenTheResultShouldBe(string result)
        {
            Assert.AreEqual(result, (_scenarioContext["vm"] as HelloViewModel).Text);
        }
    }
}
