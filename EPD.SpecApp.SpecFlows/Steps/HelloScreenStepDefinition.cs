using EPD.SpecApp.Client.ViewModels;
using EPD.SpecApp.Services;
using EPD.SpecApp.SpecFlows.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace EPD.SpecApp.SpecFlows.Steps
{
    [Binding]
    public sealed class HelloScreenStepsDefinition
    {
        [Given("I have displayed the hello screen")]
        public void GivenIHaveDisplayedTheHelloScreen()
        {
            ScenarioContext.Current["vm"] = new TableViewModel(new ServiceInvokerFactory<IHelloWorldService>(new HelloWorldService()));
        }

        [When(@"I have entered (.*) as the name")]
        public void IHaveEnteredName(string name)
        {
            (ScenarioContext.Current["vm"] as TableViewModel).Name = name;
        }

        [Then("the message (.*) is displayed")]
        public void ThenTheResultShouldBe(string result)
        {
            Assert.AreEqual(result, (ScenarioContext.Current["vm"] as TableViewModel).Text);
        }
    }
}
