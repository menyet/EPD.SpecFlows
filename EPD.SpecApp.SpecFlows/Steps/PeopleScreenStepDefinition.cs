using EPD.SpecApp.Client.ViewModels;
using EPD.SpecApp.Services;
using EPD.SpecApp.SpecFlows.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace EPD.SpecApp.SpecFlows.Steps
{
    [Binding]
    public sealed class PeopleScreenStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;

        public PeopleScreenStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
        }



        [Given("I have the following people in the database")]
        public void IHaveTheFollowingPeopleInTheDatabase(Table table)
        {
            Database.Instance.Persons.Clear();
            foreach (var p in table.CreateSet<Person>())
            {
                Database.Instance.Persons.Add(new Services.Person
                {
                    Name = p.Name,
                    Weight = p.Weight
                });
            }
        }

        [Then("I see the following table")]
        public void ISeeTheFollowingTable(Table table)
        {
            var vm = (_scenarioContext["vm"] as TableViewModel);

            var people = vm.Persons;

            var i = 0;

            foreach (var p in table.CreateSet<Person>())
            {
                Assert.AreEqual(p.Name, people[i].Name);
                Assert.AreEqual(p.Weight, people[i].Weight);

                i++;
            }
        }

        [Then("the average weight is (.*)")]
        public void TheAverageWeightIs(string weight)
        {

        }

        [When("I load the people screen")]
        public void GivenILoadThePeopleScreen()
        {
            var vm = new TableViewModel(new ServiceInvokerFactory<IHelloWorldService>(new HelloWorldService()));

            vm.Activate();

            _scenarioContext["vm"] = vm;
        }

        [When(@"I add a new person (.*) of weight (.*)")]
        public void IAddANewPerson(string name, int weight)
        {
            var vm = (_scenarioContext["vm"] as TableViewModel);

            vm.Name = name;
            vm.Weight = weight;

            vm.AddCommand.Execute(null);
        }


        private class Person
        {
            public string Name { get; set; }

            public int Weight { get; set; }
        }
    }
}
