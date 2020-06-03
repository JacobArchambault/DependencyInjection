using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public interface IPaymentProcessor
    {
        void ChargeCreditCard(string creditCardNumber, string expiryDate);
    }
    public class PaymentProcessor :IPaymentProcessor
    {
        public void ChargeCreditCard(string creditCardNumber, string expiryDate)
        {
            if (string.IsNullOrEmpty(creditCardNumber))
            {
                throw new ArgumentException("Invalid credit card");
            }
            if (string.IsNullOrEmpty(expiryDate))
            {
                throw new ArgumentException("Invalid expiration date");
            }

            Console.WriteLine("Call to Credit Card API");

        }
    }
}
