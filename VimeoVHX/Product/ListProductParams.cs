using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VimeoVHX.Product
{
    class ListProductParams
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
    enum Sort
    {
        Alphabetical,
        Newest,
        Oldest,
        Position
    }
}
