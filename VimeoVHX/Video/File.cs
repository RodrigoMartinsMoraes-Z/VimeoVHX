using Newtonsoft.Json;

using System;

namespace VimeoVHX.Video
{
    public class File
    {
        [JsonProperty("_links")]
        public Links.Links Links { get; set; }
        public string Quality { get; set; }
        public string Format { get; set; }
        public string Method { get; set; }
        public Size Size { get; set; }
        public string MimeType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class Size
    {
        public byte[] Bytes { get; set; }
        public string Formatted { get; set; }
    }
}
