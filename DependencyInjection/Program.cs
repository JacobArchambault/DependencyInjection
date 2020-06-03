using System;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    class Program
    {
        public static readonly IServiceProvider Container = new ContainerBuilder().Build();
        static void Main(string[] args)
        {
            var product = string.Empty;
            var productStockRepository = new ProductStockRepository();
            var orderManager = Container.GetService<IOrderManager>();


            while (product != "exit")
            {
                Console.WriteLine("Enter a product: " +
                    "Keyboard = 0," +
                    "Mouse = 1," +
                    "Mic = 2," +
                    "Speaker = 3");
                product = Console.ReadLine();
                try
                {
                    if (Enum.TryParse(product, out Product productEnum))
                    {
                        Console.WriteLine("Please enter a valid payment method: XXXXXXXXXXXXXXXX;MMYY");
                        var paymentsMethod = Console.ReadLine();
                        if (string.IsNullOrEmpty(paymentsMethod) || paymentsMethod.Split(";").Length != 2)
                        {
                            throw new Exception("Invalid payment method");
                        }
                        orderManager.Submit(productEnum, paymentsMethod.Split(";")[0], paymentsMethod.Split(";")[1]);
                        Console.WriteLine($"{productEnum} has been shipped");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Product");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
