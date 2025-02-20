﻿using Newtonsoft.Json;

using System.Collections.Generic;

namespace VimeoVHX.Video
{
    public class WatchList
    {
        [JsonProperty("_links")]
        public Links.Links Links { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
        [JsonProperty("_embedded")]
        public Embedded Embedded { get; set; }
    }

    public class Embedded
    {
        [JsonProperty("items")]
        public List<Video> Videos { get; set; }
    }
}
