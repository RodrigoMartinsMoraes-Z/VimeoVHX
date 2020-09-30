using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VimeoVHX.Costumers;
using VimeoVHX.Products;
using VimeoVHX.Video;

namespace VimeoVHX
{
    public interface IResources
    {
        bool Authentication { get; }

        Task<string> AddProductToCustomer(Product product, Customer customer, Plan plan, bool isRental);
        Task<Customer> CreateCustomer(Customer costumer);
        Task<ListOfCustomers> ListOfCustomers(ListCustomersParams @params);
        Task<ListOfProducts> ListOfProducts(ListProductParams @params);
        Task<string> RemoveProductFromCustomer(Product product, Customer customer, Plan plan);
        Task<Product> RetrieveAProduct(int id);
        Task<Customer> RetrieveCustomer(int id);
        void SetAuthentication(string VHXKey);
        Task<Customer> UpdateCustomer(Customer customer);
        Task<WatchList> WatchingList(Customer customer);
        Task<WatchList> WatchList(Customer customer);
    }

    internal class Resources : IResources
    {
        private readonly HttpClient _client = new HttpClient();

        public bool Authentication { get; private set; }

        public void SetAuthentication(string VHXKey)
        {

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{VHXKey}:")));
            Authentication = true;

        }

        public async Task<Product> RetrieveAProduct(int id)
        {
            Authenticated();

            if (id <= 0)
            {
                throw new Exception("Href can't be null or less than 1");
            }

            HttpResponseMessage responseMessage = await _client.GetAsync("https://api.vhx.tv/products/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                string content = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Product>(content);
            }
            else
                throw NotSuccessCode(responseMessage);

        }

        public async Task<ListOfProducts> ListOfProducts(ListProductParams @params)
        {
            Authenticated();

            HttpResponseMessage responseMessage;

            if (@params != null)
            {
                string queryString = await GenerateQueryString(@params);
                responseMessage = await _client.GetAsync("https://api.vhx.tv/products/" + queryString);
            }
            else
                responseMessage = await _client.GetAsync("https://api.vhx.tv/products/");

            if (responseMessage.IsSuccessStatusCode)
            {
                string content = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ListOfProducts>(content);
            }
            else
                throw NotSuccessCode(responseMessage);
        }

        public async Task<Customer> CreateCustomer(Customer costumer)
        {
            Authenticated();

            if (costumer == null)
                throw new Exception("Costumer can't be null");

            var json = GenerateJson(costumer);

            HttpResponseMessage responseMessage = await _client.PostAsync("https://api.vhx.tv/customers", json);

            if (responseMessage.IsSuccessStatusCode)
            {
                string content = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Customer>(content);
            }
            else
                throw NotSuccessCode(responseMessage);

        }

        public async Task<Customer> RetrieveCustomer(int id)
        {
            Authenticated();

            if (id <= 0)
            {
                throw new Exception("Href can't be null or less than 1");
            }
            HttpResponseMessage responseMessage = await _client.GetAsync("https://api.vhx.tv/customers/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                string content = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Customer>(content);
            }
            else
                throw NotSuccessCode(responseMessage);

        }

        public async Task<ListOfCustomers> ListOfCustomers(ListCustomersParams @params)
        {
            Authenticated();

            HttpResponseMessage responseMessage;
            if (@params != null)
            {
                string queryString = await GenerateQueryString(@params);
                responseMessage = await _client.GetAsync("https://api.vhx.tv/customers" + queryString);
            }
            else
                responseMessage = await _client.GetAsync("https://api.vhx.tv/customers");

            if (responseMessage.IsSuccessStatusCode)
            {
                string content = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ListOfCustomers>(content);
            }
            else
                throw NotSuccessCode(responseMessage);

        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            Authenticated();

            customer.Validate();

            HttpResponseMessage responseMessage = await _client.PutAsync($"https://api.vhx.tv/customers/{customer.Ref}", GenerateJson(customer));

            if (responseMessage.IsSuccessStatusCode)
            {
                string content = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Customer>(content);
            }
            else
                throw NotSuccessCode(responseMessage);
        }

        public async Task<string> AddProductToCustomer(Product product, Customer customer, Plan plan, bool isRental)
        {
            Authenticated();

            product.Validate();

            customer.Validate();

            object obj = new
            {
                Product = "https://api.vhx.tv/products/" + product.Ref,
                Plan = Enum.GetName(typeof(Plan), plan),
                IsRental = isRental
            };
            var json = GenerateJson(obj);

            HttpResponseMessage responseMessage = await _client.PutAsync($"https://api.vhx.tv/customers/{customer.Ref}/products", json);

            if (responseMessage.IsSuccessStatusCode)
            {
                string content = await responseMessage.Content.ReadAsStringAsync();
                return content;
            }
            else
                throw NotSuccessCode(responseMessage);
        }

        public async Task<string> RemoveProductFromCustomer(Product product, Customer customer, Plan plan)
        {
            Authenticated();

            if (product == null || product.Ref <= 0)
            {
                throw new Exception("Product can't be null or Ref is invalid.");
            }

            if (customer == null || customer.Ref <= 0)
            {
                throw new Exception("Customer can't be null or Ref is invalid.");
            }

            object obj = new
            {
                Product = "https://api.vhx.tv/products/" + product.Ref,
                Plan = Enum.GetName(typeof(Plan), plan)
            };
            var json = GenerateQueryString(GenerateJson(obj));

            HttpResponseMessage responseMessage = await _client.DeleteAsync($"https://api.vhx.tv/customers/{customer.Ref}/products{json}");

            if (responseMessage.IsSuccessStatusCode)
            {
                string content = await responseMessage.Content.ReadAsStringAsync();
                return content;
            }
            else
                throw NotSuccessCode(responseMessage);
        }

        public async Task<WatchList> WatchingList(Customer customer)
        {
            Authenticated();

            customer.Validate();

            _client.DefaultRequestHeaders.Add("VHX-Customer", "https://api.vhx.tv/customers/" + customer.Ref);

            HttpResponseMessage responseMessage = await _client.GetAsync($"https://api.vhx.tv/customers/{customer.Ref}/watching");

            if (responseMessage.IsSuccessStatusCode)
            {
                string content = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WatchList>(content);
            }
            else
                throw NotSuccessCode(responseMessage);
        }

        public async Task<WatchList> WatchList(Customer customer)
        {
            Authenticated();

            customer.Validate();

            HttpResponseMessage responseMessage = await _client.GetAsync($"https://api.vhx.tv/customers/{customer.Ref}/watchlist");

            if (responseMessage.IsSuccessStatusCode)
            {
                string content = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WatchList>(content);
            }
            else
                throw NotSuccessCode(responseMessage);
        }

        internal StringContent GenerateJson(object objeto)
        {
            string serializedObject = $"{JsonConvert.SerializeObject(objeto)}";
            return new StringContent(serializedObject, Encoding.UTF8, "application/json");
        }

        private void Authenticated()
        {
            if (!Authentication)
                throw new Exception("Please set authetication using the method 'SetAuthentication'.");
        }

        private Task<string> GenerateQueryString(object obj)
        {
            IEnumerable<string> properties = from p in obj.GetType().GetProperties()
                                             where p.GetValue(obj, null) != null
                                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return Task.FromResult('?' + string.Join("&", properties.ToArray()));
        }

        private Exception NotSuccessCode(HttpResponseMessage response)
        {
            return new Exception($"Error, tried to get a successful status code, but get: {response.StatusCode}. The server has returned: {response.Content.ReadAsStringAsync()}");
        }
    }
}
