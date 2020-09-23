using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VimeoVHX.Product
{
    public class ListOfProducts
    {
        [JsonProperty("_links")]
        public Links Links{ get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
        [JsonProperty("_embedded")]
        public ProductList Embedded { get; set; }
    }

    public class ProductList
    {
        public Product[] Products { get; set; }
    }

    public class Links
    {
        public Link Self { get; set; }
        public Link First { get; set; }
        public Link Prev { get; set; }
        public Link Next { get; set; }
        public Link Last { get; set; }
    }

}
