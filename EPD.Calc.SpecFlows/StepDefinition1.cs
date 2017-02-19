using EPD.Calc.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace EPD.Calc.SpecFlows
{
    [Binding]
    public sealed class StepDefinition1
    {
        private ScenarioContext _scenarioContext;
        private readonly Calculator _calc;

        public StepDefinition1(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            _calc = new Calculator();
        }

        [Given("I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator(int number)
        {
            _calc.EnterNumber(number);
        }

        [When("I press add")]
        public void WhenIPressAdd()
        {
            _calc.Sum();
        }

        [When("I press multiply")]
        public void WhenIPressMultiply()
        {
            _calc.Product();
        }

        [When("I press subtract")]
        public void WhenIPressSubtract()
        {
            _calc.Subtract();
        }

        [Then("the result should be (.*) on the screen")]
        public void ThenTheResultShouldBe(int result)
        {
            Assert.AreEqual(result, _calc.Result);
        }
    }
}
