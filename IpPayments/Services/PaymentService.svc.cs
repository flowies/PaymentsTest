using IpPayments.Core;

namespace IpPayments.Services
{
    public class PaymentService : IPaymentService
    {
        public string WhatsYourId()
        {
            return CandidateId.GetId();
            
        }

        public bool IsCardNumberValid(string cardNumber)
        {
            return CardValidation.IsValidCardNumber(cardNumber);
        }

        public bool IsValidPaymentAmount(long amount)
        {
            return AmountValidation.IsAmountValid(amount);
        }

        public bool CanMakePaymentWithCard(string cardNumber, int expiryMonth, int expiryYear)
        {
            return CardValidation.IsValidCard(cardNumber, expiryMonth, expiryYear);
        }
    }
}
