using Newtonsoft.Json;
using System;

namespace VimeoVHX.Products
{
    public class ListProductParams
    {
        public string Query { get; set; }
        public bool Active { get; set; }
        [JsonIgnore]
        public Sort Sort { get; set; }
        [JsonProperty("sort")]
        public string Ordenate { get => Enum.GetName(typeof(Sort), Sort); }
        public int Page { get; set; }
        public int PerPage { get; set; }
    }
    public enum Sort
    {
        Alphabetical,
        Newest,
        Oldest,
        Position
    }
}
