using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public interface IOrderManager
    {
        void Submit(Product product, string creditCardNumber, string expiryDate);
    }
    public class OrderManager : IOrderManager
    {
        IProductStockRepository _productStockRepository;
        IPaymentProcessor _paymentProcessor;
        IShippingProcessor _shippingProcessor;
        public OrderManager(IProductStockRepository productStockRepository, IPaymentProcessor paymentProcessor, IShippingProcessor shippingProcessor)
        {
            _productStockRepository = productStockRepository;
            _paymentProcessor = paymentProcessor;
            _shippingProcessor = shippingProcessor;
        }
        public void Submit(Product product, string creditCardNumber, string expiryDate)
        {
            // Check product stock
            if (!_productStockRepository.IsInStock(product))
            {
                throw new Exception($"{product} currently not in stock");
            }
            // Make payment
            _paymentProcessor.ChargeCreditCard(creditCardNumber, expiryDate);

            // Ship the product
            _shippingProcessor.MailProduct(product);
        }
    }
}
