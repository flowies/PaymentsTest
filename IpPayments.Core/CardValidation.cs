using System;

namespace IpPayments.Core
{
    public class CardValidation
    {
        // Not reinventing the wheel here there are a long of method out the to do this.
        // http://orb-of-knowledge.blogspot.com.au/2009/08/extremely-fast-luhn-function-for-c.html
        private static bool IsValidLuhnNumber(string number)
        {
            var deltas = new[] { 0, 1, 2, 3, 4, -4, -3, -2, -1, 0 };
            var checksum = 0;
            var chars = number.ToCharArray();
            for (var i = chars.Length - 1; i > -1; i--)
            {
                var j = chars[i] - 48;
                checksum += j;
                if ((i - chars.Length) % 2 == 0)
                    checksum += deltas[j];
            }

            return checksum % 10 == 0;
        }

        public static bool IsValidCardNumber(string number)
        {
            // I would normal allow for space and - which users sometimes enters.
            // But its unclear fromthe requirements
            // number = number.Replace(" ", "").Replace("-", "");

            //Lenght test
            //This won't work for Amex and Dinners
            if (number.Length != 16)
            {
                return false;
            }

            //number test
            long numberTest;
            if (!long.TryParse(number, out numberTest))
            {
                return false;
            }

            //Luhn test
            return IsValidLuhnNumber(number);
        }

        public static bool IsValidCard(string cardNumber, int expiryMonth, int expiryYear)
        {
            // Check card number
            if (!IsValidCardNumber(cardNumber))
            {
                return false;
            }

            //check Month is a month
            if (expiryMonth < 0 || expiryMonth > 13)
            {
                return false;
            }

            // Check year is equal or greater than current
            // I would normal add an upper limit here to cut out crap data
            // Timezone may be a problem is for 1 day a year....
            if (expiryYear < DateTime.Now.Year)
            {
                return false;
            }

            // Normally card expiry at the end of the month
            if (expiryYear == DateTime.Now.Year && expiryMonth < DateTime.Now.Month)
            {
                return false;
            }
            return true;
        }
    }
}
