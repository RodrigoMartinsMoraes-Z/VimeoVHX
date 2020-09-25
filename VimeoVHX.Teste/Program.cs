using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimeoVHX.Product;

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
