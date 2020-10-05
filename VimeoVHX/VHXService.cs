using System.Threading.Tasks;
using VimeoVHX.Costumers;
using VimeoVHX.Products;
using VimeoVHX.Video;

namespace VimeoVHX
{
    public interface IVHXService
    {
        void SetAuthentication(string key);
        Task<string> AddProductToCustomer(Product product, Customer customer, Plan plan, bool isRental);
        Task<Customer> CreateCustomer(Customer customer);
        Task<ListOfCustomers> ListOfCustomers(ListCustomersParams @params);
        Task<ListOfProducts> ListOfProducts(ListProductParams @params);
        Task<string> RemoveProductFromCustomer(Product product, Customer customer, Plan plan);
        Task<Product> RetrieveAProduct(int id);
        Task<Customer> RetrieveCustomer(int id);
        Task<Customer> UpdateCustomer(Customer customer);
        Task<WatchList> WatchingList(Customer customer);
        Task<WatchList> WatchList(Customer customer);
    }

    class VHXService : IVHXService
    {
        private readonly Resources _resources = new Resources();

        public void SetAuthentication(string key)
        {
            _resources.SetAuthentication(key);
        }

        public async Task<Product> RetrieveAProduct(int id)
        {
            return await _resources.RetrieveAProduct(id);
        }

        public async Task<ListOfProducts> ListOfProducts(ListProductParams @params)
        {
            return await _resources.ListOfProducts(@params);
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            return await _resources.CreateCustomer(customer);
        }

        public async Task<Customer> RetrieveCustomer(int id)
        {
            return await _resources.RetrieveCustomer(id);
        }

        public async Task<ListOfCustomers> ListOfCustomers(ListCustomersParams @params)
        {
            return await _resources.ListOfCustomers(@params);
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            return await _resources.UpdateCustomer(customer);
        }

        public async Task<string> AddProductToCustomer(Product product, Customer customer, Plan plan, bool isRental)
        {
            return await _resources.AddProductToCustomer(product, customer, plan, isRental);
        }

        public async Task<string> RemoveProductFromCustomer(Product product, Customer customer, Plan plan)
        {
            return await _resources.RemoveProductFromCustomer(product, customer, plan);
        }

        public async Task<WatchList> WatchingList(Customer customer)
        {
            return await _resources.WatchingList(customer);
        }

        public async Task<WatchList> WatchList(Customer customer)
        {
            return await _resources.WatchList(customer);
        }
    }
}
