using System;

namespace VimeoVHX.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Price Price { get; set; }
        public bool IsActive { get; set; }
        public int SeriesCount { get; set; }
        public int MoviesCount { get; set; }
        public int PlaylistsCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
