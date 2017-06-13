using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPD.SpecApp.Client.ViewModels;
using EPD.SpecApp.Services;
using EPD.SpecApp.SpecFlows.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace EPD.SpecApp.SpecFlows.Steps
{
    [Binding]
    public sealed class PeopleScreenStepDefinition
    {
        [Given("I have the following people in the database")]


        [Given("I load the people screen")]
        public void GivenIHaveDisplayedTheHelloScreen()
        {
            var vm = new TableViewModel(new ServiceInvokerFactory<IHelloWorldService>(new HelloWorldService()));

            vm.Activate();

            ScenarioContext.Current["vm"] = vm;
        }

        [When(@"I have entered (.*) as the name")]
        public void IHaveEnteredName(string name)
        {
            (ScenarioContext.Current["vm"] as HelloViewModel).Name = name;
        }

        [Then("the message (.*) is displayed")]
        public void ThenTheResultShouldBe(string result)
        {
            Assert.AreEqual(result, (ScenarioContext.Current["vm"] as HelloViewModel).Text);
        }
    }
}
