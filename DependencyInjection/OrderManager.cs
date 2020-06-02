using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public class OrderManager
    {
        public void Submit(Product product, string creditCardNumber, string expiryDate)
        {
            // Check product stock
            var productStockRepository = new ProductStockRepository();
            if (!productStockRepository.IsInStock(product))
            {
                throw new Exception($"{product} currently not in stock");
            }
            // Make payment
            var paymentProcessor = new PaymentProcessor();
            paymentProcessor.ChargeCreditCard(creditCardNumber, expiryDate);

            // Ship the product
            var shippingProcessor = new ShippingProcessor();
            shippingProcessor.MailProduct(product);
        }
    }
}
