using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace IpPayments.Core.Test
{
    [Binding]
    public class ValidationSteps
    {
        private string EnteredCardNumber { get; set; }
        private bool Result { get; set; }
        private int EnteredAmount { get; set; }

        private DateTime ExpiryDate { get; set; }

        [Given(@"I have the following '(.*)'")]
        public void GivenIHave(string p0)
        {
            EnteredCardNumber = p0;
        }
        
        [When(@"I validated the Card Number")]
        public void WhenIValidatedTheCardNumber()
        {
            Result = CardValidation.IsValidCardNumber(EnteredCardNumber);
        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(string p0)
        {
            Assert.AreEqual(Result, p0.ToLower() == "valid");
        }



        [Given(@"I have amount of (.*)")]
        public void GivenIHaveAmountOf(int p0)
        {
            EnteredAmount = p0;
        }

        [When(@"I validated the amount")]
        public void WhenIValidatedTheAmount()
        {
            Result = AmountValidation.IsAmountValid(EnteredAmount);
        }

        [Given(@"I have the following '(.*)' with an expiry date '(.*)' months from now")]
        public void GivenIHaveTheFollowingWithAnExpiryDateMonthsFromNow(string p0, int p1)
        {
            EnteredCardNumber = p0;

            // Get the end of this month to work from
            var expiryDate = new DateTime(DateTime.Now.Month ==12 ?DateTime.Now.Year+1: DateTime.Now.Year, DateTime.Now.Month+1, 1);
            expiryDate = expiryDate.AddDays(-1);

            //add/minus extra months for test
            ExpiryDate = expiryDate.AddMonths(p1);

        }

        [When(@"I validated the Card")]
        public void WhenIValidatedTheCard()
        {
            Result = CardValidation.IsValidCard(EnteredCardNumber, ExpiryDate.Month, ExpiryDate.Year);
        }


    }
}
