using System;
using System.Configuration;

using VimeoVHX.Costumers;

namespace VimeoVHX.Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            Resources resources = new Resources();

            var key = ConfigurationManager.AppSettings.Get("VHXKey");

            resources.SetAuthentication(key);

            Console.WriteLine("iniciando teste");

            Customer customer = new Customer
            {
                DaysValid = 180,
                Email = "rodrigo_moraes@hotmail.com.br",
                Name = "Rodrigo Martins Moraes",
                Plan = Plan.Standard,

            };

            var r = resources.CreateCustomer(customer).Result;

            Console.WriteLine("fim do teste");
        }
    }
}
