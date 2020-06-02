using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    class ShippingProcessor
    {
        public void MailProduct(Product product)
        {
            var productStockRepository = new ProductStockRepository();
            productStockRepository.ReduceStock(product);
            Console.WriteLine("Calling to shipping API");
        }
    }
}
