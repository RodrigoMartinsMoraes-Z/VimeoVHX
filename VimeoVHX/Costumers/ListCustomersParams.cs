using Newtonsoft.Json;

using System;

namespace VimeoVHX.Costumers
{
    public class ListCustomersParams
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
        public Links.Links Links { get; set; }

    }

}
