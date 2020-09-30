using System;
using System.Configuration;

namespace VimeoVHX.Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            IVHXService service;

            var key = ConfigurationManager.AppSettings.Get("VHXKey");

            service.SetAuthentication(key);

            Console.WriteLine("iniciando teste");

            var r = service.ListOfProducts(null).Result;

            Console.WriteLine("fim do teste");
        }
    }
}
