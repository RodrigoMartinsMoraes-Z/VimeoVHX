using Newtonsoft.Json;
using System;

namespace VimeoVHX.Products
{
    public class Product
    {
        [JsonProperty("id")]
        public int Ref { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Price Price { get; set; }
        public bool IsActive { get; set; }
        public int SeriesCount { get; set; }
        public int MoviesCount { get; set; }
        public int PlaylistsCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public void Validate()
        {
            if (this == null || Ref <= 0)
            {
                throw new Exception("Product can't be null or Ref is invalid.");
            }
        }
    }
}
