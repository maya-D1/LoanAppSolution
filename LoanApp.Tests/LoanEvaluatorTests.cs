using Xunit;
using LoanApp;

namespace LoanApp.Tests
{
    public class LoanEvaluatorTests
    {
        [Fact]
        public void Should_Return_NotEligible_When_LowIncome()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(1500, true, 800, 0, true);
            Assert.Equal("Not Eligible", result);
        }

        [Fact]
        public void Should_Return_Eligible_When_HasJob_GoodCredit_NoDependents()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(3000, true, 750, 0, true);
            Assert.Equal("Eligible", result);
        }

        [Fact]
        public void Should_Return_ReviewManually_When_NoJob_GoodCredit_NoDependents()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(6000, false, 660, 0, false);
            Assert.Equal("Review Manually", result);
        }

        [Fact]
        public void Should_Return_Eligible_When_NoJob_VeryGoodCredit_HighIncome_House()
        {
            var evaluator = new LoanEvaluator();
            var result = evaluator.GetLoanEligibility(8000, false, 760, 1, true);
            Assert.Equal("Eligible", result);
        }
    }
}
