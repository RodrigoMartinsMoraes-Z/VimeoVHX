using System;
using System.Configuration;

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

            var r = resources.ListOfProducts(null).Result;

            Console.WriteLine("fim do teste");
        }
    }
}
