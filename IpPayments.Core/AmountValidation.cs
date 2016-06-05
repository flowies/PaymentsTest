namespace IpPayments.Core
{
    public class AmountValidation
    {
        public static bool IsAmountValid(long amount)
        {
            //The spec said between, I would think It should be included but floowing the spec
            if (amount > 99 && amount < 99999999)
            {
                return true;
            }
            return false;
        }
    }
}
