using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VimeoVHX.Product;

namespace VimeoVHX
{
    class Resources
    {
        private readonly HttpClient _client = new HttpClient();

        public Resources()
        {
            PreencherCabecalho();
        }

        private void PreencherCabecalho()
        {
            string token;

            try
            {
                token = ConfigurationManager.AppSettings.Get("Token");
            }
            catch (Exception)
            {

                throw;
            }

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{token}:")));
        }

        public async Task<Product.Product> RetrieveAProduct(int href)
        {
            if (href <= 0)
            {
                throw new Exception("Href can't be null or less than 1");
            }

            HttpResponseMessage response = await _client.GetAsync("https://api.vhx.tv/products/" + href);

            return (Product.Product)await ConvertToObject(response, new Product.Product());

        }

        public async Task<ListOfProducts> ListOfProducts(ListProductParams productParams)
        {

            string queryString = await GenerateQueryString(productParams);

            HttpResponseMessage response = await _client.GetAsync("https://api.vhx.tv/products/" + queryString);

            return (ListOfProducts)await ConvertToObject(response, new ListOfProducts());
        }

        private async Task<object> ConvertToObject(HttpResponseMessage responseMessage, object obj)
        {
            if (responseMessage.IsSuccessStatusCode)
            {
                string content = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<object>(content);
            }
            else
                throw NotSuccessCode(responseMessage);
        }

        private Task<string> GenerateQueryString(object obj)
        {
            IEnumerable<string> properties = from p in obj.GetType().GetProperties()
                                             where p.GetValue(obj, null) != null
                                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return Task.FromResult(string.Join("&", properties.ToArray()));
        }

        private Exception NotSuccessCode(HttpResponseMessage response)
        {
            return new Exception("Error, tried to get a successful status code, but get: " + response.StatusCode.ToString());
        }
    }
}
