using Newtonsoft.Json;

namespace VimeoVHX.Products
{
    public class ListOfProducts
    {
        [JsonProperty("_links")]
        public Links.Links Links { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
        [JsonProperty("_embedded")]
        public ProductList ProductList { get; set; }
    }

    public class ProductList
    {
        public Product[] Products { get; set; }
    }


}
