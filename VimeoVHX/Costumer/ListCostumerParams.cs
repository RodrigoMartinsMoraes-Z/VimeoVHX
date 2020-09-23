using Newtonsoft.Json;
using System;
using VimeoVHX.Product;

namespace VimeoVHX.Costumer
{
    public class ListCostumerParams
    {
        public string Product { get; set; }
        public string Email { get; set; }
        public string Query { get; set; }
        [JsonIgnore]
        public Sort Sort { get; set; }
        [JsonProperty("sort")]
        public string Ordenate { get => Enum.GetName(typeof(Sort), Sort); }
        public int Page { get; set; }
        public int PerPage { get; set; }
        [JsonProperty("_links")]
        public Links Links{ get; set; }

    }

    public class Links
    {
        public Link Self { get; set; }
        public Link Watchlist { get; set; }
        public Link Watching { get; set; }
    }

    public enum Sort
    {
        newest,
        oldest,
        latest
    }
}
