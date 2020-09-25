using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VimeoVHX.Costumers
{
    public class ListOfCustomers
    {
        [JsonProperty("_links")]
        public Links.Links Links { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
        [JsonProperty("_embedded")]
        public CustomerList CustomerList { get; set; }
    }

    public class CustomerList
    {
        public Customer[] Customers { get; set; }
    }
}
